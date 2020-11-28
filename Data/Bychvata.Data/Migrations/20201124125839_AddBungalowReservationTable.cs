using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class AddBungalowReservationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bungalows_Reservations_ReservationId",
                table: "Bungalows");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Bungalows_BungalowId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BungalowId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Bungalows_ReservationId",
                table: "Bungalows");

            migrationBuilder.DropColumn(
                name: "BungalowId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Bungalows");

            migrationBuilder.CreateTable(
                name: "BungalowReservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BungalowId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BungalowReservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BungalowReservation_Bungalows_BungalowId",
                        column: x => x.BungalowId,
                        principalTable: "Bungalows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BungalowReservation_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BungalowReservation_BungalowId",
                table: "BungalowReservation",
                column: "BungalowId");

            migrationBuilder.CreateIndex(
                name: "IX_BungalowReservation_IsDeleted",
                table: "BungalowReservation",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BungalowReservation_ReservationId",
                table: "BungalowReservation",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BungalowReservation");

            migrationBuilder.AddColumn<int>(
                name: "BungalowId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Bungalows",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BungalowId",
                table: "Reservations",
                column: "BungalowId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Bungalows_BungalowId",
                table: "Reservations",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
