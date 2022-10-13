using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using NToastNotify;

namespace WebApplication2.Controllers
{
    public class Test1Controller : Controller
    {
        private readonly ILogger<Test1Controller> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly TestContext _context;

        public Test1Controller(ILogger<Test1Controller> logger, IToastNotification toastNotification, TestContext context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: Test1
        public async Task<IActionResult> Index()
        {
              return View(await _context.Test1s.ToListAsync());
        }

        // GET: Test1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Test1s == null)
            {
                return NotFound();
            }

            var test1 = await _context.Test1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test1 == null)
            {
                return NotFound();
            }

            return View(test1);
        }

        // GET: Test1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Test1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fname,Lname")] Test1 test1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test1);
                await _context.SaveChangesAsync();
                _toastNotification.AddSuccessToastMessage("Deatils created successfully!!");
                return RedirectToAction(nameof(Index));
            }
            return View(test1);
        }

        // GET: Test1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Test1s == null)
            {
                return NotFound();
            }

            var test1 = await _context.Test1s.FindAsync(id);
            if (test1 == null)
            {
                return NotFound();
            }
            return View(test1);
        }

        // POST: Test1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fname,Lname")] Test1 test1)
        {
            if (id != test1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(test1);
                    await _context.SaveChangesAsync();
                    _toastNotification.AddWarningToastMessage("Details updated successfully!!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Test1Exists(test1.Id))
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
            return View(test1);
        }

        // GET: Test1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Test1s == null)
            {
                return NotFound();
            }

            var test1 = await _context.Test1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (test1 == null)
            {
                return NotFound();
            }

            return View(test1);
        }

        // POST: Test1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Test1s == null)
            {
                return Problem("Entity set 'TestContext.Test1s'  is null.");
            }
            var test1 = await _context.Test1s.FindAsync(id);
            if (test1 != null)
            {
                _context.Test1s.Remove(test1);
            }
            
            await _context.SaveChangesAsync();
            _toastNotification.AddErrorToastMessage("Deatils deleted successfully!!");
            return RedirectToAction(nameof(Index));
        }

        private bool Test1Exists(int id)
        {
          return _context.Test1s.Any(e => e.Id == id);
        }
    }
}