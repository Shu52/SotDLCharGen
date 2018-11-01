using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SotDLCharGen.Models
{
    // Add profile data for application users by adding properties to the WebApp1User class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        [Required]
        [Display(Name = "Player Name")]
        public string PlayerName { get; set; }

        public virtual ICollection <Character> Characters { get; set; }
        

    }
}