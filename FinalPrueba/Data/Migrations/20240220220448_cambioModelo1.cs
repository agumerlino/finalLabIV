using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class cambioModelo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resolucion",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "Estados");

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
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
