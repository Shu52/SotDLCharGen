using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Data;
using SotDLCharGen.Models;
using SotDLCharGen.ViewModels;

namespace SotDLCharGen.Controllers
{
    public class ApplicationUserController : Controller
    {
        private ApplicationDbContext _context;

        public UserManager<ApplicationUser> _userManager { get; }

        public ApplicationUserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            {
                _context = context;
                _userManager = userManager;
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize]
        public async Task<IActionResult> UserHome()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            ApplicationUserViewModel model = new ApplicationUserViewModel(_context);

            model.Characters = await _context.Characters.Where(character => character.ApplicationUserId == user.Id).ToListAsync();
            return View(model);
        }
        // GET: ApplicationUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: ApplicationUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationUser/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}