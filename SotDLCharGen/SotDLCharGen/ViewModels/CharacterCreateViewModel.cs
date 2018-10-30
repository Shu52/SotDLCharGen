using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SotDLCharGen.Data;
using SotDLCharGen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class CharacterCreateViewModel
    {

        [Key]
        public int CharacterId { get; set; }

        [StringLength(30, ErrorMessage = "Max Character limit is 30 characters"), Required]
        public string CharacterName { get; set; }

        [StringLength(10, ErrorMessage = "Max Character limit is 10 characters"), Required]
        public string Gender { get; set; }

        [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Level { get; set; }

        [Display(Name = "Player Name")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Ancestry")]
        public int AncestryId { get; set; }

        public Ancestry Ancestry { get; set; }

        public List<SelectListItem> Ancestries { get; set; }

        private ApplicationDbContext _context;


        public CharacterCreateViewModel(ApplicationDbContext context)
        {
            
                Ancestries = context.Ancestry.Select(ancestry =>
                new SelectListItem { Text = ancestry.AncestryName, Value = ancestry.AncestryId.ToString()}).ToList();
            
        }

        public CharacterCreateViewModel() { }


    }
}
