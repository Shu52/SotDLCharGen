using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        //connection to database
        private readonly ApplicationDbContext _context;

        //connection to user
        public UserManager<ApplicationUser> _userManager { get; }

        public CharactersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            {
                _context = context;
                _userManager = userManager;
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);



        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //connect view model
            HumanDetailsViewModel character = new HumanDetailsViewModel(_context);

             character.Character = await _context.Characters
                .Include(c => c.Ancestry)
                .Include(c => c.ApplicationUser)
                .Include(c => c.CharTraits)
                    .ThenInclude(chartraits => chartraits.Trait)
                .FirstOrDefaultAsync(m => m.CharacterId == id);

            //strength
            var stringVal = character.Character.CharTraits.ElementAt(0).CharTraitValue;

            double numVal = Int32.Parse(stringVal);
                //dwarves start with + 4 to health
                if (character.Character.AncestryId == 4)
                {
                    numVal += 4;
                }
            character.hitpoints = Convert.ToInt32(numVal);
            //calculate healing rate
            int healingRate()
            {
                double longVal = Math.Floor(numVal / 4);
                int returnVal = Convert.ToInt32(longVal);
                return returnVal;
            }

            //assign healing rate value
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
        [ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Create([Bind("CharacterId,CharacterName,Gender,Level,ApplicationUserId,AncestryId")] Character character)
        {

            if (ModelState.IsValid)

            {
                //get current user and set user property on character to user
                ApplicationUser user = await GetCurrentUserAsync();
                character.ApplicationUserId = user.Id;

                //connection to veiw model
                CharacterCreateViewModel model = new CharacterCreateViewModel(_context);

                //make dropdown and assign to property on viewmodel
                model.AncestriesList = new SelectList(_context.Ancestry, "AncestryId", "AncestryId", character.AncestryId);

                //assign to property character on model
                model.Character = character;

                //if user selects non-human
                _context.Add(character);
                await _context.SaveChangesAsync();

                //if User select Human
                if (model.Character.AncestryId == 1)
                {
                    return RedirectToAction("HumanAbilitiesForm", "HumanAbilities");
                }

                else if (model.Character.AncestryId == 2)
                {
                    var abt = (from ab in _context.AncestryBaseTraits
                              join a in _context.Ancestry on ab.AncestryId equals a.AncestryId
                              where ab.AncestryId == 2
                              select ab.BaseValue)
                              .ToList();

                    CharTrait changelingTraitStrength = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 1,
                        CharTraitValue = abt.ElementAt(0).ToString()

                    };

                    //add to hold in db context
                    _context.Add(changelingTraitStrength);

                    CharTrait changelingTraitAgility = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 2,
                        CharTraitValue = abt.ElementAt(1).ToString()
                    };

                    //add to hold in db context
                    _context.Add(changelingTraitAgility);

                    CharTrait changelingTraitIntellect = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 3,
                        CharTraitValue = abt.ElementAt(2).ToString()
                    };

                    //add to hold in db context
                    _context.Add(changelingTraitIntellect);

                    CharTrait changelingTraitWill = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 4,
                        CharTraitValue = abt.ElementAt(3).ToString()
                    };

                    //add to hold in db context and save context to db
                    _context.Add(changelingTraitWill);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("UserHome", "ApplicationUser");
                }
                //begin clockwork
                if (model.Character.AncestryId == 3)
                {
                    var abt = (from ab in _context.AncestryBaseTraits
                               join a in _context.Ancestry on ab.AncestryId equals a.AncestryId
                               where ab.AncestryId == 3
                               select ab.BaseValue)
                              .ToList();

                    CharTrait clockworkTraitStrength = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 1,
                        CharTraitValue = abt.ElementAt(0).ToString()

                    };

                    //add to hold in db context
                    _context.Add(clockworkTraitStrength);

                    CharTrait clockworkTraitAgility = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 2,
                        CharTraitValue = abt.ElementAt(1).ToString()
                    };

                    //add to hold in db context
                    _context.Add(clockworkTraitAgility);

                    CharTrait clockworkTraitIntellect = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 3,
                        CharTraitValue = abt.ElementAt(2).ToString()
                    };

                    //add to hold in db context
                    _context.Add(clockworkTraitIntellect);

                    CharTrait clockworkTraitWill = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 4,
                        CharTraitValue = abt.ElementAt(3).ToString()
                    };

                    //add to hold in db context and save context to db
                    _context.Add(clockworkTraitWill);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Create", "ClockworkPurposes");
                }
                //end clockwork
                //begin dwarf
                if (model.Character.AncestryId == 4)
                {
                    var abt = (from ab in _context.AncestryBaseTraits
                               join a in _context.Ancestry on ab.AncestryId equals a.AncestryId
                               where ab.AncestryId == 4
                               select ab.BaseValue)
                              .ToList();

                    CharTrait dwarfTraitStrength = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 1,
                        CharTraitValue = abt.ElementAt(0).ToString()

                    };

                    //add to hold in db context
                    _context.Add(dwarfTraitStrength);

                    CharTrait dwarfTraitAgility = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 2,
                        CharTraitValue = abt.ElementAt(1).ToString()
                    };

                    //add to hold in db context
                    _context.Add(dwarfTraitAgility);

                    CharTrait dwarfTraitIntellect = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 3,
                        CharTraitValue = abt.ElementAt(2).ToString()
                    };

                    //add to hold in db context
                    _context.Add(dwarfTraitIntellect);

                    CharTrait dwarfTraitWill = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 4,
                        CharTraitValue = abt.ElementAt(3).ToString()
                    };

                    //add to hold in db context and save context to db
                    _context.Add(dwarfTraitWill);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("UserHome", "ApplicationUser");
                }
                //end dwarf
                //begin goblin
                if (model.Character.AncestryId == 5)
                {
                    var abt = (from ab in _context.AncestryBaseTraits
                               join a in _context.Ancestry on ab.AncestryId equals a.AncestryId
                               where ab.AncestryId == 5
                               select ab.BaseValue)
                              .ToList();

                    CharTrait goblinTraitStrength = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 1,
                        CharTraitValue = abt.ElementAt(0).ToString()

                    };

                    //add to hold in db context
                    _context.Add(goblinTraitStrength);

                    CharTrait goblinTraitAgility = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 2,
                        CharTraitValue = abt.ElementAt(1).ToString()
                    };

                    //add to hold in db context
                    _context.Add(goblinTraitAgility);

                    CharTrait goblinTraitIntellect = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 3,
                        CharTraitValue = abt.ElementAt(2).ToString()
                    };

                    //add to hold in db context
                    _context.Add(goblinTraitIntellect);

                    CharTrait goblinTraitWill = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 4,
                        CharTraitValue = abt.ElementAt(3).ToString()
                    };

                    //add to hold in db context and save context to db
                    _context.Add(goblinTraitWill);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("UserHome", "ApplicationUser");
                }
                //end goblin
                //begin orc
                if (model.Character.AncestryId == 6)
                {
                    var abt = (from ab in _context.AncestryBaseTraits
                               join a in _context.Ancestry on ab.AncestryId equals a.AncestryId
                               where ab.AncestryId == 6
                               select ab.BaseValue)
                              .ToList();

                    CharTrait orcTraitStrength = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 1,
                        CharTraitValue = abt.ElementAt(0).ToString()

                    };

                    //add to hold in db context
                    _context.Add(orcTraitStrength);

                    CharTrait orcTraitAgility = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 2,
                        CharTraitValue = abt.ElementAt(1).ToString()
                    };

                    //add to hold in db context
                    _context.Add(orcTraitAgility);

                    CharTrait orcTraitIntellect = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 3,
                        CharTraitValue = abt.ElementAt(2).ToString()
                    };

                    //add to hold in db context
                    _context.Add(orcTraitIntellect);

                    CharTrait orcTraitWill = new CharTrait
                    {
                        CharacterId = model.Character.CharacterId,
                        TraitId = 4,
                        CharTraitValue = abt.ElementAt(3).ToString()
                    };

                    //add to hold in db context and save context to db
                    _context.Add(orcTraitWill);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("UserHome", "ApplicationUser");
                }
                //end orc

                return View(character);
            }
            return View();

        }

        

        // GET: Characters/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //connection to view model
            HumanEditViewModel viewModel = new HumanEditViewModel();

            //current user
            ApplicationUser user = await GetCurrentUserAsync();

            //fill propert with character by id from route and user id
             viewModel.Character = await _context.Characters
                            .Where(c => c.CharacterId == id)
                            .FirstAsync(c => c.ApplicationUserId == user.Id);

            

            if (viewModel.Character == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId,CharacterName,Gender,Level,ApplicationUserId, AncestryId")] Character character)
        {
            //Current user  
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

            return View(character);
        }

        // GET: Characters/Delete/5
        [Authorize]
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
        [ValidateAntiForgeryToken, Authorize]
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
