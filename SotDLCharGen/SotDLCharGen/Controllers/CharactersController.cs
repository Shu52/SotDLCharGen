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

            var stringVal = character.Character.CharTraits.ElementAt(0).CharTraitValue;

            //calculate healing rate
            int healingRate()
            {
                double numVal = Int32.Parse(stringVal);
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
                    return RedirectToAction("HumanAbilitiesForm","HumanAbilities");
                }
                return RedirectToAction("UserHome","ApplicationUser");
            }
            
            return View(character);
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
