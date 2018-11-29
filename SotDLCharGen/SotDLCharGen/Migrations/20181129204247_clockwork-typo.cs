using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Migrations
{
    public partial class clockworktypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clockworkPurposes_Ancestry_AncestryId",
                table: "clockworkPurposes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clockworkPurposes",
                table: "clockworkPurposes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "70ad08b7-6893-4ea3-8949-a8ffb64ba827", "4edbef87-0648-48eb-b1bb-2edf840937f4" });

            migrationBuilder.RenameTable(
                name: "clockworkPurposes",
                newName: "ClockworkPurposes");

            migrationBuilder.RenameIndex(
                name: "IX_clockworkPurposes_AncestryId",
                table: "ClockworkPurposes",
                newName: "IX_ClockworkPurposes_AncestryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClockworkPurposes",
                table: "ClockworkPurposes",
                column: "ClockworkPurposeId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da5cbfa2-1ed0-4e65-a78e-213f4954e3e3", 0, "b5a37615-e288-4728-883e-19c8882476a9", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEPGYG6BkZSIJ9HCYIKYdaxihnTo1YKO1ol2a/yxU2Dvc1f1RpYuJr0qRce4vn6dV1w==", null, false, "test", "dd2c332a-495a-4a1b-b105-ef9ccc3b4640", false, "test" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClockworkPurposes_Ancestry_AncestryId",
                table: "ClockworkPurposes",
                column: "AncestryId",
                principalTable: "Ancestry",
                principalColumn: "AncestryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClockworkPurposes_Ancestry_AncestryId",
                table: "ClockworkPurposes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClockworkPurposes",
                table: "ClockworkPurposes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "da5cbfa2-1ed0-4e65-a78e-213f4954e3e3", "b5a37615-e288-4728-883e-19c8882476a9" });

            migrationBuilder.RenameTable(
                name: "ClockworkPurposes",
                newName: "clockworkPurposes");

            migrationBuilder.RenameIndex(
                name: "IX_ClockworkPurposes_AncestryId",
                table: "clockworkPurposes",
                newName: "IX_clockworkPurposes_AncestryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clockworkPurposes",
                table: "clockworkPurposes",
                column: "ClockworkPurposeId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "70ad08b7-6893-4ea3-8949-a8ffb64ba827", 0, "4edbef87-0648-48eb-b1bb-2edf840937f4", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEJlktN41KODKz7/Y+/TxS8urfaA5gs78rvkB3f/8f6ZkrfE/hfxbVbGx5dFnXpP9IQ==", null, false, "test", "e318843c-90d1-4603-a1b7-819f6c484db6", false, "test" });

            migrationBuilder.AddForeignKey(
                name: "FK_clockworkPurposes_Ancestry_AncestryId",
                table: "clockworkPurposes",
                column: "AncestryId",
                principalTable: "Ancestry",
                principalColumn: "AncestryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
