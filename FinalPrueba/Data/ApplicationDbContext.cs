using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using FinalPrueba.Models;

namespace FinalPrueba.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FinalPrueba.Models.Afiliado> Afiliados { get; set; }
        public DbSet<FinalPrueba.Models.Estado> Estados { get; set; }
        public DbSet<FinalPrueba.Models.TicketDetalle> TicketDetalles { get; set; }
        public DbSet<FinalPrueba.Models.Ticket> Tickets { get; set; }
    }
}
