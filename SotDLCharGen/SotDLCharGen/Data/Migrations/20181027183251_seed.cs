using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Data.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerName",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "716a349a-7bd4-4b76-b9c2-427faf1eef2d", 0, "82a26a87-0c8b-40c8-978d-e09af48eaa3f", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAELqKFWZjOEExTvwDwsZ389kxhOUu0kpkgD4JuMBqQ/dp3vcvdG5HDJUJ8KasRVYmQw==", null, false, "test", "1854645e-25a9-408f-9284-e4bfda3717ef", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "716a349a-7bd4-4b76-b9c2-427faf1eef2d", "82a26a87-0c8b-40c8-978d-e09af48eaa3f" });

            migrationBuilder.AlterColumn<string>(
                name: "PlayerName",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
        }
    }
}
