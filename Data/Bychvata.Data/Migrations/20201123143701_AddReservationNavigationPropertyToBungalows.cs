using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class AddReservationNavigationPropertyToBungalows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Bungalows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Bungalows",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Bungalows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Bungalows",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Bungalows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bungalows_IsDeleted",
                table: "Bungalows",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Bungalows_ReservationId",
                table: "Bungalows",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bungalows_Reservations_ReservationId",
                table: "Bungalows",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bungalows_Reservations_ReservationId",
                table: "Bungalows");

            migrationBuilder.DropIndex(
                name: "IX_Bungalows_IsDeleted",
                table: "Bungalows");

            migrationBuilder.DropIndex(
                name: "IX_Bungalows_ReservationId",
                table: "Bungalows");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Bungalows");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Bungalows");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Bungalows");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Bungalows");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Bungalows");
        }
    }
}
