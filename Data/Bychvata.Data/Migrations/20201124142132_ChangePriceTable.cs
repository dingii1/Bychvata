using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class ChangePriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Additions_Bungalows_BungalowId",
                table: "Additions");

            migrationBuilder.DropIndex(
                name: "IX_Additions_BungalowId",
                table: "Additions");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "BungalowId",
                table: "Additions");

            migrationBuilder.RenameColumn(
                name: "To",
                table: "Prices",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Prices",
                newName: "To");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BungalowId",
                table: "Additions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Additions_BungalowId",
                table: "Additions",
                column: "BungalowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Additions_Bungalows_BungalowId",
                table: "Additions",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
