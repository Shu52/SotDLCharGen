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
        //connection to Database
        private ApplicationDbContext _context;

        //connection to user
        private UserManager<ApplicationUser> _userManager { get; }

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
            //get current user and set them to user
            ApplicationUser user = await GetCurrentUserAsync();
            //link var to view model
            ApplicationUserViewModel model = new ApplicationUserViewModel(_context);

            model.Characters = await _context.Characters.Where(character => character.ApplicationUserId == user.Id).ToListAsync();
            return View(model);
        }
        
    }
}