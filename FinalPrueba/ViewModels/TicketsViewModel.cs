using FinalPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FinalPrueba.ViewModels
{
    public class TicketsViewModel
    {
        public IPagedList<Ticket> Tickets  { get; set; }

        public DateTime fechaSolicitud { get; set; }
    }
}
