using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class cambiomodelofin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resolucion",
                table: "TicketDetalles");

            migrationBuilder.AddColumn<bool>(
                name: "resolucion",
                table: "Estados",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resolucion",
                table: "Estados");

            migrationBuilder.AddColumn<bool>(
                name: "resolucion",
                table: "TicketDetalles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
