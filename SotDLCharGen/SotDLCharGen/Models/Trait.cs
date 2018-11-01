using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotDLCharGen.Models
{
    public class Trait
    {
        [Key]
        public int TraitId { get; set; }

        public string TraitName { get; set; }

        public virtual ICollection <CharTrait> CharTraits { get; set; }

        public virtual ICollection<AncestryBaseTrait> AncestryBaseTraits { get; set; }
    }
}