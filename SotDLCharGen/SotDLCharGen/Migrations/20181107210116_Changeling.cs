using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Migrations
{
    public partial class Changeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9a992415-1167-47c0-b54d-503d1162147c", "bef300bf-3212-4194-a53a-c61f40fbd13e" });

            migrationBuilder.InsertData(
                table: "Ancestry",
                columns: new[] { "AncestryId", "AncestryName" },
                values: new object[] { 2, "Changeling" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af5f8233-c772-4618-962a-1faa784ff43c", 0, "1d091f61-72af-4dec-ad91-76a19a76165c", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEOawIuyUYcbeTdTUFgJIM4//p3idFxUJVzuY1XzM2r8szVJmOYKkENavQxghcCoHCQ==", null, false, "test", "95a7a25b-7390-4409-9a59-b208fe240daf", false, "test" });

            migrationBuilder.InsertData(
                table: "AncestryBaseTraits",
                columns: new[] { "AncestryBaseTraitId", "AncestryId", "BaseValue", "TraitId" },
                values: new object[,]
                {
                    { 5, 2, "9", 1 },
                    { 6, 2, "10", 2 },
                    { 7, 2, "10", 3 },
                    { 8, 2, "10", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AncestryBaseTraits",
                keyColumn: "AncestryBaseTraitId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "af5f8233-c772-4618-962a-1faa784ff43c", "1d091f61-72af-4dec-ad91-76a19a76165c" });

            migrationBuilder.DeleteData(
                table: "Ancestry",
                keyColumn: "AncestryId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9a992415-1167-47c0-b54d-503d1162147c", 0, "bef300bf-3212-4194-a53a-c61f40fbd13e", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEOqnZ5wfnKr+9j7Oxp+X1Mogp2d0LiOcrYn4WX/FCRYLSTdzptkGdaZU+EAEbEpy0w==", null, false, "test", "e9042db2-8b63-4410-9dcc-0364bdd274b2", false, "test" });
        }
    }
}
