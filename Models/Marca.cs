using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Marca")]
    public partial class Marca
    {
        public Marca()
        {
            Equipos = new HashSet<Equipo>();
        }

        [Key]
        [Column("Id_Marca")]
        public int IdMarca { get; set; }
        [Required]
        [Column("Nombre_Marca")]
        [StringLength(25)]
        public string NombreMarca { get; set; }

        [InverseProperty(nameof(Equipo.MarcaNavigation))]
        public virtual ICollection<Equipo> Equipos { get; set; }
    }
}
