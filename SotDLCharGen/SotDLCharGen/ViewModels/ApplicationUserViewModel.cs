using SotDLCharGen.Data;
using SotDLCharGen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class ApplicationUserViewModel
    {
        private ApplicationDbContext _context;

        public ApplicationUserViewModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [Display(Name = "Character Name" )]
        public string CharacterName { get; set; }

        public IEnumerable <Character> Characters { get; set; }
    }
}
