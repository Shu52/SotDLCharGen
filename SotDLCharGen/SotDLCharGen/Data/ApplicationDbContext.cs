using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SotDLCharGen.Models;
using SotDLCharGen.ViewModels;

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

            modelBuilder.Entity<Ancestry>().HasData(
                    new Ancestry
                    {
                        AncestryId = 1,
                        AncestryName = "Human"
                    }
                    );
            modelBuilder.Entity<AncestryBaseTrait>().HasData(
                new AncestryBaseTrait
                {
                    AncestryBaseTraitId =1,
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
                }
                );
        }

        public DbSet<SotDLCharGen.ViewModels.HumanAbilitiesViewModel> HumanAbilitiesViewModel { get; set; }

        public DbSet<SotDLCharGen.ViewModels.CharTraitHumanViewModel> CharTraitHumanViewModel { get; set; }
    }
    }
