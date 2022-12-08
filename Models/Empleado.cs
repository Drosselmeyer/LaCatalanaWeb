using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Asignaciones = new HashSet<Asignacione>();
        }

        [Key]
        [Column("Id_Empleado")]
        public int IdEmpleado { get; set; }
        [Required]
        [Column("Nombres_Empleado")]
        [StringLength(50)]
        public string NombresEmpleado { get; set; }
        [Required]
        [Column("Apellidos_Empleado")]
        [StringLength(50)]
        public string ApellidosEmpleado { get; set; }
        [Column("Correo_Corporativo")]
        [StringLength(100)]
        public string CorreoCorporativo { get; set; }
        [Column("Telefono_Corporativo")]
        [StringLength(10)]
        public string TelefonoCorporativo { get; set; }
        public int Rol { get; set; }
        public int Estado { get; set; }
        public int Empresa { get; set; }
        public int Departamento { get; set; }

        [ForeignKey(nameof(Departamento))]
        [InverseProperty("Empleados")]
        public virtual Departamento DepartamentoNavigation { get; set; }
        [ForeignKey(nameof(Empresa))]
        [InverseProperty("Empleados")]
        public virtual Empresa EmpresaNavigation { get; set; }
        [ForeignKey(nameof(Estado))]
        [InverseProperty(nameof(EstadoUsuario.Empleados))]
        public virtual EstadoUsuario EstadoNavigation { get; set; }
        [ForeignKey(nameof(Rol))]
        [InverseProperty(nameof(Role.Empleados))]
        public virtual Role RolNavigation { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual LoginUsuario LoginUsuario { get; set; }
        [InverseProperty(nameof(Asignacione.EmpleadoNavigation))]
        public virtual ICollection<Asignacione> Asignaciones { get; set; }
    }
}
