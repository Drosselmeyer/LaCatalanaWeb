using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Color")]
    public partial class Color
    {
        public Color()
        {
            Equipos = new HashSet<Equipo>();
        }

        [Key]
        [Column("Id_Color")]
        public int IdColor { get; set; }
        [Column("Nombre_Color")]
        [StringLength(25)]
        public string NombreColor { get; set; }

        [InverseProperty(nameof(Equipo.ColorNavigation))]
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
