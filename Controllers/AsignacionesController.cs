using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCatalanaWeb.Data;
using LaCatalanaWeb.Models;

namespace LaCatalanaWeb.Controllers
{
    public class AsignacionesController : Controller
    {
        private readonly GEAContext _context;

        public AsignacionesController(GEAContext context)
        {
            _context = context;
        }

        // GET: Asignaciones
        public async Task<IActionResult> Index()
        {
            var gEAContext = _context.Asignaciones.Include(a => a.EmpleadoNavigation).Include(a => a.TipoProcesoNavigation);
            return View(await gEAContext.ToListAsync());
        }

        // GET: Asignaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacione = await _context.Asignaciones
                .Include(a => a.EmpleadoNavigation)
                .Include(a => a.TipoProcesoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacione == null)
            {
                return NotFound();
            }

            return View(asignacione);
        }

        // GET: Asignaciones/Create
        public IActionResult Create()
        {
            ViewData["Empleado"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado");
            ViewData["TipoProceso"] = new SelectList(_context.Procesos, "IdTipo", "NombreProceso");
            return View();
        }

        // POST: Asignaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,FechaAsignacion,Descripcion,TipoProceso,Empleado,EmpleadoAnterior,DetallesAsignaciones,UrlQr")] Asignacione asignacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Empleado"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", asignacione.Empleado);
            ViewData["TipoProceso"] = new SelectList(_context.Procesos, "IdTipo", "NombreProceso", asignacione.TipoProceso);
            return View(asignacione);
        }

        // GET: Asignaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacione = await _context.Asignaciones.FindAsync(id);
            if (asignacione == null)
            {
                return NotFound();
            }
            ViewData["Empleado"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", asignacione.Empleado);
            ViewData["TipoProceso"] = new SelectList(_context.Procesos, "IdTipo", "NombreProceso", asignacione.TipoProceso);
            return View(asignacione);
        }

        // POST: Asignaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,FechaAsignacion,Descripcion,TipoProceso,Empleado,EmpleadoAnterior,DetallesAsignaciones,UrlQr")] Asignacione asignacione)
        {
            if (id != asignacione.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacioneExists(asignacione.IdAsignacion))
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
            ViewData["Empleado"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", asignacione.Empleado);
            ViewData["TipoProceso"] = new SelectList(_context.Procesos, "IdTipo", "NombreProceso", asignacione.TipoProceso);
            return View(asignacione);
        }

        // GET: Asignaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacione = await _context.Asignaciones
                .Include(a => a.EmpleadoNavigation)
                .Include(a => a.TipoProcesoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacione == null)
            {
                return NotFound();
            }

            return View(asignacione);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacione = await _context.Asignaciones.FindAsync(id);
            _context.Asignaciones.Remove(asignacione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacioneExists(int id)
        {
            return _context.Asignaciones.Any(e => e.IdAsignacion == id);
        }
    }
}
