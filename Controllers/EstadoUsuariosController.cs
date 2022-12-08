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
    public class EstadoUsuariosController : Controller
    {
        private readonly GEAContext _context;

        public EstadoUsuariosController(GEAContext context)
        {
            _context = context;
        }

        // GET: EstadoUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoUsuarios.ToListAsync());
        }

        // GET: EstadoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuarios
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return View(estadoUsuario);
        }

        // GET: EstadoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,NombreEstado")] EstadoUsuario estadoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoUsuario);
        }

        // GET: EstadoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuarios.FindAsync(id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }
            return View(estadoUsuario);
        }

        // POST: EstadoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,NombreEstado")] EstadoUsuario estadoUsuario)
        {
            if (id != estadoUsuario.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoUsuarioExists(estadoUsuario.IdEstado))
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
            return View(estadoUsuario);
        }

        // GET: EstadoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuarios
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return View(estadoUsuario);
        }

        // POST: EstadoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoUsuario = await _context.EstadoUsuarios.FindAsync(id);
            _context.EstadoUsuarios.Remove(estadoUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoUsuarioExists(int id)
        {
            return _context.EstadoUsuarios.Any(e => e.IdEstado == id);
        }
    }
}
