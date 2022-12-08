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
    public class EstadoEquipoesController : Controller
    {
        private readonly GEAContext _context;

        public EstadoEquipoesController(GEAContext context)
        {
            _context = context;
        }

        // GET: EstadoEquipoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoEquipos.ToListAsync());
        }

        // GET: EstadoEquipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoEquipo = await _context.EstadoEquipos
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoEquipo == null)
            {
                return NotFound();
            }

            return View(estadoEquipo);
        }

        // GET: EstadoEquipoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoEquipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,NombreEstado")] EstadoEquipo estadoEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoEquipo);
        }

        // GET: EstadoEquipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoEquipo = await _context.EstadoEquipos.FindAsync(id);
            if (estadoEquipo == null)
            {
                return NotFound();
            }
            return View(estadoEquipo);
        }

        // POST: EstadoEquipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,NombreEstado")] EstadoEquipo estadoEquipo)
        {
            if (id != estadoEquipo.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoEquipoExists(estadoEquipo.IdEstado))
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
            return View(estadoEquipo);
        }

        // GET: EstadoEquipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoEquipo = await _context.EstadoEquipos
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoEquipo == null)
            {
                return NotFound();
            }

            return View(estadoEquipo);
        }

        // POST: EstadoEquipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoEquipo = await _context.EstadoEquipos.FindAsync(id);
            _context.EstadoEquipos.Remove(estadoEquipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoEquipoExists(int id)
        {
            return _context.EstadoEquipos.Any(e => e.IdEstado == id);
        }
    }
}
