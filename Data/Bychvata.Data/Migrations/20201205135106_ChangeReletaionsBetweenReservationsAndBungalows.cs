using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class ChangeReletaionsBetweenReservationsAndBungalows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BungalowsReservations");

            migrationBuilder.AddColumn<int>(
                name: "BungalowId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_BungalowId",
                table: "Reservations",
                column: "BungalowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Bungalows_BungalowId",
                table: "Reservations",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Bungalows_BungalowId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_BungalowId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BungalowId",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "BungalowsReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BungalowId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BungalowsReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BungalowsReservations_Bungalows_BungalowId",
                        column: x => x.BungalowId,
                        principalTable: "Bungalows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BungalowsReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BungalowsReservations_BungalowId",
                table: "BungalowsReservations",
                column: "BungalowId");

            migrationBuilder.CreateIndex(
                name: "IX_BungalowsReservations_IsDeleted",
                table: "BungalowsReservations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BungalowsReservations_ReservationId",
                table: "BungalowsReservations",
                column: "ReservationId");
        }
    }
}
