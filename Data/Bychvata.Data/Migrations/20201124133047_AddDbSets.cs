using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class AddDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BungalowReservation_Bungalows_BungalowId",
                table: "BungalowReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_BungalowReservation_Reservations_ReservationId",
                table: "BungalowReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_DateAvailable_Bungalows_BungalowId",
                table: "DateAvailable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateAvailable",
                table: "DateAvailable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BungalowReservation",
                table: "BungalowReservation");

            migrationBuilder.RenameTable(
                name: "DateAvailable",
                newName: "DatesAvailable");

            migrationBuilder.RenameTable(
                name: "BungalowReservation",
                newName: "BungalowsReservations");

            migrationBuilder.RenameIndex(
                name: "IX_DateAvailable_IsDeleted",
                table: "DatesAvailable",
                newName: "IX_DatesAvailable_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_DateAvailable_BungalowId",
                table: "DatesAvailable",
                newName: "IX_DatesAvailable_BungalowId");

            migrationBuilder.RenameIndex(
                name: "IX_BungalowReservation_ReservationId",
                table: "BungalowsReservations",
                newName: "IX_BungalowsReservations_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_BungalowReservation_IsDeleted",
                table: "BungalowsReservations",
                newName: "IX_BungalowsReservations_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_BungalowReservation_BungalowId",
                table: "BungalowsReservations",
                newName: "IX_BungalowsReservations_BungalowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatesAvailable",
                table: "DatesAvailable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BungalowsReservations",
                table: "BungalowsReservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BungalowsReservations_Bungalows_BungalowId",
                table: "BungalowsReservations",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BungalowsReservations_Reservations_ReservationId",
                table: "BungalowsReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DatesAvailable_Bungalows_BungalowId",
                table: "DatesAvailable",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BungalowsReservations_Bungalows_BungalowId",
                table: "BungalowsReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_BungalowsReservations_Reservations_ReservationId",
                table: "BungalowsReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_DatesAvailable_Bungalows_BungalowId",
                table: "DatesAvailable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatesAvailable",
                table: "DatesAvailable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BungalowsReservations",
                table: "BungalowsReservations");

            migrationBuilder.RenameTable(
                name: "DatesAvailable",
                newName: "DateAvailable");

            migrationBuilder.RenameTable(
                name: "BungalowsReservations",
                newName: "BungalowReservation");

            migrationBuilder.RenameIndex(
                name: "IX_DatesAvailable_IsDeleted",
                table: "DateAvailable",
                newName: "IX_DateAvailable_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_DatesAvailable_BungalowId",
                table: "DateAvailable",
                newName: "IX_DateAvailable_BungalowId");

            migrationBuilder.RenameIndex(
                name: "IX_BungalowsReservations_ReservationId",
                table: "BungalowReservation",
                newName: "IX_BungalowReservation_ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_BungalowsReservations_IsDeleted",
                table: "BungalowReservation",
                newName: "IX_BungalowReservation_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_BungalowsReservations_BungalowId",
                table: "BungalowReservation",
                newName: "IX_BungalowReservation_BungalowId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateAvailable",
                table: "DateAvailable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BungalowReservation",
                table: "BungalowReservation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BungalowReservation_Bungalows_BungalowId",
                table: "BungalowReservation",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BungalowReservation_Reservations_ReservationId",
                table: "BungalowReservation",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DateAvailable_Bungalows_BungalowId",
                table: "DateAvailable",
                column: "BungalowId",
                principalTable: "Bungalows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
