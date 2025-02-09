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
    public class BuyingMaterialsController : Controller
    {
        private readonly Appdbcontext _context;
        

        public BuyingMaterialsController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: BuyingMaterials
        public async Task<IActionResult> Index()
        {
            return View(await _context.BuyingMaterials.ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.name=await _context.materials.Select(x => x.Name).ToListAsync();
            return View();
        }

        // POST: BuyingMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BuyingMaterials buyingMaterials)
        {
            if (ModelState.IsValid)
            {
                var mat = await _context.materials.FirstOrDefaultAsync(x => x.Name == buyingMaterials.NameOfMaterials);
                mat.Quantity += buyingMaterials.NoPiece;
                mat.Quantityinstorage += buyingMaterials.NoPiece;
                mat.priceForbuy= (int)buyingMaterials.PriceofPiece;
                _context.materials.Update(mat);

                if (buyingMaterials.TotalPrice==null)
                {
                    buyingMaterials.TotalPrice = buyingMaterials.NoPiece * buyingMaterials.PriceofPiece;
                }

                if (buyingMaterials.typeofcash != null)
                {
                    var cash = new Cash();
                    cash.AccountName = buyingMaterials.typeofcash;
                    cash.Outgoing = (decimal)buyingMaterials.TotalPrice;
                    cash.Date = buyingMaterials.DateTime;
                    cash.TotalAmount = -buyingMaterials.TotalPrice;
                    cash.MoneyOut = buyingMaterials.NameOfMaterials;
                    cash.Nameoftech = buyingMaterials.NameOfBuyer;
                    cash.Statement = buyingMaterials.Note;
                    _context.Cash.Add(cash);

                }

                _context.Add(buyingMaterials);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyingMaterials);
        }

        // GET: BuyingMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.name = await _context.materials.Select(x => x.Name).ToListAsync();
            var oldData = await _context.BuyingMaterials.SingleOrDefaultAsync(x => x.id == id);
            TempData["Nopiece"] = oldData.NoPiece;

            if (id == null)
            {
                return NotFound();
            }

            var buyingMaterials = await _context.BuyingMaterials.FindAsync(id);
            if (buyingMaterials == null)
            {
                return NotFound();
            }
            return View(buyingMaterials);
        }

        // POST: BuyingMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  BuyingMaterials buyingMaterials)
        {
            if (id != buyingMaterials.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    int oldData = 0;
                    if (buyingMaterials.TotalPrice == null)
                    {
                        buyingMaterials.TotalPrice = buyingMaterials.NoPiece * buyingMaterials.PriceofPiece;
                    }

                    if (buyingMaterials.typeofcash != null)
                    {
                        var cash = await _context.Cash.FirstOrDefaultAsync(x => x.Date == buyingMaterials.DateTime);
                        cash.AccountName = buyingMaterials.typeofcash;
                        cash.Outgoing = (decimal)buyingMaterials.TotalPrice;
                        cash.TotalAmount = -buyingMaterials.TotalPrice; 
                        cash.Date = buyingMaterials.DateTime;
                        cash.MoneyOut = buyingMaterials.NameOfMaterials;
                        cash.Nameoftech=buyingMaterials.NameOfBuyer;
                        cash.Statement = buyingMaterials.Note;
                        _context.Cash.Update(cash);

                    }
                    var mat = await _context.materials.FirstOrDefaultAsync(x => x.Name == buyingMaterials.NameOfMaterials);
                    oldData = (int)TempData["Nopiece"];
                    mat.priceForbuy = (int)buyingMaterials.PriceofPiece;
                    if (oldData>buyingMaterials.NoPiece)
                    {
                        var result = oldData-buyingMaterials.NoPiece;
                        mat.Quantity -= result;
                        mat.Quantityinstorage -= result;
                    }
                    else
                    {
                        var result = buyingMaterials.NoPiece - oldData;
                        mat.Quantity += result;
                        mat.Quantityinstorage += result;
                    }
                    _context.materials.Update(mat);
                    _context.BuyingMaterials.Update(buyingMaterials);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuyingMaterialsExists(buyingMaterials.id))
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
            return View(buyingMaterials);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.BuyingMaterials.SingleOrDefaultAsync(x => x.id == id);
            var cash = await _context.Cash.FirstOrDefaultAsync(x=>x.Date==result.DateTime && x.MoneyOut==result.NameOfMaterials);
            var mat = await _context.materials.FirstOrDefaultAsync(x => x.Name == result.NameOfMaterials);
            mat.Quantity -= result.NoPiece;
            mat.Quantityinstorage -= result.NoPiece;
            _context.materials.Update(mat);
            if (cash != null)
            {
                _context.Cash.Remove(cash);
            }
            _context.BuyingMaterials.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuyingMaterialsExists(int id)
        {
            return _context.BuyingMaterials.Any(e => e.id == id);
        }
    }
}
