using SotDLCharGen.Data;
using SotDLCharGen.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotDLCharGen.ViewModels
{
    public class ApplicationUserViewModel
    {
        private ApplicationDbContext _context;

        [Display(Name = "Character's Name" )]
        public string CharacterName { get; set; }

        public IEnumerable <Character> Characters { get; set; }

        public ApplicationUserViewModel(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
