using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalPrueba.Models
{
    public class TicketDetalle
    {
        public int Id { get; set; }

        public int IdTicket { get; set; }

        public string descripcionPedido { get; set; }

        public int estadoId { get; set; }

        public DateTime fechaEstado { get; set; }

        public Ticket? ticket { get; set; }

        public Estado? estado { get; set; }
    }
}
