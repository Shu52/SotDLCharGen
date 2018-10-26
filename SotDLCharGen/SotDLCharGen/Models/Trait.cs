using System.ComponentModel.DataAnnotations;

namespace SotDLCharGen.Models
{
    public class Trait
    {
        [Key]
        public int TraitId { get; set; }

        public string TraitName { get; set; }
    }
}