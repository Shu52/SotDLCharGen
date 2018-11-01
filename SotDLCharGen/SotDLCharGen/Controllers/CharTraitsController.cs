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
    public class CharTraitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CharTraitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CharTraits
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CharTrait.Include(c => c.Character).Include(c => c.Trait);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CharTraits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charTrait = await _context.CharTrait
                .Include(c => c.Character)
                .Include(c => c.Trait)
                .FirstOrDefaultAsync(m => m.CharTraitId == id);
            if (charTrait == null)
            {
                return NotFound();
            }

            return View(charTrait);
        }

        // GET: CharTraits/Create
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "CharacterId", "CharacterName");
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId");
            return View();
        }

        // POST: CharTraits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharcTraitId,CharTraitValue,CharacterId,TraitId")] CharTrait charTrait)
        {
            if (ModelState.IsValid)
            {
                _context.Add(charTrait);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "CharacterId", "CharacterName", charTrait.CharacterId);
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId", charTrait.TraitId);
            return View(charTrait);
        }

        // GET: CharTraits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charTrait = await _context.CharTrait.FindAsync(id);
            if (charTrait == null)
            {
                return NotFound();
            }
            ViewData["CharacterId"] = new SelectList(_context.Characters, "CharacterId", "CharacterName", charTrait.CharacterId);
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId", charTrait.TraitId);
            return View(charTrait);
        }

        // POST: CharTraits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharcTraitId,CharTraitValue,CharacterId,TraitId")] CharTrait charTrait)
        {
            if (id != charTrait.CharTraitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charTrait);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharTraitExists(charTrait.CharTraitId))
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
            ViewData["CharacterId"] = new SelectList(_context.Characters, "CharacterId", "CharacterName", charTrait.CharacterId);
            ViewData["TraitId"] = new SelectList(_context.Trait, "TraitId", "TraitId", charTrait.TraitId);
            return View(charTrait);
        }

        // GET: CharTraits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charTrait = await _context.CharTrait
                .Include(c => c.Character)
                .Include(c => c.Trait)
                .FirstOrDefaultAsync(m => m.CharTraitId == id);
            if (charTrait == null)
            {
                return NotFound();
            }

            return View(charTrait);
        }

        // POST: CharTraits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charTrait = await _context.CharTrait.FindAsync(id);
            _context.CharTrait.Remove(charTrait);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharTraitExists(int id)
        {
            return _context.CharTrait.Any(e => e.CharTraitId == id);
        }
    }
}
