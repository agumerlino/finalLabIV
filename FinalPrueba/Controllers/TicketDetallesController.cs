using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalPrueba.Data;
using FinalPrueba.Models;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace FinalPrueba.Controllers
{
    public class TicketDetallesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketDetallesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketDetalles
        
        public async Task<IActionResult> Index(int? page)
        {
            var appDbContext = _context.TicketDetalles
                .AsQueryable()
                .Include(t => t.estado)
                .Include(t => t.ticket)
                .ThenInclude(t => t.afiliado);

            int pageNumber = page ?? 1;
            int pageSize = 4;

            IPagedList<TicketDetalle> detallesPaginados = await appDbContext.ToPagedListAsync(pageNumber, pageSize);

            return View(detallesPaginados);
        }

        // GET: TicketDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketDetalle = await _context.TicketDetalles
                .Include(t => t.estado)
                .Include(t => t.ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketDetalle == null)
            {
                return NotFound();
            }

            return View(ticketDetalle);
        }

        // GET: TicketDetalles/Create
        [Authorize]
        public IActionResult Create()
        {
         
            ViewData["IdTicket"] = new SelectList(_context.Set<Ticket>(), "Id", "Id");
            ViewData["estadoId"] = new SelectList(_context.Estados, "Id", "descripcion");
            return View();
        }

        // POST: TicketDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdTicket,descripcionPedido,estadoId,fechaEstado")] TicketDetalle ticketDetalles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketDetalles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTicket"] = new SelectList(_context.Set<Ticket>(), "Id", "Id", ticketDetalles.ticket.Id);
            ViewData["estadoId"] = new SelectList(_context.Estados, "Id", "Id", ticketDetalles.estadoId);

            return View(ticketDetalles);
        }

        // GET: TicketDetalles/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketDetalle = await _context.TicketDetalles.FindAsync(id);
            if (ticketDetalle == null)
            {
                return NotFound();
            }
            

            ViewData["IdTicket"] = new SelectList(_context.Set<Ticket>(), "Id", "Id");
            ViewData["estadoId"] = new SelectList(_context.Estados, "Id", "descripcion");
            return View(ticketDetalle);
        }

        // POST: TicketDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdTicket,descripcionPedido,estadoId,fechaEstado")] TicketDetalle ticketDetalle)
        {
            if (id != ticketDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketDetalleExists(ticketDetalle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticketDetalle);
        }

        // GET: TicketDetalles/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketDetalle = await _context.TicketDetalles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketDetalle == null)
            {
                return NotFound();
            }

            return View(ticketDetalle);
        }

        // POST: TicketDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketDetalle = await _context.TicketDetalles.FindAsync(id);
            _context.TicketDetalles.Remove(ticketDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketDetalleExists(int id)
        {
            return _context.TicketDetalles.Any(e => e.Id == id);
        }

        public async Task<IActionResult> DetallesPorTicket(int id)
        {
            List<TicketDetalle> detallesPorTicket = await _context.TicketDetalles
                .Include(t => t.estado)
                .Where(td => td.IdTicket == id)
                .ToListAsync();

            return View(detallesPorTicket);
        }
    }
}
