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
                    //keep current character in context to use in CharTrait Table
                    
                    return RedirectToAction(nameof(HumanAbilities));
                }
                return RedirectToAction("UserHome","ApplicationUser");
            }
            //ask Emily about this tomorrow

            return View(character);
        }

        //don't know if i need to bind anything
        public IActionResult HumanAbilities()
        {

            //List<AncestryBaseTrait> ancestryModel = new List<AncestryBaseTrait>();
            HumanAbilitiesViewModel ancestryModel = new HumanAbilitiesViewModel();

            var ancestryBaseTraits = from ab in _context.AncestryBaseTraits
                                 join t in _context.Trait on ab.TraitId equals t.TraitId
                                 join a in _context.Ancestry on ab.AncestryId equals a.AncestryId
                                 where ab.AncestryId == a.AncestryId && a.AncestryName == "Human"
                                 select ab;

            ancestryModel.Equals(ancestryBaseTraits);

            //ancestryModel = _context.AncestryBaseTraits
            //    .Include(a => a.TraitId)
            //    .Include(a => a.AncestryId)
            //    .Where(a => a.AncestryId == a.Ancestry.AncestryId && a.Ancestry.AncestryName.Contains("Human")).SelectMany(AncestryBaseTrait => AncestryBaseTrait.BaseValue)
            //    .ToList();


            var characters = _context.Characters.Last();
            //var charTrait = _context.CharTrait.Last();

            CharTrait humanTraitStrength = new CharTrait
            {
                //CharTraitId = charTrait.CharTraitId,
                CharacterId = characters.CharacterId,
                TraitId = 1,
                CharTraitValue = "10"
            };
            //model.Add(new CharTrait()
            //{
            //    CharacterId = characters.CharacterId,
            //    TraitId = 1,
            //    CharTraitValue = "10"
            //});
            //model.Add(humanTraitStrength)

            CharTrait humanTraitAgility = new CharTrait
            {
                //CharTraitId = charTrait.CharTraitId,
                CharacterId = characters.CharacterId,
                TraitId = 2,
                CharTraitValue = "10"
            };

            CharTrait humanTraitIntellect = new CharTrait
            {
                //CharTraitId = charTrait.CharTraitId,
                CharacterId = characters.CharacterId,
                TraitId = 3,
                CharTraitValue = "10"
            };

            CharTrait humanTraitWill = new CharTrait
            {
                //CharTraitId = charTrait.CharTraitId,
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


            return View(ancestryModel);
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
            //need to change this for edit, get current user for id. See userhome for referenc
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
                return RedirectToAction("UserHome", "ApplicationUser");
            } 
            //need to change this for edit, get current user for id. See userhome for reference
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
            return RedirectToAction("UserHome", "ApplicationUser");
        }

        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.CharacterId == id);
        }
    }
}
