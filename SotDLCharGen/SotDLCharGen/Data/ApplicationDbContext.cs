using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Models;

namespace SotDLCharGen.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Ancestry> Ancestry { get; set; }
        public DbSet<AncestryBaseTrait> AncestryBaseTraits { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharTrait> CharTrait { get; set; }
        public DbSet<Trait> Trait { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            ApplicationUser user = new ApplicationUser
            {
                UserName = "test",
                PlayerName = "test",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Test1*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Trait>().HasData
                (
                    new Trait
                    {
                        TraitId = 1,
                        TraitName = "Strength"
                    },
                    new Trait
                    {
                        TraitId = 2,
                        TraitName = "Agility"
                    },
                    new Trait
                    {
                        TraitId = 3,
                        TraitName = "Intellect"
                    },
                    new Trait
                    {
                        TraitId = 4,
                        TraitName = "Will"
                    }

                );

            modelBuilder.Entity<Ancestry>().HasData
                (
                    new Ancestry
                    {
                        AncestryId = 1,
                        AncestryName = "Human"
                    },
                    new Ancestry
                    {
                        AncestryId = 2,
                        AncestryName = "Changeling"
                    },
                    new Ancestry
                    {
                        AncestryId = 3,
                        AncestryName = "Clockwork"
                    },
                    new Ancestry
                    {
                        AncestryId = 4,
                        AncestryName = "Dwarf"
                    },
                    new Ancestry
                    {
                        AncestryId = 5,
                        AncestryName = "Goblin"
                    },
                    new Ancestry
                    {
                        AncestryId = 6,
                        AncestryName = "Orc"
                    }

                );
            modelBuilder.Entity<AncestryBaseTrait>().HasData
                (
                //begin human
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 1,
                        AncestryId = 1,
                        TraitId = 1,
                        BaseValue = "10",
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 2,
                        AncestryId = 1,
                        TraitId = 2,
                        BaseValue = "10",
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 3,
                        AncestryId = 1,
                        TraitId = 3,
                        BaseValue = "10",
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 4,
                        AncestryId = 1,
                        TraitId = 4,
                        BaseValue = "10",
                    },
                    //end human
                    //begin changeling
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 5,
                        AncestryId = 2,
                        TraitId = 1,
                        BaseValue = "9"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 6,
                        AncestryId = 2,
                        TraitId = 2,
                        BaseValue = "10"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 7,
                        AncestryId = 2,
                        TraitId = 3,
                        BaseValue = "10"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 8,
                        AncestryId = 2,
                        TraitId = 4,
                        BaseValue = "10"
                    },
                    //end changeling
                    //begin clockwork
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 9,
                        AncestryId = 3,
                        TraitId = 1,
                        BaseValue = "9"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 10,
                        AncestryId = 3,
                        TraitId = 2,
                        BaseValue = "8"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 11,
                        AncestryId = 3,
                        TraitId = 3,
                        BaseValue = "9"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 12,
                        AncestryId = 3, 
                        TraitId = 4,
                        BaseValue = "9"
                    },
                    //end clockwork
                    //begin dwarf
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 13,
                        AncestryId = 4,
                        TraitId = 1,
                        BaseValue = "10"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 14,
                        AncestryId = 4,
                        TraitId = 2,
                        BaseValue = "9"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 15,
                        AncestryId = 4,
                        TraitId = 3,
                        BaseValue = "10"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 16,
                        AncestryId = 4,
                        TraitId = 4,
                        BaseValue = "10"
                    },
                    //end dwarf
                    //Begin Goblin
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 17,
                        AncestryId = 5,
                        TraitId = 1,
                        BaseValue = "8"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 18,
                        AncestryId = 5,
                        TraitId = 2,
                        BaseValue = "12"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 19,
                        AncestryId = 5,
                        TraitId = 3,
                        BaseValue = "10"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 20,
                        AncestryId = 5,
                        TraitId = 4,
                        BaseValue = "9"
                    },
                    //End goblin
                    //Begin Orc
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 21,
                        AncestryId = 6,
                        TraitId = 1,
                        BaseValue = "11"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 22,
                        AncestryId = 6,
                        TraitId = 2,
                        BaseValue = "10"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 23,
                        AncestryId = 6,
                        TraitId = 3,
                        BaseValue = "9"
                    },
                    new AncestryBaseTrait
                    {
                        AncestryBaseTraitId = 24,
                        AncestryId = 6,
                        TraitId = 4,
                        BaseValue = "9"
                    }
                    //End Orc

               );
        }

    }
}
