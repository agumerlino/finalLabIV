using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class inicial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Afiliados_afiliadoId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IdAfiliado",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "afiliadoId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Afiliados_afiliadoId",
                table: "Tickets",
                column: "afiliadoId",
                principalTable: "Afiliados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Afiliados_afiliadoId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "afiliadoId",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdAfiliado",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Afiliados_afiliadoId",
                table: "Tickets",
                column: "afiliadoId",
                principalTable: "Afiliados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
