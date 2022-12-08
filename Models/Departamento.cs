using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Empleados = new HashSet<Empleado>();
        }

        [Key]
        [Column("Id_Departamento")]
        public int IdDepartamento { get; set; }
        [Required]
        [Column("Nombre_Departamento")]
        [StringLength(25)]
        public string NombreDepartamento { get; set; }

        [InverseProperty(nameof(Empleado.DepartamentoNavigation))]
        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
