using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Data;
using SotDLCharGen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class CharTraitHumanViewModel
    {
        [Key]
        public int CharTrait { get; set; }

        public List <CharTrait> CharTraits { get; set; }

        public Trait Traits { get; set; }

        public CharTraitHumanViewModel() { }

        public CharTraitHumanViewModel(ApplicationDbContext context)
        {
            CharTraits = context.CharTrait
                         .Include("Trait")
                         .ToList();
                         
        }
    }
}
