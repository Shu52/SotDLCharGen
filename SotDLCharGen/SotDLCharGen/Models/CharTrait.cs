using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.Models
{
    public class CharTrait
    {
        [Key]
        public int CharTraitId { get; set; }

        public string CharTraitValue { get; set; }

        public int CharacterId { get; set; }

        public Character Character { get; set; } 

        public int TraitId { get; set; }

        public Trait Trait { get; set; }
    }
}
