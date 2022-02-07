using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftwareAPI.Database.Migrations
{
    public partial class Make_TypeId_In_Utility_Model_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilities_Types_TypeId",
                table: "Utilities");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Utilities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilities_Types_TypeId",
                table: "Utilities",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilities_Types_TypeId",
                table: "Utilities");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "Utilities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utilities_Types_TypeId",
                table: "Utilities",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
