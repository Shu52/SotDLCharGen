using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Data.Migrations
{
    public partial class ICollectionAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "de4882f6-b594-41c5-818b-73093346f575", "311bc242-3a20-42fb-ac7e-b0a663bdcc2d" });

            migrationBuilder.AddColumn<int>(
                name: "HumanAbilitiesViewModelHumanAbilities",
                table: "Trait",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CharTraitHumanViewModelCharTrait",
                table: "CharTrait",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HumanAbilitiesViewModelHumanAbilities",
                table: "AncestryBaseTraits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CharTraitHumanViewModel",
                columns: table => new
                {
                    CharTrait = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharTraitHumanViewModel", x => x.CharTrait);
                });

            migrationBuilder.CreateTable(
                name: "HumanAbilitiesViewModel",
                columns: table => new
                {
                    HumanAbilities = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanAbilitiesViewModel", x => x.HumanAbilities);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5a43ae4-0f4d-4db6-988c-c1a3460438d7", 0, "e9c409b4-79ce-46a5-823c-4695cf124e59", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEAz4hRO6U+xO/ig4xe0mcJ+1miyKJDMJT2ufH/ywEZO6DQnf8NAggcC9s9j0rKST3A==", null, false, "test", "15d4770f-7396-4af0-98fa-05616b9e64dc", false, "test" });

            migrationBuilder.CreateIndex(
                name: "IX_Trait_HumanAbilitiesViewModelHumanAbilities",
                table: "Trait",
                column: "HumanAbilitiesViewModelHumanAbilities");

            migrationBuilder.CreateIndex(
                name: "IX_CharTrait_CharTraitHumanViewModelCharTrait",
                table: "CharTrait",
                column: "CharTraitHumanViewModelCharTrait");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AncestryBaseTraits_HumanAbilitiesViewModelHumanAbilities",
                table: "AncestryBaseTraits",
                column: "HumanAbilitiesViewModelHumanAbilities");

            migrationBuilder.AddForeignKey(
                name: "FK_AncestryBaseTraits_HumanAbilitiesViewModel_HumanAbilitiesViewModelHumanAbilities",
                table: "AncestryBaseTraits",
                column: "HumanAbilitiesViewModelHumanAbilities",
                principalTable: "HumanAbilitiesViewModel",
                principalColumn: "HumanAbilities",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CharTrait_CharTraitHumanViewModel_CharTraitHumanViewModelCharTrait",
                table: "CharTrait",
                column: "CharTraitHumanViewModelCharTrait",
                principalTable: "CharTraitHumanViewModel",
                principalColumn: "CharTrait",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trait_HumanAbilitiesViewModel_HumanAbilitiesViewModelHumanAbilities",
                table: "Trait",
                column: "HumanAbilitiesViewModelHumanAbilities",
                principalTable: "HumanAbilitiesViewModel",
                principalColumn: "HumanAbilities",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AncestryBaseTraits_HumanAbilitiesViewModel_HumanAbilitiesViewModelHumanAbilities",
                table: "AncestryBaseTraits");

            migrationBuilder.DropForeignKey(
                name: "FK_CharTrait_CharTraitHumanViewModel_CharTraitHumanViewModelCharTrait",
                table: "CharTrait");

            migrationBuilder.DropForeignKey(
                name: "FK_Trait_HumanAbilitiesViewModel_HumanAbilitiesViewModelHumanAbilities",
                table: "Trait");

            migrationBuilder.DropTable(
                name: "CharTraitHumanViewModel");

            migrationBuilder.DropTable(
                name: "HumanAbilitiesViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Trait_HumanAbilitiesViewModelHumanAbilities",
                table: "Trait");

            migrationBuilder.DropIndex(
                name: "IX_CharTrait_CharTraitHumanViewModelCharTrait",
                table: "CharTrait");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_AncestryBaseTraits_HumanAbilitiesViewModelHumanAbilities",
                table: "AncestryBaseTraits");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f5a43ae4-0f4d-4db6-988c-c1a3460438d7", "e9c409b4-79ce-46a5-823c-4695cf124e59" });

            migrationBuilder.DropColumn(
                name: "HumanAbilitiesViewModelHumanAbilities",
                table: "Trait");

            migrationBuilder.DropColumn(
                name: "CharTraitHumanViewModelCharTrait",
                table: "CharTrait");

            migrationBuilder.DropColumn(
                name: "HumanAbilitiesViewModelHumanAbilities",
                table: "AncestryBaseTraits");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de4882f6-b594-41c5-818b-73093346f575", 0, "311bc242-3a20-42fb-ac7e-b0a663bdcc2d", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEBJUYV/WoJC0uqqwvapmv7OW0O9IhGqpP0YzBl1wUxj2NSu/idStf/XKY2saR4HGsA==", null, false, "test", "0ab69b38-bab4-4100-85f3-84c53b0b8a33", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters",
                column: "ApplicationUserId");
        }
    }
}
