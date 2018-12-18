using Microsoft.AspNetCore.Mvc.Rendering;
using SotDLCharGen.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class ClockworkPurposeViewModel
    {
        public int ClockworkPurposeId { get; set; }

        public string SelectedAttr { get; set; }

        [Display(Name = "Clockwork Purpose", GroupName = "Clockwork Purpose")]
        public List<SelectListItem> ClockworkPurpose { get; set; }

        public ClockworkPurposeViewModel(ApplicationDbContext context)
        {

            ClockworkPurpose = context.ClockworkPurposes.Select(purpose =>
            new SelectListItem { Text = purpose.ClockworkPurposeValue, Value = purpose.ClockworkPurposeId.ToString() }).ToList();

        }
        public ClockworkPurposeViewModel() { }
    }
}
