﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Data;
using SotDLCharGen.Models;
using SotDLCharGen.ViewModels;

namespace SotDLCharGen.Controllers
{
    public class ClockworkPurposesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClockworkPurposesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClockworkPurposes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClockworkPurposes.ToListAsync());
        }

        // GET: ClockworkPurposes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clockworkPurpose = await _context.ClockworkPurposes
                .FirstOrDefaultAsync(m => m.ClockworkPurposeId == id);
            if (clockworkPurpose == null)
            {
                return NotFound();
            }

            return View(clockworkPurpose);
        }

        // GET: ClockworkPurposes/Create
        public IActionResult Create()
        {
;
            ClockworkPurposeViewModel model = new ClockworkPurposeViewModel(_context);
            return View(model);
        }

        // POST: ClockworkPurposes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EnableCors("ShadowPolicy")]
        public async Task<IActionResult> Create([FromBody] ClockworkPurposeViewModel IdandAttr)
        {
          
            Console.WriteLine("In controller");
            if (ModelState.IsValid)
            {
                //_context.Add(clockworkPurpose);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("UserHome", "ApplicationUser");
            }
            return RedirectToAction("UserHome", "ApplicationUser");
        }

        // GET: ClockworkPurposes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clockworkPurpose = await _context.ClockworkPurposes.FindAsync(id);
            if (clockworkPurpose == null)
            {
                return NotFound();
            }
            return View(clockworkPurpose);
        }

        // POST: ClockworkPurposes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClockworkPurposeId,ClockworkPurposeValue")] ClockworkPurpose clockworkPurpose)
        {
            if (id != clockworkPurpose.ClockworkPurposeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clockworkPurpose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClockworkPurposeExists(clockworkPurpose.ClockworkPurposeId))
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
            return View(clockworkPurpose);
        }

        // GET: ClockworkPurposes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clockworkPurpose = await _context.ClockworkPurposes
                .FirstOrDefaultAsync(m => m.ClockworkPurposeId == id);
            if (clockworkPurpose == null)
            {
                return NotFound();
            }

            return View(clockworkPurpose);
        }

        // POST: ClockworkPurposes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clockworkPurpose = await _context.ClockworkPurposes.FindAsync(id);
            _context.ClockworkPurposes.Remove(clockworkPurpose);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClockworkPurposeExists(int id)
        {
            return _context.ClockworkPurposes.Any(e => e.ClockworkPurposeId == id);
        }
    }
}
