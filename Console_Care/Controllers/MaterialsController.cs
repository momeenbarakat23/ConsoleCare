using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Console_Care.Models;

namespace Console_Care.Controllers
{
    public class MaterialsController : Controller
    {
        private readonly Appdbcontext _context;

        public MaterialsController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: Materials
        public async Task<IActionResult> Index()
        {
            var data = await _context.materials.ToListAsync();
            return View(data);
        }


        // GET: Materials/Create
        public IActionResult addmaterial()
        {
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addmaterial( Materials materials)
        {
            if (ModelState.IsValid)
            {
                materials.Quantityinstorage = materials.Quantity;
               await _context.AddAsync(materials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materials);
        }

        // GET: Materials/Edit/5
        public async Task<IActionResult> Edititem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materials = await _context.materials.FindAsync(id);
            if (materials == null)
            {
                return NotFound();
            }
            return View(materials);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edititem   (int id, Materials materials)
        {
            if (id != materials.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var data= await _context.materials.SingleOrDefaultAsync(x=>x.Id== id);
                    data.priceForbuy = materials.priceForbuy;
                    data.priceForHome = materials.priceForHome;
                    data.priceForPs = materials.priceForPs;
                    data.Quantity = materials.Quantity;
                    data.minQuantity = materials.minQuantity;
                    data.Name = materials.Name;
                    data.Storage = materials.Storage;
                    data.Quantityinstorage += materials.Quantityinstorage;
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialsExists(materials.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materials);
        }





        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var materials = await _context.materials.FindAsync(id);
            if (materials != null)
            {
               
                _context.materials.Remove(materials);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialsExists(int id)
        {
            return _context.materials.Any(e => e.Id == id);
        }
    }
}
