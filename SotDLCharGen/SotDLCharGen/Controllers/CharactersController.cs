using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            character.ApplicationUserId = user.Id;

                //if user selects human
                if (character.AncestryId == 1)
                {
                    //keep current character in context to use in CharTrait Table
                    _context.Add(character);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(HumanAbilities));
                }

                //if user selects non-human
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction("UserHome","ApplicationUser");
            }
            //ask Emily about this tomorrow
            CharacterCreateViewModel model = new CharacterCreateViewModel(_context);
            model.AncestriesList = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", character.AncestryId);

            model.Character = character;
            
            return View(character);
        }

        //don't know if i need to bind anything
        public IActionResult HumanAbilities()
        {

            CharTraitHumanViewModel model = new CharTraitHumanViewModel(_context);

            var characters = _context.Characters.Last();

            CharTrait humanTraitStrength = new CharTrait
            {
                CharTraitId = 1,
                CharacterId = characters.CharacterId,
                TraitId = 1,
                CharTraitValue = "10"
            };

            CharTrait humanTraitAgility = new CharTrait
            {
                CharTraitId = 2,
                CharacterId = characters.CharacterId,
                TraitId = 2,
                CharTraitValue = "10"
            };

            CharTrait humanTraitIntellect = new CharTrait
            {
                CharTraitId = 3,
                CharacterId = characters.CharacterId,
                TraitId = 3,
                CharTraitValue = "10"
            };

            CharTrait humanTraitWill = new CharTrait
            {
                CharTraitId = 4,
                CharacterId = characters.CharacterId,
                TraitId = 4,
                CharTraitValue = "10"
            };


            //foreach (id in trait && id.value < 5 )
            //{
            // new chartrait
            //where characterId= CharacterId,
            //TraitId = id.value,
            // CharTraitValue = "10"
            // }

            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("UserHome", "ApplicationUser");
            //}
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("UserHome", "ApplicationUser");
            //}


            //chartrait.CharacterId = ModelState.Root.Children.CharacterId;

            //CharTraitHumanViewModel model = new CharTraitHumanViewModel();

            //var character = await _context.Characters
            //   .Include(c => c.Ancestry)
            //   .Include(c => c.ApplicationUser)
            //   .FirstOrDefaultAsync(m => m.CharacterId == id);

            //var model = await _context.CharTrait
            //   .Include(c => c.Trait)
            //   .ToListAsync();

            //CharTraitHumanViewModel model = new CharTraitHumanViewModel(_context);


            return View();
        }
        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["AncestryId"] = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", character.AncestryId);
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", character.ApplicationUserId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId,CharacterName,Gender,Level,ApplicationUserId,AncestryId")] Character character)
        {
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["AncestryId"] = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", character.AncestryId);
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", character.ApplicationUserId);
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
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
