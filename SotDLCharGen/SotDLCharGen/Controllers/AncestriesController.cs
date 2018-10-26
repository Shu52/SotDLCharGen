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
    public class AncestriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AncestriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ancestries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ancestry.ToListAsync());
        }

        // GET: Ancestries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ancestry = await _context.Ancestry
                .FirstOrDefaultAsync(m => m.AncestryId == id);
            if (ancestry == null)
            {
                return NotFound();
            }

            return View(ancestry);
        }

        // GET: Ancestries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ancestries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AncestryId,AncestryName")] Ancestry ancestry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ancestry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ancestry);
        }

        // GET: Ancestries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ancestry = await _context.Ancestry.FindAsync(id);
            if (ancestry == null)
            {
                return NotFound();
            }
            return View(ancestry);
        }

        // POST: Ancestries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AncestryId,AncestryName")] Ancestry ancestry)
        {
            if (id != ancestry.AncestryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ancestry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AncestryExists(ancestry.AncestryId))
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
            return View(ancestry);
        }

        // GET: Ancestries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ancestry = await _context.Ancestry
                .FirstOrDefaultAsync(m => m.AncestryId == id);
            if (ancestry == null)
            {
                return NotFound();
            }

            return View(ancestry);
        }

        // POST: Ancestries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ancestry = await _context.Ancestry.FindAsync(id);
            _context.Ancestry.Remove(ancestry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AncestryExists(int id)
        {
            return _context.Ancestry.Any(e => e.AncestryId == id);
        }
    }
}
