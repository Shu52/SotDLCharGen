//Well,this shit didn't work

//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using SotDLCharGen.Data;
//using System;
//using System.Linq;

//namespace SotDLCharGen.Models
//{
//    public class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new ApplicationDbContext(
//                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
//            {
//                // Look for any traits.
//                if (context.Trait.Any())
//                {
//                    return;   // DB has been seeded
//                }


//                context.Trait.AddRange(
//                    new Trait
//                    {   
//                        TraitId = 1,
//                        TraitName = "Strength"
//                    },
//                    new Trait
//                    {
//                        TraitId = 2,
//                        TraitName = "Agility"
//                    },
//                    new Trait
//                    {
//                        TraitId = 3,
//                        TraitName = "Intellect"
//                    },
//                    new Trait
//                    {
//                        TraitId = 4,
//                        TraitName = "Will"
//                    }

//                    );
//                context.Ancestry.AddRange(
//                    new Ancestry
//                    {
//                        AncestryId = 1,
//                        AncestryName = "Human"
//                    }
//                    );
//                context.AncestryBaseTraits.AddRange(
//                    new AncestryBaseTrait
//                    {
//                        AncestryId = 1,
//                        TraitId = 1,
//                        BaseValue = "10",
//                    },
//                    new AncestryBaseTrait
//                    {
//                        AncestryId = 1,
//                        TraitId = 2,
//                        BaseValue = "10",
//                    },
//                    new AncestryBaseTrait
//                    {
//                        AncestryId = 1,
//                        TraitId = 3,
//                        BaseValue = "10",
//                    },
//                    new AncestryBaseTrait
//                    {
//                        AncestryId = 1,
//                        TraitId = 4,
//                        BaseValue = "10",
//                    }
//                    );
                
//            };
                        
            
//        }
//    }
//}
