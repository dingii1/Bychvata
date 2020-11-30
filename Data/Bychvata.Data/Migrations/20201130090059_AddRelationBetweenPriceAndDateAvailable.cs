using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class AddRelationBetweenPriceAndDateAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "DatesAvailable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DatesAvailable_PriceId",
                table: "DatesAvailable",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DatesAvailable_Prices_PriceId",
                table: "DatesAvailable",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatesAvailable_Prices_PriceId",
                table: "DatesAvailable");

            migrationBuilder.DropIndex(
                name: "IX_DatesAvailable_PriceId",
                table: "DatesAvailable");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "DatesAvailable");
        }
    }
}
