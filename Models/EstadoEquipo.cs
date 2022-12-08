using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Estado_Equipo")]
    public partial class EstadoEquipo
    {
        public EstadoEquipo()
        {
            Equipos = new HashSet<Equipo>();
        }

        [Key]
        [Column("Id_Estado")]
        public int IdEstado { get; set; }
        [Required]
        [Column("Nombre_Estado")]
        [StringLength(25)]
        public string NombreEstado { get; set; }

        [InverseProperty(nameof(Equipo.EstadoNavigation))]
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
