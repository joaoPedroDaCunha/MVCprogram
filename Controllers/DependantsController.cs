using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programa.Data;
using Project.Models;

namespace Programa.Controllers
{
    public class DependantsController : Controller
    {
        private readonly ConnectionContext _context;

        public DependantsController(ConnectionContext context)
        {
            _context = context;
        }

        // GET: Dependants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dependants.ToListAsync());
        }

        // GET: Dependants/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependants = await _context.Dependants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dependants == null)
            {
                return NotFound();
            }

            return View(dependants);
        }

        // GET: Dependants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dependants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Parentage,ID")] Dependants dependants)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependants);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dependants);
        }

        // GET: Dependants/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependants = await _context.Dependants.FindAsync(id);
            if (dependants == null)
            {
                return NotFound();
            }
            return View(dependants);
        }

        // POST: Dependants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Parentage,ID")] Dependants dependants)
        {
            if (id != dependants.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dependants);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DependantsExists(dependants.ID))
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
            return View(dependants);
        }

        // GET: Dependants/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependants = await _context.Dependants
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dependants == null)
            {
                return NotFound();
            }

            return View(dependants);
        }

        // POST: Dependants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dependants = await _context.Dependants.FindAsync(id);
            if (dependants != null)
            {
                _context.Dependants.Remove(dependants);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DependantsExists(string id)
        {
            return _context.Dependants.Any(e => e.ID == id);
        }
    }
}
