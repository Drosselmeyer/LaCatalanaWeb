using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Almacen_Inventario")]
    public partial class AlmacenInventario
    {
        public AlmacenInventario()
        {
            Equipos = new HashSet<Equipo>();
            StockAlmacenDetalles = new HashSet<StockAlmacenDetalle>();
        }

        [Key]
        [Column("Id_Almacen")]
        public int IdAlmacen { get; set; }
        [Required]
        [Column("Nombre_Almacen")]
        [StringLength(50)]
        public string NombreAlmacen { get; set; }
        [Column("Descripcion_Almacen")]
        [StringLength(100)]
        public string DescripcionAlmacen { get; set; }

        [InverseProperty(nameof(Equipo.AlmacenNavigation))]
        public virtual ICollection<Equipo> Equipos { get; set; }
        [InverseProperty(nameof(StockAlmacenDetalle.IdAlmacenNavigation))]
        public virtual ICollection<StockAlmacenDetalle> StockAlmacenDetalles { get; set; }
    }
}
