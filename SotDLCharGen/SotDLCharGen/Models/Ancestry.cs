using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SotDLCharGen.Models
{
    public class Ancestry
    {
        [Key]
        public int AncestryId { get; set; }

        [Display(Name = "Ancestry")]
        public string AncestryName { get; set; }

        public virtual ICollection <AncestryBaseTrait> AncestryBaseTraits { get; set; }

        public virtual ICollection <Character> Characters { get; set; }
    }
}