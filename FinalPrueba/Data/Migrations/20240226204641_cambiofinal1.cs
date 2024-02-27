using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class cambiofinal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Tickets_TicketId",
                table: "TicketDetalles");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "TicketDetalles",
                newName: "ticketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetalles_TicketId",
                table: "TicketDetalles",
                newName: "IX_TicketDetalles_ticketId");

            migrationBuilder.AlterColumn<int>(
                name: "ticketId",
                table: "TicketDetalles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdTicket",
                table: "TicketDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles");

            migrationBuilder.DropColumn(
                name: "IdTicket",
                table: "TicketDetalles");

            migrationBuilder.RenameColumn(
                name: "ticketId",
                table: "TicketDetalles",
                newName: "TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetalles_ticketId",
                table: "TicketDetalles",
                newName: "IX_TicketDetalles_TicketId");

            migrationBuilder.AlterColumn<int>(
                name: "TicketId",
                table: "TicketDetalles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalles_Tickets_TicketId",
                table: "TicketDetalles",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
