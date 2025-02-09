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
    public class Purchase_PaymentsController : Controller
    {
        private readonly Appdbcontext _context;

        public Purchase_PaymentsController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: Purchase_Payments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Purchase_Payments.ToListAsync());
        }


        // GET: Purchase_Payments/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Purchase_Payments purchase_Payments)
        {
            if (ModelState.IsValid)
            {
                purchase_Payments.remaining = purchase_Payments.InvoiceValue - purchase_Payments.PaidValue;
                var cash = new Cash();
                cash.AccountName = purchase_Payments.typeofcash;
                cash.Outgoing = purchase_Payments.PaidValue;
                cash.MoneyOut = purchase_Payments.SupplierName;
                cash.Date = purchase_Payments.DateTime;
                cash.Statement = purchase_Payments.Note;
                cash.TotalAmount = -purchase_Payments.PaidValue;
                _context.Cash.Add(cash);
                _context.Add(purchase_Payments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchase_Payments);
        }

        // GET: Purchase_Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase_Payments = await _context.Purchase_Payments.FindAsync(id);
            if (purchase_Payments == null)
            {
                return NotFound();
            }
            return View(purchase_Payments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Purchase_Payments purchase_Payments)
        {
            if (id != purchase_Payments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    purchase_Payments.remaining = purchase_Payments.InvoiceValue - purchase_Payments.PaidValue;
                    var cash = await _context.Cash.FirstOrDefaultAsync(x => x.Date == purchase_Payments.DateTime && x.MoneyOut == purchase_Payments.SupplierName);
                    cash.AccountName = purchase_Payments.typeofcash;
                    cash.Outgoing = purchase_Payments.PaidValue;
                    cash.MoneyOut = purchase_Payments.SupplierName;
                    cash.Date = purchase_Payments.DateTime;
                    cash.Statement = purchase_Payments.Note;
                    cash.TotalAmount = -purchase_Payments.PaidValue;
                    _context.Cash.Update(cash);
                    _context.Update(purchase_Payments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Purchase_PaymentsExists(purchase_Payments.Id))
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
            return View(purchase_Payments);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchase_Payments = await _context.Purchase_Payments.FindAsync(id);
            if (purchase_Payments != null)
            {
                _context.Purchase_Payments.Remove(purchase_Payments);
            }
            var cash = await _context.Cash.FirstOrDefaultAsync(x => x.Date == purchase_Payments.DateTime && x.MoneyOut == purchase_Payments.SupplierName);
            if (cash != null)
            {
                _context.Cash.Remove(cash);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Purchase_PaymentsExists(int id)
        {
            return _context.Purchase_Payments.Any(e => e.Id == id);
        }
    }
}
