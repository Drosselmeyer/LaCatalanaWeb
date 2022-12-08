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
    public class EmpleadoesController : Controller
    {
        private readonly GEAContext _context;

        public EmpleadoesController(GEAContext context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var gEAContext = _context.Empleados.Include(e => e.DepartamentoNavigation).Include(e => e.EmpresaNavigation).Include(e => e.EstadoNavigation).Include(e => e.RolNavigation);
            return View(await gEAContext.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.DepartamentoNavigation)
                .Include(e => e.EmpresaNavigation)
                .Include(e => e.EstadoNavigation)
                .Include(e => e.RolNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["Departamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento");
            ViewData["Empresa"] = new SelectList(_context.Empresas, "IdEmpresa", "NombreEmpresa");
            ViewData["Estado"] = new SelectList(_context.EstadoUsuarios, "IdEstado", "NombreEstado");
            ViewData["Rol"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,NombresEmpleado,ApellidosEmpleado,CorreoCorporativo,TelefonoCorporativo,Rol,Estado,Empresa,Departamento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Departamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento", empleado.Departamento);
            ViewData["Empresa"] = new SelectList(_context.Empresas, "IdEmpresa", "NombreEmpresa", empleado.Empresa);
            ViewData["Estado"] = new SelectList(_context.EstadoUsuarios, "IdEstado", "NombreEstado", empleado.Estado);
            ViewData["Rol"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", empleado.Rol);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["Departamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento", empleado.Departamento);
            ViewData["Empresa"] = new SelectList(_context.Empresas, "IdEmpresa", "NombreEmpresa", empleado.Empresa);
            ViewData["Estado"] = new SelectList(_context.EstadoUsuarios, "IdEstado", "NombreEstado", empleado.Estado);
            ViewData["Rol"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", empleado.Rol);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,NombresEmpleado,ApellidosEmpleado,CorreoCorporativo,TelefonoCorporativo,Rol,Estado,Empresa,Departamento")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["Departamento"] = new SelectList(_context.Departamentos, "IdDepartamento", "NombreDepartamento", empleado.Departamento);
            ViewData["Empresa"] = new SelectList(_context.Empresas, "IdEmpresa", "NombreEmpresa", empleado.Empresa);
            ViewData["Estado"] = new SelectList(_context.EstadoUsuarios, "IdEstado", "NombreEstado", empleado.Estado);
            ViewData["Rol"] = new SelectList(_context.Roles, "IdRol", "DescripcionRol", empleado.Rol);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.DepartamentoNavigation)
                .Include(e => e.EmpresaNavigation)
                .Include(e => e.EstadoNavigation)
                .Include(e => e.RolNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
