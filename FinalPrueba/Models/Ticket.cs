using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FinalPrueba.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [DisplayName("Afiliado")]
        public int afiliadoId { get; set; }

        [DisplayName("Fecha de Solicitud")]
        public DateTime fechaSolicitud { get; set; }

        [DisplayName("Observacion")]
        public string observacion { get; set; }

        public Afiliado? afiliado { get; set; }

        public ICollection<TicketDetalle> ticketDetalle { get; set; }

        
    }
}
