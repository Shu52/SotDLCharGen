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
    public class HumanEditViewModel
    {

        public Character Character { get; set; }
        
    }
}