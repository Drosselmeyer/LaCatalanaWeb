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
    public class StockAlmacenDetallesController : Controller
    {
        private readonly GEAContext _context;

        public StockAlmacenDetallesController(GEAContext context)
        {
            _context = context;
        }

        // GET: StockAlmacenDetalles
        public async Task<IActionResult> Index()
        {
            var gEAContext = _context.StockAlmacenDetalles.Include(s => s.IdAlmacenNavigation).Include(s => s.IdEquipoNavigation);
            return View(await gEAContext.ToListAsync());
        }

        // GET: StockAlmacenDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockAlmacenDetalle = await _context.StockAlmacenDetalles
                .Include(s => s.IdAlmacenNavigation)
                .Include(s => s.IdEquipoNavigation)
                .FirstOrDefaultAsync(m => m.IdStock == id);
            if (stockAlmacenDetalle == null)
            {
                return NotFound();
            }

            return View(stockAlmacenDetalle);
        }

        // GET: StockAlmacenDetalles/Create
        public IActionResult Create()
        {
            ViewData["IdAlmacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen");
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion");
            return View();
        }

        // POST: StockAlmacenDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStock,IdEquipo,IdAlmacen,CantidadStock")] StockAlmacenDetalle stockAlmacenDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockAlmacenDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlmacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen", stockAlmacenDetalle.IdAlmacen);
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion", stockAlmacenDetalle.IdEquipo);
            return View(stockAlmacenDetalle);
        }

        // GET: StockAlmacenDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockAlmacenDetalle = await _context.StockAlmacenDetalles.FindAsync(id);
            if (stockAlmacenDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdAlmacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen", stockAlmacenDetalle.IdAlmacen);
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion", stockAlmacenDetalle.IdEquipo);
            return View(stockAlmacenDetalle);
        }

        // POST: StockAlmacenDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStock,IdEquipo,IdAlmacen,CantidadStock")] StockAlmacenDetalle stockAlmacenDetalle)
        {
            if (id != stockAlmacenDetalle.IdStock)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockAlmacenDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockAlmacenDetalleExists(stockAlmacenDetalle.IdStock))
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
            ViewData["IdAlmacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen", stockAlmacenDetalle.IdAlmacen);
            ViewData["IdEquipo"] = new SelectList(_context.Equipos, "IdEquipo", "Descripcion", stockAlmacenDetalle.IdEquipo);
            return View(stockAlmacenDetalle);
        }

        // GET: StockAlmacenDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockAlmacenDetalle = await _context.StockAlmacenDetalles
                .Include(s => s.IdAlmacenNavigation)
                .Include(s => s.IdEquipoNavigation)
                .FirstOrDefaultAsync(m => m.IdStock == id);
            if (stockAlmacenDetalle == null)
            {
                return NotFound();
            }

            return View(stockAlmacenDetalle);
        }

        // POST: StockAlmacenDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockAlmacenDetalle = await _context.StockAlmacenDetalles.FindAsync(id);
            _context.StockAlmacenDetalles.Remove(stockAlmacenDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockAlmacenDetalleExists(int id)
        {
            return _context.StockAlmacenDetalles.Any(e => e.IdStock == id);
        }
    }
}
