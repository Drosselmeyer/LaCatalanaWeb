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
    public class LoginUsuariosController : Controller
    {
        private readonly GEAContext _context;

        public LoginUsuariosController(GEAContext context)
        {
            _context = context;
        }

        // GET: LoginUsuarios
        public async Task<IActionResult> Index()
        {
            var gEAContext = _context.LoginUsuarios.Include(l => l.IdUsuarioNavigation);
            return View(await gEAContext.ToListAsync());
        }

        // GET: LoginUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginUsuario = await _context.LoginUsuarios
                .Include(l => l.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (loginUsuario == null)
            {
                return NotFound();
            }

            return View(loginUsuario);
        }

        // GET: LoginUsuarios/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado");
            return View();
        }

        // POST: LoginUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Usuario,Contraseña")] LoginUsuario loginUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", loginUsuario.IdUsuario);
            return View(loginUsuario);
        }

        // GET: LoginUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginUsuario = await _context.LoginUsuarios.FindAsync(id);
            if (loginUsuario == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", loginUsuario.IdUsuario);
            return View(loginUsuario);
        }

        // POST: LoginUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Usuario,Contraseña")] LoginUsuario loginUsuario)
        {
            if (id != loginUsuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginUsuarioExists(loginUsuario.IdUsuario))
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
            ViewData["IdUsuario"] = new SelectList(_context.Empleados, "IdEmpleado", "ApellidosEmpleado", loginUsuario.IdUsuario);
            return View(loginUsuario);
        }

        // GET: LoginUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginUsuario = await _context.LoginUsuarios
                .Include(l => l.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (loginUsuario == null)
            {
                return NotFound();
            }

            return View(loginUsuario);
        }

        // POST: LoginUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginUsuario = await _context.LoginUsuarios.FindAsync(id);
            _context.LoginUsuarios.Remove(loginUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginUsuarioExists(int id)
        {
            return _context.LoginUsuarios.Any(e => e.IdUsuario == id);
        }
    }
}
