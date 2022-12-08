using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    public partial class Role
    {
        public Role()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        [Column("Id_Rol")]
        public int IdRol { get; set; }
        [Required]
        [Column("Nombre_Rol")]
        [StringLength(50)]
        public string NombreRol { get; set; }
        [Required]
        [Column("Descripcion_Rol")]
        [StringLength(100)]
        public string DescripcionRol { get; set; }

        [InverseProperty(nameof(Empleado.RolNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
