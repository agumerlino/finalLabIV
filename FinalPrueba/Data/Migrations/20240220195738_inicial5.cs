using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class inicial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Estados_estadoId",
                table: "TicketDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "TicketDetalles");

            migrationBuilder.DropColumn(
                name: "IdTicket",
                table: "TicketDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "ticketId",
                table: "TicketDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estadoId",
                table: "TicketDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Estados_estadoId",
                table: "TicketDetalles",
                column: "estadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Estados_estadoId",
                table: "TicketDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles");

            migrationBuilder.AlterColumn<int>(
                name: "ticketId",
                table: "TicketDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "estadoId",
                table: "TicketDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "TicketDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTicket",
                table: "TicketDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Estados_estadoId",
                table: "TicketDetalles",
                column: "estadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
