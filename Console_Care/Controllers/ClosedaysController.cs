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
    public class ClosedaysController : Controller
    {
        private readonly Appdbcontext _context;

        public ClosedaysController(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Closeday.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Origins,Cash,Sales,PaidSales,Remainingsales,Procurement,PaidPurchases,Remainingpurchases,Expenses")] Closeday closeday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(closeday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(closeday);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closeday = await _context.Closeday.FindAsync(id);
            if (closeday == null)
            {
                return NotFound();
            }
            return View(closeday);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Origins,Cash,Sales,PaidSales,Remainingsales,Procurement,PaidPurchases,Remainingpurchases,Expenses")] Closeday closeday)
        {
            if (id != closeday.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(closeday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClosedayExists(closeday.Id))
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
            return View(closeday);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var closeday = await _context.Closeday.FindAsync(id);
            if (closeday != null)
            {
                _context.Closeday.Remove(closeday);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClosedayExists(int id)
        {
            return _context.Closeday.Any(e => e.Id == id);
        }
    }
}
