using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Migrations
{
    public partial class goblinsandorcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ded24f9f-bcf5-4650-9880-f77c36194fab", "972496e0-2b34-4832-8ff3-be019dc86a03" });

            migrationBuilder.InsertData(
                table: "Ancestry",
                columns: new[] { "AncestryId", "AncestryName" },
                values: new object[] { 5, "Goblin" });

            migrationBuilder.InsertData(
                table: "Ancestry",
                columns: new[] { "AncestryId", "AncestryName" },
                values: new object[] { 6, "Orc" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6408a7b5-e812-4f50-83ef-a663712e359e", 0, "548fd806-eb21-46f5-be27-1c56e574b5ad", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEChvNPtyxzQ/7f62jYflN7v82Aew1ishcrYlaFQtJk+egIGibWTGfjUvC+ORWOlnLg==", null, false, "test", "32173678-481e-4e61-afa0-cbfdcb4a2987", false, "test" });

            migrationBuilder.InsertData(
                table: "AncestryBaseTraits",
                columns: new[] { "AncestryBaseTraitId", "AncestryId", "BaseValue", "TraitId" },
                values: new object[,]
                {
                    { 17, 5, "8", 1 },
                    { 18, 5, "12", 2 },
                    { 19, 5, "10", 3 },
                    { 20, 5, "9", 4 },
                    { 21, 6, "11", 1 },
                    { 22, 6, "10", 2 },
                    { 23, 6, "9", 3 },
                    { 24, 6, "9", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6408a7b5-e812-4f50-83ef-a663712e359e", "548fd806-eb21-46f5-be27-1c56e574b5ad" });

            migrationBuilder.DeleteData(
                table: "Ancestry",
                keyColumn: "AncestryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ancestry",
                keyColumn: "AncestryId",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ded24f9f-bcf5-4650-9880-f77c36194fab", 0, "972496e0-2b34-4832-8ff3-be019dc86a03", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAELzjQt+iZI7qwV2kgowJ7DNL1sxFbefWi+drFD8OC84DaG1SxA3OpSW6rEb6xHiQ3A==", null, false, "test", "c83d82ce-2010-4645-8694-8435de2fb99d", false, "test" });
        }
    }
}
