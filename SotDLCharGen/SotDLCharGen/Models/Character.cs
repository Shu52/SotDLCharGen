﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotDLCharGen.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }

        [StringLength(30, ErrorMessage = "Max Character limit is 30 characters"), Required, Display(Name ="Character's Name")]
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

        public virtual ICollection <CharTrait> CharTraits { get; set; } 
    }
}
