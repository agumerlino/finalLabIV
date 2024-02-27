using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalPrueba.Data;
using FinalPrueba.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using FinalPrueba.ViewModels;
using OfficeOpenXml;
using System.Globalization;
using X.PagedList;

namespace FinalPrueba.Controllers
{
    public class AfiliadosController : Controller
    {
    
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;


        public AfiliadosController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Afiliados
        
        public async Task<IActionResult> Index(string busquedaApellido, int? busquedaDNI, int? page)
        {

            var appDBcontexto = _context.Afiliados.AsQueryable();
            if(!string.IsNullOrEmpty(busquedaApellido))
            {
                appDBcontexto = appDBcontexto.Where(a => a.apellido.Contains(busquedaApellido));
            }
            if(busquedaDNI.HasValue)
            {
                var dniString = busquedaDNI.Value.ToString();
                appDBcontexto = appDBcontexto.Where(a => a.dni.ToString().Contains(dniString.ToString()));

            }
            int dni = busquedaDNI ?? 0;
            int pageNumber = page ?? 1;
            int pageSize = 4;

            IPagedList<Afiliado> afiliadosPaginados = await appDBcontexto.ToPagedListAsync(pageNumber, pageSize);
            AfiliadosViewModel modelo = new AfiliadosViewModel()
            {
                Afiliados = afiliadosPaginados,
                apellido = busquedaApellido,
                dni = dni,
            };

            return View(modelo);
        }

        public async Task<IActionResult> Importar()
        {
            var archivos = HttpContext.Request.Form.Files;
            if (archivos != null && archivos.Count > 0)
            {
                var archivo = archivos[0];

                if (archivo.Length > 0)
                {
                    var pathDestino = Path.Combine(_env.WebRootPath, "importaciones");
                    var archivoDestino = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(archivo.FileName);

                    using (var filestream = new FileStream(Path.Combine(pathDestino, archivoDestino), FileMode.Create))
                    {
                        archivo.CopyTo(filestream);
                    }
                    using (var package = new ExcelPackage(new FileInfo(Path.Combine(pathDestino, archivoDestino))))
                    {
                        var hojaExcel = package.Workbook.Worksheets[0];
                        List<Afiliado> afiliadosArchivo = new List<Afiliado>();

                        int cantFilas = hojaExcel.Dimension.Rows;

                        for (int fila = 1; fila <= 3; fila++)
                        {

                            Afiliado afiliado = new Afiliado();
                            afiliado.nombre = hojaExcel.Cells[fila, 1].Value?.ToString();
                            afiliado.apellido = hojaExcel.Cells[fila, 2].Value?.ToString();
                            afiliado.dni = int.Parse(hojaExcel.Cells[fila, 3].Value?.ToString());
                            double valorNumeroExcel;
                            if (double.TryParse(hojaExcel.Cells[fila, 4].Value?.ToString(), out valorNumeroExcel))
                            {
                                afiliado.fechaNacimiento = DateTime.FromOADate(valorNumeroExcel);
                            }
                            afiliadosArchivo.Add(afiliado);


                        }
                        _context.Afiliados.AddRange(afiliadosArchivo);
                        await _context.SaveChangesAsync();
                    }

                }
                return RedirectToAction("Index");
            }
                return View("Index", await _context.Afiliados.ToListAsync());

         }
        // GET: Afiliados/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // GET: Afiliados/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Afiliados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nombre,apellido,dni,fechaNacimiento")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                var archivos = HttpContext.Request.Form.Files;
                if (archivos != null && archivos.Count > 0)
                {
                    var archivoFoto = archivos[0];
                   
                    if(archivoFoto.Length > 0)
                    {
                        var pathDestino = Path.Combine(_env.WebRootPath, "images\\afiliados");
                        var archivoDestino = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(archivoFoto.FileName);

                        using (var filestream = new FileStream(Path.Combine(pathDestino, archivoDestino), FileMode.Create))
                        {
                            archivoFoto.CopyTo(filestream);
                            afiliado.foto = archivoDestino;
                        }
                    }
                }
                _context.Add(afiliado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(afiliado);
        }

        // GET: Afiliados/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nombre,apellido,dni,fechaNacimiento,foto")] Afiliado afiliado)
        {
            if (id != afiliado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var archivos = HttpContext.Request.Form.Files;
                if (archivos != null && archivos.Count > 0)
                {
                    var archivoFoto = archivos[0];

                    if (archivoFoto.Length > 0)
                    {
                        var pathDestino = Path.Combine(_env.WebRootPath, "images\\afiliados");
                        var archivoDestino = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(archivoFoto.FileName);
                        var rutaDestino = Path.Combine(pathDestino, archivoDestino);
                        if (!string.IsNullOrEmpty(afiliado.foto))
                        {
                            string fotoAnterior = Path.Combine(pathDestino, afiliado.foto);
                            if (System.IO.File.Exists(fotoAnterior))
                                System.IO.File.Delete(fotoAnterior);
                        }
                            using (var filestream = new FileStream(rutaDestino, FileMode.Create))
                            {
                                archivoFoto.CopyTo(filestream);
                                afiliado.foto = archivoDestino;
                            };
                        
                    }
                }
                try
                {
                    _context.Update(afiliado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfiliadoExists(afiliado.Id))
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
            return View(afiliado);
        }

        // GET: Afiliados/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // POST: Afiliados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afiliado = await _context.Afiliados.FindAsync(id);
            _context.Afiliados.Remove(afiliado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfiliadoExists(int id)
        {
            return _context.Afiliados.Any(e => e.Id == id);
        }
    }
}
