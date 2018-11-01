using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Data.Migrations
{
    public partial class moreIcollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f5a43ae4-0f4d-4db6-988c-c1a3460438d7", "e9c409b4-79ce-46a5-823c-4695cf124e59" });

            migrationBuilder.RenameColumn(
                name: "CharcTraitId",
                table: "CharTrait",
                newName: "CharTraitId");

            migrationBuilder.AddColumn<int>(
                name: "TraitsTraitId",
                table: "CharTraitHumanViewModel",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c4641873-2727-4054-9b2e-a8990e3b309d", 0, "66afd16d-c655-4f09-ac2a-b387cc4d89b4", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEMn6qHozU3fK5J2a7q8MUFqV+YUvdYIh5wkel9Feytloa0kEpG16spNLGVzWrGcyAA==", null, false, "test", "57dba13f-201e-4647-9ff5-a8ae72df789d", false, "test" });

            migrationBuilder.CreateIndex(
                name: "IX_CharTraitHumanViewModel_TraitsTraitId",
                table: "CharTraitHumanViewModel",
                column: "TraitsTraitId");

            migrationBuilder.AddForeignKey(
                name: "FK_CharTraitHumanViewModel_Trait_TraitsTraitId",
                table: "CharTraitHumanViewModel",
                column: "TraitsTraitId",
                principalTable: "Trait",
                principalColumn: "TraitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharTraitHumanViewModel_Trait_TraitsTraitId",
                table: "CharTraitHumanViewModel");

            migrationBuilder.DropIndex(
                name: "IX_CharTraitHumanViewModel_TraitsTraitId",
                table: "CharTraitHumanViewModel");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c4641873-2727-4054-9b2e-a8990e3b309d", "66afd16d-c655-4f09-ac2a-b387cc4d89b4" });

            migrationBuilder.DropColumn(
                name: "TraitsTraitId",
                table: "CharTraitHumanViewModel");

            migrationBuilder.RenameColumn(
                name: "CharTraitId",
                table: "CharTrait",
                newName: "CharcTraitId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f5a43ae4-0f4d-4db6-988c-c1a3460438d7", 0, "e9c409b4-79ce-46a5-823c-4695cf124e59", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEAz4hRO6U+xO/ig4xe0mcJ+1miyKJDMJT2ufH/ywEZO6DQnf8NAggcC9s9j0rKST3A==", null, false, "test", "15d4770f-7396-4af0-98fa-05616b9e64dc", false, "test" });
        }
    }
}
