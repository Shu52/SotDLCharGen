using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Migrations
{
    public partial class clockwork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "af5f8233-c772-4618-962a-1faa784ff43c", "1d091f61-72af-4dec-ad91-76a19a76165c" });

            migrationBuilder.InsertData(
                table: "Ancestry",
                columns: new[] { "AncestryId", "AncestryName" },
                values: new object[] { 3, "Clockwork" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f04d196c-6e49-4634-b192-3ff4c3758981", 0, "79a6308b-e04f-4115-889d-ce2ccd7ab1f3", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAECAbXwfvA9GxWprImfabM0XvI3+LSKHNHdxB/kIxyUEEG46OCTBhmaLIqITF0PiFGw==", null, false, "test", "e79a900b-f2c6-48b8-a8c4-94b75a0f71f5", false, "test" });

            migrationBuilder.InsertData(
                table: "AncestryBaseTraits",
                columns: new[] { "AncestryBaseTraitId", "AncestryId", "BaseValue", "TraitId" },
                values: new object[,]
                {
                    { 9, 3, "9", 1 },
                    { 10, 3, "8", 2 },
                    { 11, 3, "9", 3 },
                    { 12, 3, "9", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f04d196c-6e49-4634-b192-3ff4c3758981", "79a6308b-e04f-4115-889d-ce2ccd7ab1f3" });

            migrationBuilder.DeleteData(
                table: "Ancestry",
                keyColumn: "AncestryId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af5f8233-c772-4618-962a-1faa784ff43c", 0, "1d091f61-72af-4dec-ad91-76a19a76165c", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEOawIuyUYcbeTdTUFgJIM4//p3idFxUJVzuY1XzM2r8szVJmOYKkENavQxghcCoHCQ==", null, false, "test", "95a7a25b-7390-4409-9a59-b208fe240daf", false, "test" });
        }
    }
}
