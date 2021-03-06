﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SotDLCharGen.Data;

namespace SotDLCharGen.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181105162735_initialAgain")]
    partial class initialAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SotDLCharGen.Models.Ancestry", b =>
                {
                    b.Property<int>("AncestryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AncestryName");

                    b.HasKey("AncestryId");

                    b.ToTable("Ancestry");

                    b.HasData(
                        new { AncestryId = 1, AncestryName = "Human" }
                    );
                });

            modelBuilder.Entity("SotDLCharGen.Models.AncestryBaseTrait", b =>
                {
                    b.Property<int>("AncestryBaseTraitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AncestryId");

                    b.Property<string>("BaseValue");

                    b.Property<int>("TraitId");

                    b.HasKey("AncestryBaseTraitId");

                    b.HasIndex("AncestryId");

                    b.HasIndex("TraitId");

                    b.ToTable("AncestryBaseTraits");

                    b.HasData(
                        new { AncestryBaseTraitId = 1, AncestryId = 1, BaseValue = "10", TraitId = 1 },
                        new { AncestryBaseTraitId = 2, AncestryId = 1, BaseValue = "10", TraitId = 2 },
                        new { AncestryBaseTraitId = 3, AncestryId = 1, BaseValue = "10", TraitId = 3 },
                        new { AncestryBaseTraitId = 4, AncestryId = 1, BaseValue = "10", TraitId = 4 }
                    );
                });

            modelBuilder.Entity("SotDLCharGen.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PlayerName")
                        .IsRequired();

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new { Id = "9a992415-1167-47c0-b54d-503d1162147c", AccessFailedCount = 0, ConcurrencyStamp = "bef300bf-3212-4194-a53a-c61f40fbd13e", Email = "test@test.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "TEST@TEST.COM", PasswordHash = "AQAAAAEAACcQAAAAEOqnZ5wfnKr+9j7Oxp+X1Mogp2d0LiOcrYn4WX/FCRYLSTdzptkGdaZU+EAEbEpy0w==", PhoneNumberConfirmed = false, PlayerName = "test", SecurityStamp = "e9042db2-8b63-4410-9dcc-0364bdd274b2", TwoFactorEnabled = false, UserName = "test" }
                    );
                });

            modelBuilder.Entity("SotDLCharGen.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AncestryId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("CharacterName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("Level");

                    b.HasKey("CharacterId");

                    b.HasIndex("AncestryId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("SotDLCharGen.Models.CharTrait", b =>
                {
                    b.Property<int>("CharTraitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharTraitValue");

                    b.Property<int>("CharacterId");

                    b.Property<int>("TraitId");

                    b.HasKey("CharTraitId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("TraitId");

                    b.ToTable("CharTrait");
                });

            modelBuilder.Entity("SotDLCharGen.Models.Trait", b =>
                {
                    b.Property<int>("TraitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TraitName");

                    b.HasKey("TraitId");

                    b.ToTable("Trait");

                    b.HasData(
                        new { TraitId = 1, TraitName = "Strength" },
                        new { TraitId = 2, TraitName = "Agility" },
                        new { TraitId = 3, TraitName = "Intellect" },
                        new { TraitId = 4, TraitName = "Will" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SotDLCharGen.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SotDLCharGen.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SotDLCharGen.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SotDLCharGen.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SotDLCharGen.Models.AncestryBaseTrait", b =>
                {
                    b.HasOne("SotDLCharGen.Models.Ancestry", "Ancestry")
                        .WithMany("AncestryBaseTraits")
                        .HasForeignKey("AncestryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SotDLCharGen.Models.Trait", "Trait")
                        .WithMany("AncestryBaseTraits")
                        .HasForeignKey("TraitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SotDLCharGen.Models.Character", b =>
                {
                    b.HasOne("SotDLCharGen.Models.Ancestry", "Ancestry")
                        .WithMany("Characters")
                        .HasForeignKey("AncestryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SotDLCharGen.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Characters")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("SotDLCharGen.Models.CharTrait", b =>
                {
                    b.HasOne("SotDLCharGen.Models.Character", "Character")
                        .WithMany("CharTraits")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SotDLCharGen.Models.Trait", "Trait")
                        .WithMany("CharTraits")
                        .HasForeignKey("TraitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
