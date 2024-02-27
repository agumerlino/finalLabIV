using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class cambioModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "resolucion",
                table: "Estados");

            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Estados",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
