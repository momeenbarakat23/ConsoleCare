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
    public class Other_expensesController : Controller
    {
        private readonly Appdbcontext _context;

        public Other_expensesController(Appdbcontext context)
        {
            _context = context;
        }

        // GET: Other_expenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Other_expenses.ToListAsync());
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Other_expenses other_expenses)
        {
            if (ModelState.IsValid)
            {
                var cash = new Cash();
                cash.AccountName = other_expenses.typeofcash;
                cash.Outgoing=other_expenses.ExpenseValue;
                cash.MoneyOut=other_expenses.DisbursementName;
                cash.Date = other_expenses.DateTime;
                cash.Statement = other_expenses.Note;
                cash.TotalAmount= -other_expenses.ExpenseValue;
                _context.Cash.Add(cash);
                _context.Add(other_expenses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(other_expenses);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var other_expenses = await _context.Other_expenses.FindAsync(id);
            if (other_expenses == null)
            {
                return NotFound();
            }
            return View(other_expenses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Other_expenses other_expenses)
        {
            if (id != other_expenses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var cash = await _context.Cash.FirstOrDefaultAsync(x => x.Date==other_expenses.DateTime&& x.MoneyOut == other_expenses.DisbursementName);
                    cash.AccountName = other_expenses.typeofcash;
                    cash.Outgoing = other_expenses.ExpenseValue;
                    cash.MoneyOut = other_expenses.DisbursementName;
                    cash.Date = other_expenses.DateTime;
                    cash.Statement = other_expenses.Note;
                    cash.TotalAmount = -other_expenses.ExpenseValue;
                    _context.Cash.Update(cash);
                    _context.Update(other_expenses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Other_expensesExists(other_expenses.Id))
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
            return View(other_expenses);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var other_expenses = await _context.Other_expenses.FindAsync(id);
            if (other_expenses != null)
            {
                var cash = await _context.Cash.FirstOrDefaultAsync(x => x.Date == other_expenses.DateTime && x.MoneyOut == other_expenses.DisbursementName);
                if (cash != null)
                {
                    _context.Cash.Remove(cash);
                }
            
                _context.Other_expenses.Remove(other_expenses);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Other_expensesExists(int id)
        {
            return _context.Other_expenses.Any(e => e.Id == id);
        }
    }
}
