using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class cambiomodelo9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketDetalles_ticketId",
                table: "TicketDetalles");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetalles_ticketId",
                table: "TicketDetalles",
                column: "ticketId");
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
