using FinalPrueba.Data;
using FinalPrueba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace FinalPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {

            int pageNumber = page ?? 1;
            int pageSize = 4;

            var idtickets = await _context.TicketDetalles
                .Where(td => !td.estado.resolucion)
                .Select(td => td.IdTicket)
                .Distinct()
                .ToListAsync();

            var ticketsPendientes = await _context.Tickets
            .Where(t => idtickets.Contains(t.Id))
            .Include(t => t.afiliado)// Incluir datos relacionados si es necesario
            .OrderBy(t => t.fechaSolicitud)
            .ToPagedListAsync(pageNumber, pageSize);

            
            

            return View(ticketsPendientes);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
