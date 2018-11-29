using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.Models
{
    public class ClockworkPurpose
    {
        [Key]
        public int ClockworkPurposeId { get; set; }

        [Display(Name = "Clockwork Purpose")]
        public string ClockworkPurposeValue { get; set; }
    }
}
