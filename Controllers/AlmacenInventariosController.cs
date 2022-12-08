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
    public class AlmacenInventariosController : Controller
    {
        private readonly GEAContext _context;

        public AlmacenInventariosController(GEAContext context)
        {
            _context = context;
        }

        // GET: AlmacenInventarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlmacenInventarios.ToListAsync());
        }

        // GET: AlmacenInventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenInventario = await _context.AlmacenInventarios
                .FirstOrDefaultAsync(m => m.IdAlmacen == id);
            if (almacenInventario == null)
            {
                return NotFound();
            }

            return View(almacenInventario);
        }

        // GET: AlmacenInventarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AlmacenInventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlmacen,NombreAlmacen,DescripcionAlmacen")] AlmacenInventario almacenInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(almacenInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almacenInventario);
        }

        // GET: AlmacenInventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenInventario = await _context.AlmacenInventarios.FindAsync(id);
            if (almacenInventario == null)
            {
                return NotFound();
            }
            return View(almacenInventario);
        }

        // POST: AlmacenInventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlmacen,NombreAlmacen,DescripcionAlmacen")] AlmacenInventario almacenInventario)
        {
            if (id != almacenInventario.IdAlmacen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacenInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenInventarioExists(almacenInventario.IdAlmacen))
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
            return View(almacenInventario);
        }

        // GET: AlmacenInventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenInventario = await _context.AlmacenInventarios
                .FirstOrDefaultAsync(m => m.IdAlmacen == id);
            if (almacenInventario == null)
            {
                return NotFound();
            }

            return View(almacenInventario);
        }

        // POST: AlmacenInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var almacenInventario = await _context.AlmacenInventarios.FindAsync(id);
            _context.AlmacenInventarios.Remove(almacenInventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenInventarioExists(int id)
        {
            return _context.AlmacenInventarios.Any(e => e.IdAlmacen == id);
        }
    }
}
