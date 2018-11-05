﻿using SotDLCharGen.Data;
using SotDLCharGen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class HumanDetailsViewModel
    {
        [Display(Name = " Character's Name")]
        public string CharacterName { get; set; }

        public string Gender { get; set; }
        
        public int Level { get; set; }
        
        public string ApplicationUserId { get; set; }

        public Character Character { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Ancestry")]
        public int AncestryId { get; set; }

        public Ancestry Ancestry { get; set; }

        [Display(Name = " Healing Rate")]
        public int healingRate { get; set; }

        public virtual ICollection<CharTrait> CharTraits { get; set; }

        public HumanDetailsViewModel (ApplicationDbContext context)
        {

        }
        public HumanDetailsViewModel(){}

    }

}