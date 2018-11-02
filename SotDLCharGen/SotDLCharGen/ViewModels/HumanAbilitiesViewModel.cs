using SotDLCharGen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class HumanAbilitiesViewModel
    {
        [Key]
        public int HumanAbilities { get; set; }

        public List <CharTrait> CharTraits { get; }

        public List<AncestryBaseTrait> AncestryBaseTraits { get; set; }

        public AncestryBaseTrait ancestryBaseTrait { get; set; }

        public int strength { get; set; }

        public int agility { get; set; }

        public int intellect { get; set; }

        public int will { get; set; }

        [Range(42,24,ErrorMessage = "The sum of all values must be 42")]
        public int AllValues 
        {
            get
            {
                return strength + agility + intellect + will;
            }
        }
   }
}
