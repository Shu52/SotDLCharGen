using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Models;

namespace SotDLCharGen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Ancestry> Ancestry { get; set; }
        public DbSet<AncestryBaseTrait> AncestryBaseTraits { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharTrait> CharTrait { get; set; }
        public DbSet<Trait> Trait { get; set; }
    }
}
