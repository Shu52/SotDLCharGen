using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Migrations
{
    public partial class Dwarf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f04d196c-6e49-4634-b192-3ff4c3758981", "79a6308b-e04f-4115-889d-ce2ccd7ab1f3" });

            migrationBuilder.InsertData(
                table: "Ancestry",
                columns: new[] { "AncestryId", "AncestryName" },
                values: new object[] { 4, "Dwarf" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ded24f9f-bcf5-4650-9880-f77c36194fab", 0, "972496e0-2b34-4832-8ff3-be019dc86a03", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAELzjQt+iZI7qwV2kgowJ7DNL1sxFbefWi+drFD8OC84DaG1SxA3OpSW6rEb6xHiQ3A==", null, false, "test", "c83d82ce-2010-4645-8694-8435de2fb99d", false, "test" });

            migrationBuilder.InsertData(
                table: "AncestryBaseTraits",
                columns: new[] { "AncestryBaseTraitId", "AncestryId", "BaseValue", "TraitId" },
                values: new object[,]
                {
                    { 13, 4, "10", 1 },
                    { 14, 4, "9", 2 },
                    { 15, 4, "10", 3 },
                    { 16, 4, "10", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ded24f9f-bcf5-4650-9880-f77c36194fab", "972496e0-2b34-4832-8ff3-be019dc86a03" });

            migrationBuilder.DeleteData(
                table: "Ancestry",
                keyColumn: "AncestryId",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f04d196c-6e49-4634-b192-3ff4c3758981", 0, "79a6308b-e04f-4115-889d-ce2ccd7ab1f3", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAECAbXwfvA9GxWprImfabM0XvI3+LSKHNHdxB/kIxyUEEG46OCTBhmaLIqITF0PiFGw==", null, false, "test", "e79a900b-f2c6-48b8-a8c4-94b75a0f71f5", false, "test" });
        }
    }
}
