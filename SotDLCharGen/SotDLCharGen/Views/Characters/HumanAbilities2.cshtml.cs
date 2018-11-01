using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SotDLCharGen.Data;
using SotDLCharGen.ViewModels;

namespace SotDLCharGen.Views.Characters
{
    public class HumanAbilitiesModel : PageModel
    {
        private readonly SotDLCharGen.Data.ApplicationDbContext _context;

        public HumanAbilitiesModel(SotDLCharGen.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CharTraitHumanViewModel CharTraitHumanViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CharTraitHumanViewModel.Add(CharTraitHumanViewModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}