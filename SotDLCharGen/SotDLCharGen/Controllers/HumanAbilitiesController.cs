using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SotDLCharGen.Data;
using SotDLCharGen.Models;

namespace SotDLCharGen.Controllers
{
    public class HumanAbilitiesController : Controller
    {
        //connection to database
        private readonly ApplicationDbContext _context;

        //connection to user
        private UserManager<ApplicationUser> _userManager { get; }

        public HumanAbilitiesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            {
                _context = context;
                _userManager = userManager;
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET Controller for human abilites form
        public IActionResult HumanAbilitiesForm()
        {
            return View();
        }

        // POST: HumanAbilities/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create([Bind ("strength", "agility","intellect", "will" )] IFormCollection collection)
        {
            //get current user
            ApplicationUser user = await GetCurrentUserAsync();

            //get last character for current user
            var characters = _context.Characters
                .Where(character => character.ApplicationUserId == user.Id )
                .Last();

            //Assign form values to variables
            var strenghtValue = collection.ElementAt(0).Value;
            var agilityValue = collection.ElementAt(1).Value;
            var intellectValue = collection.ElementAt(2).Value;
            var WillValue = collection.ElementAt(3).Value;

            //Method for validation using form variables
            int TotalValue()
            {
                //Parse from string to int
                int numVal = Int32.Parse(strenghtValue) + Int32.Parse(agilityValue) + Int32.Parse(intellectValue) + Int32.Parse(WillValue);
                return numVal;
            }


            if(ModelState.IsValid && TotalValue() == 42)
            {

                //build new row in CharTrait table
                CharTrait humanTraitStrength = new CharTrait
                {
                    CharacterId = characters.CharacterId,
                    TraitId = 1,
                    CharTraitValue = collection.ElementAt(0).Value
                };

                //add to hold in db context
                _context.Add(humanTraitStrength);

                CharTrait humanTraitAgility = new CharTrait
                {
                    CharacterId = characters.CharacterId,
                    TraitId = 2,
                    CharTraitValue = collection.ElementAt(1).Value
                };

                //add to hold in db context
                _context.Add(humanTraitAgility);

                CharTrait humanTraitIntellect = new CharTrait
                {
                    CharacterId = characters.CharacterId,
                    TraitId = 3,
                    CharTraitValue = collection.ElementAt(2).Value
                };

                //add to hold in db context
                _context.Add(humanTraitIntellect);

                CharTrait humanTraitWill = new CharTrait
                {
                    CharacterId = characters.CharacterId,
                    TraitId = 4,
                    CharTraitValue = collection.ElementAt(3).Value
                };

                //add to hold in db context and save context to db
                _context.Add(humanTraitWill);
                await _context.SaveChangesAsync();

                return RedirectToAction("UserHome", "ApplicationUser");
            }
            else
            {
                //if failed vaildation, return to form
                return View("HumanAbilitiesForm");
            }
        }

    }
}