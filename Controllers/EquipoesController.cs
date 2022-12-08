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
    public class EquipoesController : Controller
    {
        private readonly GEAContext _context;

        public EquipoesController(GEAContext context)
        {
            _context = context;
        }

        // GET: Equipoes
        public async Task<IActionResult> Index()
        {
            var gEAContext = _context.Equipos.Include(e => e.AlmacenNavigation).Include(e => e.CategoriaNavigation).Include(e => e.ColorNavigation).Include(e => e.EstadoNavigation).Include(e => e.MarcaNavigation);
            return View(await gEAContext.ToListAsync());
        }

        // GET: Equipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.AlmacenNavigation)
                .Include(e => e.CategoriaNavigation)
                .Include(e => e.ColorNavigation)
                .Include(e => e.EstadoNavigation)
                .Include(e => e.MarcaNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Equipoes/Create
        public IActionResult Create()
        {
            ViewData["Almacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen");
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria");
            ViewData["Color"] = new SelectList(_context.Colors, "IdColor", "IdColor");
            ViewData["Estado"] = new SelectList(_context.EstadoEquipos, "IdEstado", "NombreEstado");
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "NombreMarca");
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEquipo,NombreEquipo,Descripcion,Marca,Modelo,Color,Estado,Categoria,Proveedor,Almacen,Foto")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Almacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen", equipo.Almacen);
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", equipo.Categoria);
            ViewData["Color"] = new SelectList(_context.Colors, "IdColor", "IdColor", equipo.Color);
            ViewData["Estado"] = new SelectList(_context.EstadoEquipos, "IdEstado", "NombreEstado", equipo.Estado);
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "NombreMarca", equipo.Marca);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["Almacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen", equipo.Almacen);
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", equipo.Categoria);
            ViewData["Color"] = new SelectList(_context.Colors, "IdColor", "IdColor", equipo.Color);
            ViewData["Estado"] = new SelectList(_context.EstadoEquipos, "IdEstado", "NombreEstado", equipo.Estado);
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "NombreMarca", equipo.Marca);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEquipo,NombreEquipo,Descripcion,Marca,Modelo,Color,Estado,Categoria,Proveedor,Almacen,Foto")] Equipo equipo)
        {
            if (id != equipo.IdEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.IdEquipo))
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
            ViewData["Almacen"] = new SelectList(_context.AlmacenInventarios, "IdAlmacen", "NombreAlmacen", equipo.Almacen);
            ViewData["Categoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", equipo.Categoria);
            ViewData["Color"] = new SelectList(_context.Colors, "IdColor", "IdColor", equipo.Color);
            ViewData["Estado"] = new SelectList(_context.EstadoEquipos, "IdEstado", "NombreEstado", equipo.Estado);
            ViewData["Marca"] = new SelectList(_context.Marcas, "IdMarca", "NombreMarca", equipo.Marca);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipos
                .Include(e => e.AlmacenNavigation)
                .Include(e => e.CategoriaNavigation)
                .Include(e => e.ColorNavigation)
                .Include(e => e.EstadoNavigation)
                .Include(e => e.MarcaNavigation)
                .FirstOrDefaultAsync(m => m.IdEquipo == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
            return _context.Equipos.Any(e => e.IdEquipo == id);
        }
    }
}
