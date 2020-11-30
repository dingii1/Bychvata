using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class RemoveForeignKeyToPriceInBungalow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Bungalows_BungalowId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_Prices_BungalowId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "BungalowId",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Prices");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountPercent",
                table: "Prices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DiscountPercent",
                table: "Prices",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "BungalowId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Prices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Prices_BungalowId",
                table: "Prices",
                column: "BungalowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Bungalows_BungalowId",
                table: "Prices",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
