using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.Models
{
    public class AncestryBaseTrait
    {
        [Key]
        public int AncestryBaseTraitId { get; set; }

        public string BaseValue { get; set; }

        public int AncestryId { get; set; }

        public Ancestry Ancestry { get; set; }

        public int TraitId { get; set; }

        public Trait Trait { get; set; }
    }
}
