using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class RemoveDeletableEntityFromReservationsAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions");

            migrationBuilder.DropIndex(
                name: "IX_ReservationAdditions_AdditionId",
                table: "ReservationAdditions");

            migrationBuilder.DropIndex(
                name: "IX_ReservationAdditions_IsDeleted",
                table: "ReservationAdditions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReservationAdditions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ReservationAdditions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ReservationAdditions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReservationAdditions");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ReservationAdditions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions",
                columns: new[] { "AdditionId", "ReservationId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReservationAdditions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ReservationAdditions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ReservationAdditions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReservationAdditions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ReservationAdditions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationAdditions_AdditionId",
                table: "ReservationAdditions",
                column: "AdditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationAdditions_IsDeleted",
                table: "ReservationAdditions",
                column: "IsDeleted");
        }
    }
}
