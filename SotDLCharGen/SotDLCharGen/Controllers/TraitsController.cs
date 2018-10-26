using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Data;
using SotDLCharGen.Models;

namespace SotDLCharGen.Controllers
{
    public class TraitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TraitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Traits
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trait.ToListAsync());
        }

        // GET: Traits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trait = await _context.Trait
                .FirstOrDefaultAsync(m => m.TraitId == id);
            if (trait == null)
            {
                return NotFound();
            }

            return View(trait);
        }

        // GET: Traits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Traits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraitId,TraitName")] Trait trait)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trait);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trait);
        }

        // GET: Traits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trait = await _context.Trait.FindAsync(id);
            if (trait == null)
            {
                return NotFound();
            }
            return View(trait);
        }

        // POST: Traits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraitId,TraitName")] Trait trait)
        {
            if (id != trait.TraitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trait);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraitExists(trait.TraitId))
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
            return View(trait);
        }

        // GET: Traits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trait = await _context.Trait
                .FirstOrDefaultAsync(m => m.TraitId == id);
            if (trait == null)
            {
                return NotFound();
            }

            return View(trait);
        }

        // POST: Traits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trait = await _context.Trait.FindAsync(id);
            _context.Trait.Remove(trait);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraitExists(int id)
        {
            return _context.Trait.Any(e => e.TraitId == id);
        }
    }
}
