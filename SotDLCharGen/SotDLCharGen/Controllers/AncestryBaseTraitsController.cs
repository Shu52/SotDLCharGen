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
    public class AncestryBaseTraitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AncestryBaseTraitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AncestryBaseTraits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AncestryBaseTraits.Include(a => a.Ancestry).Include(a => a.Trait);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AncestryBaseTraits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ancestryBaseTrait = await _context.AncestryBaseTraits
                .Include(a => a.Ancestry)
                .Include(a => a.Trait)
                .FirstOrDefaultAsync(m => m.AncestryBaseTraitId == id);
            if (ancestryBaseTrait == null)
            {
                return NotFound();
            }

            return View(ancestryBaseTrait);
        }

        // GET: AncestryBaseTraits/Create
        public IActionResult Create()
        {
            ViewData["AncestryId"] = new SelectList(_context.Ancestry, "AncestryId", "AncestryId");
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId");
            return View();
        }

        // POST: AncestryBaseTraits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AncestryBaseTraitId,BaseValue,AncestryId,TraitId")] AncestryBaseTrait ancestryBaseTrait)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ancestryBaseTrait);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AncestryId"] = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", ancestryBaseTrait.AncestryId);
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId", ancestryBaseTrait.TraitId);
            return View(ancestryBaseTrait);
        }

        // GET: AncestryBaseTraits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ancestryBaseTrait = await _context.AncestryBaseTraits.FindAsync(id);
            if (ancestryBaseTrait == null)
            {
                return NotFound();
            }
            ViewData["AncestryId"] = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", ancestryBaseTrait.AncestryId);
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId", ancestryBaseTrait.TraitId);
            return View(ancestryBaseTrait);
        }

        // POST: AncestryBaseTraits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AncestryBaseTraitId,BaseValue,AncestryId,TraitId")] AncestryBaseTrait ancestryBaseTrait)
        {
            if (id != ancestryBaseTrait.AncestryBaseTraitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ancestryBaseTrait);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AncestryBaseTraitExists(ancestryBaseTrait.AncestryBaseTraitId))
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
            ViewData["AncestryId"] = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", ancestryBaseTrait.AncestryId);
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId", ancestryBaseTrait.TraitId);
            return View(ancestryBaseTrait);
        }

        // GET: AncestryBaseTraits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ancestryBaseTrait = await _context.AncestryBaseTraits
                .Include(a => a.Ancestry)
                .Include(a => a.Trait)
                .FirstOrDefaultAsync(m => m.AncestryBaseTraitId == id);
            if (ancestryBaseTrait == null)
            {
                return NotFound();
            }

            return View(ancestryBaseTrait);
        }

        // POST: AncestryBaseTraits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ancestryBaseTrait = await _context.AncestryBaseTraits.FindAsync(id);
            _context.AncestryBaseTraits.Remove(ancestryBaseTrait);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AncestryBaseTraitExists(int id)
        {
            return _context.AncestryBaseTraits.Any(e => e.AncestryBaseTraitId == id);
        }
    }
}
