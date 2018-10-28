using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Data.Migrations
{
    public partial class becauseItToldMeTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "97e9207e-9fd9-4cf5-b7e7-722aef313200", "91eab135-2652-4e3c-a0cc-9090f4ae2f56" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "de4882f6-b594-41c5-818b-73093346f575", 0, "311bc242-3a20-42fb-ac7e-b0a663bdcc2d", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEBJUYV/WoJC0uqqwvapmv7OW0O9IhGqpP0YzBl1wUxj2NSu/idStf/XKY2saR4HGsA==", null, false, "test", "0ab69b38-bab4-4100-85f3-84c53b0b8a33", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "de4882f6-b594-41c5-818b-73093346f575", "311bc242-3a20-42fb-ac7e-b0a663bdcc2d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "97e9207e-9fd9-4cf5-b7e7-722aef313200", 0, "91eab135-2652-4e3c-a0cc-9090f4ae2f56", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEM7gcH1gJvbxmRhsxhNz+2rYKCk5J1xMz15OfbpoD1hGWEt5PpcILBX5mqmHdHa/Sw==", null, false, "test", "3a24ef91-06c8-4f7e-918f-68977c3c084e", false, null });
        }
    }
}
