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
    public class AsignacionEquipoDetallesController : Controller
    {
        private readonly GEAContext _context;

        public AsignacionEquipoDetallesController(GEAContext context)
        {
            _context = context;
        }

        // GET: AsignacionEquipoDetalles
        public async Task<IActionResult> Index()
        {
            var gEAContext = _context.AsignacionEquipoDetalles.Include(a => a.IdAsignacionNavigation).Include(a => a.IdEquipoNavigation);
            return View(await gEAContext.ToListAsync());
        }

        // GET: AsignacionEquipoDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionEquipoDetalle = await _context.AsignacionEquipoDetalles
                .Include(a => a.IdAsignacionNavigation)
                .Include(a => a.IdEquipoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleAe == id);
            if (asignacionEquipoDetalle == null)
            {
                return NotFound();
            }

            return View(asignacionEquipoDetalle);
        }

        // GET: AsignacionEquipoDetalles/Create
        public IActionResult Create()
        {
            ViewData["IdAsignacion"] = new SelectList(_context.Asignaciones, "IdAsignacion", "Descripcion");
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion");
            return View();
        }

        // POST: AsignacionEquipoDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleAe,IdAsignacion,IdEquipo")] AsignacionEquipoDetalle asignacionEquipoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionEquipoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAsignacion"] = new SelectList(_context.Asignaciones, "IdAsignacion", "Descripcion", asignacionEquipoDetalle.IdAsignacion);
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion", asignacionEquipoDetalle.IdEquipo);
            return View(asignacionEquipoDetalle);
        }

        // GET: AsignacionEquipoDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionEquipoDetalle = await _context.AsignacionEquipoDetalles.FindAsync(id);
            if (asignacionEquipoDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdAsignacion"] = new SelectList(_context.Asignaciones, "IdAsignacion", "Descripcion", asignacionEquipoDetalle.IdAsignacion);
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion", asignacionEquipoDetalle.IdEquipo);
            return View(asignacionEquipoDetalle);
        }

        // POST: AsignacionEquipoDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleAe,IdAsignacion,IdEquipo")] AsignacionEquipoDetalle asignacionEquipoDetalle)
        {
            if (id != asignacionEquipoDetalle.IdDetalleAe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionEquipoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionEquipoDetalleExists(asignacionEquipoDetalle.IdDetalleAe))
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
            ViewData["IdAsignacion"] = new SelectList(_context.Asignaciones, "IdAsignacion", "Descripcion", asignacionEquipoDetalle.IdAsignacion);
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion", asignacionEquipoDetalle.IdEquipo);
            return View(asignacionEquipoDetalle);
        }

        // GET: AsignacionEquipoDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionEquipoDetalle = await _context.AsignacionEquipoDetalles
                .Include(a => a.IdAsignacionNavigation)
                .Include(a => a.IdEquipoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleAe == id);
            if (asignacionEquipoDetalle == null)
            {
                return NotFound();
            }

            return View(asignacionEquipoDetalle);
        }

        // POST: AsignacionEquipoDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacionEquipoDetalle = await _context.AsignacionEquipoDetalles.FindAsync(id);
            _context.AsignacionEquipoDetalles.Remove(asignacionEquipoDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionEquipoDetalleExists(int id)
        {
            return _context.AsignacionEquipoDetalles.Any(e => e.IdDetalleAe == id);
        }
    }
}
