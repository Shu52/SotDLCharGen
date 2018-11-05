using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SotDLCharGen.Data;
using SotDLCharGen.Models;
using SotDLCharGen.ViewModels;

namespace SotDLCharGen.Controllers
{
    public class HumanAbilitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManager<ApplicationUser> _userManager { get; }

        public HumanAbilitiesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            {
                _context = context;
                _userManager = userManager;
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //don't know if i need to bind anything
        public IActionResult HumanAbilitiesForm()
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

           
            //model.Add(new CharTrait()
            //{
            //    CharacterId = characters.CharacterId,
            //    TraitId = 1,
            //    CharTraitValue = "10"
            //});
            //model.Add(humanTraitStrength)

           


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
        // POST: HumanAbilities/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create([Bind ("strength", "agility","intellect", "will" )] IFormCollection collection)
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var characters = _context.Characters
                .Where(character => character.ApplicationUserId == user.Id )
                .Last();

            //var TraitValue = collection.ToList();

            //var test = collection.ElementAt(1).Value;

            //var attempt = TraitValue.ToLookup;
            CharTrait EntriesToPost = new CharTrait();

            var strenghtValue = collection.ElementAt(1).Value;
            var agilityValue = collection.ElementAt(2).Value;
            var intellectValue = collection.ElementAt(3).Value;
            var WillValue = collection.ElementAt(4).Value;

            int TotalValue()
            {
                int numVal = Int32.Parse(strenghtValue) + Int32.Parse(agilityValue) + Int32.Parse(intellectValue) + Int32.Parse(WillValue);
                return numVal;
            }

            Console.WriteLine("In HumanAbilitiesCreate");

            if(ModelState.IsValid && TotalValue() == 42)
            {

                CharTrait humanTraitStrength = new CharTrait
                {
                    //CharTraitId = charTrait.CharTraitId,
                    CharacterId = characters.CharacterId,
                    TraitId = 1,
                    CharTraitValue = collection.ElementAt(1).Value
                };
                CharTrait humanTraitAgility = new CharTrait
                {
                    //CharTraitId = charTrait.CharTraitId,
                    CharacterId = characters.CharacterId,
                    TraitId = 2,
                    CharTraitValue = collection.ElementAt(2).Value
                };

                CharTrait humanTraitIntellect = new CharTrait
                {
                    //CharTraitId = charTrait.CharTraitId,
                    CharacterId = characters.CharacterId,
                    TraitId = 3,
                    CharTraitValue = collection.ElementAt(3).Value
                };

                CharTrait humanTraitWill = new CharTrait
                {
                    //CharTraitId = charTrait.CharTraitId,
                    CharacterId = characters.CharacterId,
                    TraitId = 4,
                    CharTraitValue = collection.ElementAt(4).Value
                };

                // TODO: Add insert logic here

                return RedirectToAction("UserHome", "ApplicationUser");
            }
            else
            {
                return View("HumanAbilitiesForm");
            }
        }

        // GET: HumanAbilities
        public ActionResult Index()
        {
            return View();
        }

        // GET: HumanAbilities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HumanAbilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HumanAbilities/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: HumanAbilities/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HumanAbilities/Edit/5
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

        // GET: HumanAbilities/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HumanAbilities/Delete/5
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