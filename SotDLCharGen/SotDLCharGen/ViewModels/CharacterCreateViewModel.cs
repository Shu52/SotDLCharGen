using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using SotDLCharGen.Data;
using SotDLCharGen.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SotDLCharGen.ViewModels
{
    public class CharacterCreateViewModel
    {

        public List<SelectListItem> Ancestries { get; set; }
        public SelectList AncestriesList { get; set; }

        public Character Character { get; set; }

        public CharacterCreateViewModel(ApplicationDbContext context)
        {
            
                Ancestries = context.Ancestry.Select(ancestry =>
                new SelectListItem { Text = ancestry.AncestryName, Value = ancestry.AncestryId.ToString()}).ToList();
                     
        }
        
        public CharacterCreateViewModel() { }
        
    }
}
