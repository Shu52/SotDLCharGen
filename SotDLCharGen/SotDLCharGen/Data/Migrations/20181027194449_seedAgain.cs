using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Data.Migrations
{
    public partial class seedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "716a349a-7bd4-4b76-b9c2-427faf1eef2d", "82a26a87-0c8b-40c8-978d-e09af48eaa3f" });

            migrationBuilder.InsertData(
                table: "Ancestry",
                columns: new[] { "AncestryId", "AncestryName" },
                values: new object[] { 1, "Human" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "97e9207e-9fd9-4cf5-b7e7-722aef313200", 0, "91eab135-2652-4e3c-a0cc-9090f4ae2f56", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEM7gcH1gJvbxmRhsxhNz+2rYKCk5J1xMz15OfbpoD1hGWEt5PpcILBX5mqmHdHa/Sw==", null, false, "test", "3a24ef91-06c8-4f7e-918f-68977c3c084e", false, null });

            migrationBuilder.InsertData(
                table: "Trait",
                columns: new[] { "TraitId", "TraitName" },
                values: new object[,]
                {
                    { 1, "Strength" },
                    { 2, "Agility" },
                    { 3, "Intellect" },
                    { 4, "Will" }
                });

            migrationBuilder.InsertData(
                table: "AncestryBaseTraits",
                columns: new[] { "AncestryBaseTraitId", "AncestryId", "BaseValue", "TraitId" },
                values: new object[,]
                {
                    { 1, 1, "10", 1 },
                    { 2, 1, "10", 2 },
                    { 3, 1, "10", 3 },
                    { 4, 1, "10", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "97e9207e-9fd9-4cf5-b7e7-722aef313200", "91eab135-2652-4e3c-a0cc-9090f4ae2f56" });

            migrationBuilder.DeleteData(
                table: "Ancestry",
                keyColumn: "AncestryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trait",
                keyColumn: "TraitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trait",
                keyColumn: "TraitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trait",
                keyColumn: "TraitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trait",
                keyColumn: "TraitId",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "716a349a-7bd4-4b76-b9c2-427faf1eef2d", 0, "82a26a87-0c8b-40c8-978d-e09af48eaa3f", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAELqKFWZjOEExTvwDwsZ389kxhOUu0kpkgD4JuMBqQ/dp3vcvdG5HDJUJ8KasRVYmQw==", null, false, "test", "1854645e-25a9-408f-9284-e4bfda3717ef", false, null });
        }
    }
}
