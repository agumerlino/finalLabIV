using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalPrueba.Data.Migrations
{
    public partial class inicial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Afiliado_afiliadoId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalle_Estado_estadoId",
                table: "TicketDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalle_Ticket_ticketId",
                table: "TicketDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDetalle",
                table: "TicketDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Afiliado",
                table: "Afiliado");

            migrationBuilder.RenameTable(
                name: "TicketDetalle",
                newName: "TicketDetalles");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "Estados");

            migrationBuilder.RenameTable(
                name: "Afiliado",
                newName: "Afiliados");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetalle_ticketId",
                table: "TicketDetalles",
                newName: "IX_TicketDetalles_ticketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetalle_estadoId",
                table: "TicketDetalles",
                newName: "IX_TicketDetalles_estadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Ticket_afiliadoId",
                table: "Tickets",
                newName: "IX_Tickets_afiliadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDetalles",
                table: "TicketDetalles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estados",
                table: "Estados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Afiliados",
                table: "Afiliados",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Afiliados_afiliadoId",
                table: "Tickets",
                column: "afiliadoId",
                principalTable: "Afiliados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Estados_estadoId",
                table: "TicketDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetalles_Tickets_ticketId",
                table: "TicketDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Afiliados_afiliadoId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketDetalles",
                table: "TicketDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estados",
                table: "Estados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Afiliados",
                table: "Afiliados");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "TicketDetalles",
                newName: "TicketDetalle");

            migrationBuilder.RenameTable(
                name: "Estados",
                newName: "Estado");

            migrationBuilder.RenameTable(
                name: "Afiliados",
                newName: "Afiliado");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_afiliadoId",
                table: "Ticket",
                newName: "IX_Ticket_afiliadoId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetalles_ticketId",
                table: "TicketDetalle",
                newName: "IX_TicketDetalle_ticketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketDetalles_estadoId",
                table: "TicketDetalle",
                newName: "IX_TicketDetalle_estadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketDetalle",
                table: "TicketDetalle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Afiliado",
                table: "Afiliado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Afiliado_afiliadoId",
                table: "Ticket",
                column: "afiliadoId",
                principalTable: "Afiliado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalle_Estado_estadoId",
                table: "TicketDetalle",
                column: "estadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetalle_Ticket_ticketId",
                table: "TicketDetalle",
                column: "ticketId",
                principalTable: "Ticket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
