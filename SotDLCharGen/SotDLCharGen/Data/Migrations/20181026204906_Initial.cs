using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ancestry",
                columns: table => new
                {
                    AncestryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AncestryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ancestry", x => x.AncestryId);
                });

            migrationBuilder.CreateTable(
                name: "Trait",
                columns: table => new
                {
                    TraitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TraitName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trait", x => x.TraitId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterName = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    AncestryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Ancestry_AncestryId",
                        column: x => x.AncestryId,
                        principalTable: "Ancestry",
                        principalColumn: "AncestryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AncestryBaseTraits",
                columns: table => new
                {
                    AncestryBaseTraitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseValue = table.Column<string>(nullable: true),
                    AncestryId = table.Column<int>(nullable: false),
                    TraitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AncestryBaseTraits", x => x.AncestryBaseTraitId);
                    table.ForeignKey(
                        name: "FK_AncestryBaseTraits_Ancestry_AncestryId",
                        column: x => x.AncestryId,
                        principalTable: "Ancestry",
                        principalColumn: "AncestryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AncestryBaseTraits_Trait_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Trait",
                        principalColumn: "TraitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharTrait",
                columns: table => new
                {
                    CharcTraitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharTraitValue = table.Column<string>(nullable: true),
                    CharacterId = table.Column<int>(nullable: false),
                    TraitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharTrait", x => x.CharcTraitId);
                    table.ForeignKey(
                        name: "FK_CharTrait_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharTrait_Trait_TraitId",
                        column: x => x.TraitId,
                        principalTable: "Trait",
                        principalColumn: "TraitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AncestryBaseTraits_AncestryId",
                table: "AncestryBaseTraits",
                column: "AncestryId");

            migrationBuilder.CreateIndex(
                name: "IX_AncestryBaseTraits_TraitId",
                table: "AncestryBaseTraits",
                column: "TraitId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_AncestryId",
                table: "Characters",
                column: "AncestryId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharTrait_CharacterId",
                table: "CharTrait",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CharTrait_TraitId",
                table: "CharTrait",
                column: "TraitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AncestryBaseTraits");

            migrationBuilder.DropTable(
                name: "CharTrait");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Trait");

            migrationBuilder.DropTable(
                name: "Ancestry");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlayerName",
                table: "AspNetUsers");
        }
    }
}
