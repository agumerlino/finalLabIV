using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class cambiofinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles");

            migrationBuilder.DropIndex(
                name: "IX_TicketDetalles_ticketId",
                table: "TicketDetalles");

            migrationBuilder.RenameColumn(
                name: "ticketId",
                table: "TicketDetalles",
                newName: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetalles_TicketId",
                table: "TicketDetalles",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Tickets_TicketId",
                table: "TicketDetalles",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Tickets_TicketId",
                table: "TicketDetalles");

            migrationBuilder.DropIndex(
                name: "IX_TicketDetalles_TicketId",
                table: "TicketDetalles");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "TicketDetalles",
                newName: "ticketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetalles_ticketId",
                table: "TicketDetalles",
                column: "ticketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
