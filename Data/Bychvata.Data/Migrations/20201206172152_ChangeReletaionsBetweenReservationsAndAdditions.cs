using Microsoft.EntityFrameworkCore.Migrations;

namespace Bychvata.Data.Migrations
{
    public partial class ChangeReletaionsBetweenReservationsAndAdditions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Additions_Reservations_ReservationId",
                table: "Additions");

            migrationBuilder.DropIndex(
                name: "IX_Additions_ReservationId",
                table: "Additions");

            migrationBuilder.CreateTable(
                name: "AdditionReservation",
                columns: table => new
                {
                    AdditionsId = table.Column<int>(type: "int", nullable: false),
                    ReservationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionReservation", x => new { x.AdditionsId, x.ReservationsId });
                    table.ForeignKey(
                        name: "FK_AdditionReservation_Additions_AdditionsId",
                        column: x => x.AdditionsId,
                        principalTable: "Additions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdditionReservation_Reservations_ReservationsId",
                        column: x => x.ReservationsId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionReservation_ReservationsId",
                table: "AdditionReservation",
                column: "ReservationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionReservation");

            migrationBuilder.CreateIndex(
                name: "IX_Additions_ReservationId",
                table: "Additions",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Additions_Reservations_ReservationId",
                table: "Additions",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
