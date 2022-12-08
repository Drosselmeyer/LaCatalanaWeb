using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Equipos = new HashSet<Equipo>();
        }

        [Key]
        [Column("Id_Categoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("Nombre_Categoria")]
        [StringLength(25)]
        public string NombreCategoria { get; set; }

        [InverseProperty(nameof(Equipo.CategoriaNavigation))]
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
