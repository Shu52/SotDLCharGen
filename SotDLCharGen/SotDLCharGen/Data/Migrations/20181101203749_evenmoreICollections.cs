using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Data.Migrations
{
    public partial class evenmoreICollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c4641873-2727-4054-9b2e-a8990e3b309d", "66afd16d-c655-4f09-ac2a-b387cc4d89b4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c6c4db43-c7a1-4aa9-9d8f-185b997e4b1c", 0, "10d58ff8-4539-420c-b2fc-dd5dcb5e02ef", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEPbpdZ8C2TksLubJ4K+uJ5BPVonG5GtvMfqS9iB8Gkq0x4RMEXaMss9dK5A2kFVTOw==", null, false, "test", "0c87b393-3810-409b-a0c4-1d5d307f708f", false, "test" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c6c4db43-c7a1-4aa9-9d8f-185b997e4b1c", "10d58ff8-4539-420c-b2fc-dd5dcb5e02ef" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c4641873-2727-4054-9b2e-a8990e3b309d", 0, "66afd16d-c655-4f09-ac2a-b387cc4d89b4", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEMn6qHozU3fK5J2a7q8MUFqV+YUvdYIh5wkel9Feytloa0kEpG16spNLGVzWrGcyAA==", null, false, "test", "57dba13f-201e-4647-9ff5-a8ae72df789d", false, "test" });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");
        }
    }
}
