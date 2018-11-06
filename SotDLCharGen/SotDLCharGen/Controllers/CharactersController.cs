using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Data;
using SotDLCharGen.Models;
using SotDLCharGen.ViewModels;

namespace SotDLCharGen.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManager<ApplicationUser> _userManager { get; }

        public CharactersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            {
                _context = context;
                _userManager = userManager;
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Characters.Include(c => c.Ancestry).Include(c => c.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HumanDetailsViewModel character = new HumanDetailsViewModel(_context);

             character.Character = await _context.Characters
                .Include(c => c.Ancestry)
                .Include(c => c.ApplicationUser)
                .Include(c => c.CharTraits)
                .ThenInclude(chartraits => chartraits.Trait)
                .FirstOrDefaultAsync(m => m.CharacterId == id);

            var stringVal = character.Character.CharTraits.ElementAt(0).CharTraitValue;

            int healingRate()
            {
                double numVal = Int32.Parse(stringVal);
                double longVal = Math.Floor(numVal / 4);
                int returnVal = Convert.ToInt32(longVal);
                return returnVal;
            }

            character.healingRate = healingRate();
            
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            CharacterCreateViewModel model = new CharacterCreateViewModel(_context);


            return View(model);
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterId,CharacterName,Gender,Level,ApplicationUserId,AncestryId")] Character character)
        {

            if (ModelState.IsValid)

            {
            //get current user and set user property on character to user
            ApplicationUser user = await GetCurrentUserAsync();

            CharacterCreateViewModel model = new CharacterCreateViewModel(_context);
            model.AncestriesList = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", character.AncestryId);

            model.Character = character;
            
                //if user selects human
            character.ApplicationUserId = user.Id;


                //if user selects non-human
                _context.Add(character);
                await _context.SaveChangesAsync();
                if (model.Character.AncestryId == 1)
                {
                    
                    
                    return RedirectToAction("HumanAbilitiesForm","HumanAbilities");
                }
                return RedirectToAction("UserHome","ApplicationUser");
            }
            //ask Emily about this tomorrow

            return View(character);
        }

        

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HumanEditViewModel viewModel = new HumanEditViewModel();
            ApplicationUser user = await GetCurrentUserAsync();

             viewModel.Character = await _context.Characters
                            .Where(c => c.CharacterId == id)
                            .FirstAsync(c => c.ApplicationUserId == user.Id);

            

            if (viewModel.Character == null)
            {
                return NotFound();
            }
            //need to change this for edit, get current user for id. See userhome for reference
            //HumanEditViewModel model = new HumanEditViewModel(_context);
            //model.AncestriesList = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", character.AncestryId);

            //ApplicationUser user = await GetCurrentUserAsync();
            //character.ApplicationUserId = user.Id;

            //var ancestryId = _context.Ancestry
            //    .Where(ancestry => ancestry.AncestryId == character.AncestryId).Single();
            //character.AncestryId = ancestryId.AncestryId;

            //character.AncestryId = _context.Ancestry
            //    .Where(ancestry => ancestry.AncestryId == character.AncestryId).Single();

            //ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", character.ApplicationUserId);
            return View(viewModel);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId,CharacterName,Gender,Level,ApplicationUserId, AncestryId")] Character character)
        {
            //var ancestryId = _context.Ancestry
            //    .Where(ancestry => ancestry.AncestryId == character.AncestryId).Single();
            //character.AncestryId = ancestryId.AncestryId;

            ApplicationUser user = await GetCurrentUserAsync();
            character.ApplicationUserId = user.Id;

            if (id != character.CharacterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.CharacterId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("UserHome", "ApplicationUser");
            }
            //need to change this for edit, get current user for id. See userhome for reference
            //ViewData["AncestryId"] = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", character.AncestryId);

/*            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", character.ApplicationUserId)*/;
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .Include(c => c.Ancestry)
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction("UserHome", "ApplicationUser");
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
