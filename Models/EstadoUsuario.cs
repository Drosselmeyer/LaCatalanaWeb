using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Estado_Usuario")]
    public partial class EstadoUsuario
    {
        public EstadoUsuario()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        [Column("Id_Estado")]
        public int IdEstado { get; set; }
        [Required]
        [Column("Nombre_Estado")]
        [StringLength(10)]
        public string NombreEstado { get; set; }

        [InverseProperty(nameof(Empleado.EstadoNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
