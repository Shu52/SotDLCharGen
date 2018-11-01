using SotDLCharGen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class HumanAbilitiesViewModel
    {
        [Key]
        public int HumanAbilities { get; set; }

        public List <Trait> Traits { get; }

        public List <AncestryBaseTrait> AncestryBaseTraits { get; }


    }
}
