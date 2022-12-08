using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Empresa")]
    public partial class Empresa
    {
        public Empresa()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        [Column("Id_Empresa")]
        public int IdEmpresa { get; set; }
        [Required]
        [Column("Nombre_Empresa")]
        [StringLength(100)]
        public string NombreEmpresa { get; set; }

        [InverseProperty(nameof(Empleado.EmpresaNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
