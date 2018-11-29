using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SotDLCharGen.Migrations
{
    public partial class clockworkpurpose : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6408a7b5-e812-4f50-83ef-a663712e359e", "548fd806-eb21-46f5-be27-1c56e574b5ad" });

            migrationBuilder.CreateTable(
                name: "clockworkPurposes",
                columns: table => new
                {
                    ClockworkPurposeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClockworkPurposeValue = table.Column<string>(nullable: true),
                    AncestryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clockworkPurposes", x => x.ClockworkPurposeId);
                    table.ForeignKey(
                        name: "FK_clockworkPurposes_Ancestry_AncestryId",
                        column: x => x.AncestryId,
                        principalTable: "Ancestry",
                        principalColumn: "AncestryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "70ad08b7-6893-4ea3-8949-a8ffb64ba827", 0, "4edbef87-0648-48eb-b1bb-2edf840937f4", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEJlktN41KODKz7/Y+/TxS8urfaA5gs78rvkB3f/8f6ZkrfE/hfxbVbGx5dFnXpP9IQ==", null, false, "test", "e318843c-90d1-4603-a1b7-819f6c484db6", false, "test" });

            migrationBuilder.InsertData(
                table: "clockworkPurposes",
                columns: new[] { "ClockworkPurposeId", "AncestryId", "ClockworkPurposeValue" },
                values: new object[,]
                {
                    { 1, null, "You were built for war. Increase your Strength or Agility by 2" },
                    { 2, null, "You were built to work. Increase your Strength by 2" },
                    { 3, null, "You were built to use magic. Increase your Intellect or Will by 2" },
                    { 4, null, "You were built to gather intelligence about or assassinate targets.Increase your Agility or Intellect by 2" },
                    { 5, null, "You were built for an inexplicable purpose. Increase one attribute of your choice by 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_clockworkPurposes_AncestryId",
                table: "clockworkPurposes",
                column: "AncestryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clockworkPurposes");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "70ad08b7-6893-4ea3-8949-a8ffb64ba827", "4edbef87-0648-48eb-b1bb-2edf840937f4" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6408a7b5-e812-4f50-83ef-a663712e359e", 0, "548fd806-eb21-46f5-be27-1c56e574b5ad", "test@test.com", true, false, null, "TEST@TEST.COM", null, "AQAAAAEAACcQAAAAEChvNPtyxzQ/7f62jYflN7v82Aew1ishcrYlaFQtJk+egIGibWTGfjUvC+ORWOlnLg==", null, false, "test", "32173678-481e-4e61-afa0-cbfdcb4a2987", false, "test" });
        }
    }
}
