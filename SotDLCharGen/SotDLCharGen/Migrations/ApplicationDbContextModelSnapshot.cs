﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SotDLCharGen.Data;

namespace SotDLCharGen.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        new { AncestryId = 1, AncestryName = "Human" },
                        new { AncestryId = 2, AncestryName = "Changeling" },
                        new { AncestryId = 3, AncestryName = "Clockwork" },
                        new { AncestryId = 4, AncestryName = "Dwarf" },
                        new { AncestryId = 5, AncestryName = "Goblin" },
                        new { AncestryId = 6, AncestryName = "Orc" }
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
                        new { AncestryBaseTraitId = 4, AncestryId = 1, BaseValue = "10", TraitId = 4 },
                        new { AncestryBaseTraitId = 5, AncestryId = 2, BaseValue = "9", TraitId = 1 },
                        new { AncestryBaseTraitId = 6, AncestryId = 2, BaseValue = "10", TraitId = 2 },
                        new { AncestryBaseTraitId = 7, AncestryId = 2, BaseValue = "10", TraitId = 3 },
                        new { AncestryBaseTraitId = 8, AncestryId = 2, BaseValue = "10", TraitId = 4 },
                        new { AncestryBaseTraitId = 9, AncestryId = 3, BaseValue = "9", TraitId = 1 },
                        new { AncestryBaseTraitId = 10, AncestryId = 3, BaseValue = "8", TraitId = 2 },
                        new { AncestryBaseTraitId = 11, AncestryId = 3, BaseValue = "9", TraitId = 3 },
                        new { AncestryBaseTraitId = 12, AncestryId = 3, BaseValue = "9", TraitId = 4 },
                        new { AncestryBaseTraitId = 13, AncestryId = 4, BaseValue = "10", TraitId = 1 },
                        new { AncestryBaseTraitId = 14, AncestryId = 4, BaseValue = "9", TraitId = 2 },
                        new { AncestryBaseTraitId = 15, AncestryId = 4, BaseValue = "10", TraitId = 3 },
                        new { AncestryBaseTraitId = 16, AncestryId = 4, BaseValue = "10", TraitId = 4 },
                        new { AncestryBaseTraitId = 17, AncestryId = 5, BaseValue = "8", TraitId = 1 },
                        new { AncestryBaseTraitId = 18, AncestryId = 5, BaseValue = "12", TraitId = 2 },
                        new { AncestryBaseTraitId = 19, AncestryId = 5, BaseValue = "10", TraitId = 3 },
                        new { AncestryBaseTraitId = 20, AncestryId = 5, BaseValue = "9", TraitId = 4 },
                        new { AncestryBaseTraitId = 21, AncestryId = 6, BaseValue = "11", TraitId = 1 },
                        new { AncestryBaseTraitId = 22, AncestryId = 6, BaseValue = "10", TraitId = 2 },
                        new { AncestryBaseTraitId = 23, AncestryId = 6, BaseValue = "9", TraitId = 3 },
                        new { AncestryBaseTraitId = 24, AncestryId = 6, BaseValue = "9", TraitId = 4 }
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
                        new { Id = "da5cbfa2-1ed0-4e65-a78e-213f4954e3e3", AccessFailedCount = 0, ConcurrencyStamp = "b5a37615-e288-4728-883e-19c8882476a9", Email = "test@test.com", EmailConfirmed = true, LockoutEnabled = false, NormalizedEmail = "TEST@TEST.COM", PasswordHash = "AQAAAAEAACcQAAAAEPGYG6BkZSIJ9HCYIKYdaxihnTo1YKO1ol2a/yxU2Dvc1f1RpYuJr0qRce4vn6dV1w==", PhoneNumberConfirmed = false, PlayerName = "test", SecurityStamp = "dd2c332a-495a-4a1b-b105-ef9ccc3b4640", TwoFactorEnabled = false, UserName = "test" }
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

            modelBuilder.Entity("SotDLCharGen.Models.ClockworkPurpose", b =>
                {
                    b.Property<int>("ClockworkPurposeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AncestryId");

                    b.Property<string>("ClockworkPurposeValue");

                    b.HasKey("ClockworkPurposeId");

                    b.HasIndex("AncestryId");

                    b.ToTable("ClockworkPurposes");

                    b.HasData(
                        new { ClockworkPurposeId = 1, ClockworkPurposeValue = "You were built for war. Increase your Strength or Agility by 2" },
                        new { ClockworkPurposeId = 2, ClockworkPurposeValue = "You were built to work. Increase your Strength by 2" },
                        new { ClockworkPurposeId = 3, ClockworkPurposeValue = "You were built to use magic. Increase your Intellect or Will by 2" },
                        new { ClockworkPurposeId = 4, ClockworkPurposeValue = "You were built to gather intelligence about or assassinate targets.Increase your Agility or Intellect by 2" },
                        new { ClockworkPurposeId = 5, ClockworkPurposeValue = "You were built for an inexplicable purpose. Increase one attribute of your choice by 2" }
                    );
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

            modelBuilder.Entity("SotDLCharGen.Models.ClockworkPurpose", b =>
                {
                    b.HasOne("SotDLCharGen.Models.Ancestry")
                        .WithMany("ClockworkPurposes")
                        .HasForeignKey("AncestryId");
                });
#pragma warning restore 612, 618
        }
    }
}
