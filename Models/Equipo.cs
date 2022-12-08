using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            AsignacionEquipoDetalles = new HashSet<AsignacionEquipoDetalle>();
            StockAlmacenDetalles = new HashSet<StockAlmacenDetalle>();
        }

        [Key]
        [Column("Id_Equipo")]
        public int IdEquipo { get; set; }
        [Required]
        [Column("Nombre_Equipo")]
        [StringLength(25)]
        public string NombreEquipo { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        public int Marca { get; set; }
        [Required]
        [StringLength(25)]
        public string Modelo { get; set; }
        public int Color { get; set; }
        public int Estado { get; set; }
        public int Categoria { get; set; }
        public int Proveedor { get; set; }
        public int Almacen { get; set; }
        public byte[] Foto { get; set; }

        [ForeignKey(nameof(Almacen))]
        [InverseProperty(nameof(AlmacenInventario.Equipos))]
        public virtual AlmacenInventario AlmacenNavigation { get; set; }
        [ForeignKey(nameof(Categoria))]
        [InverseProperty(nameof(Categorium.Equipos))]
        public virtual Categorium CategoriaNavigation { get; set; }
        [ForeignKey(nameof(Color))]
        [InverseProperty("Equipos")]
        public virtual Color ColorNavigation { get; set; }
        [ForeignKey(nameof(Estado))]
        [InverseProperty(nameof(EstadoEquipo.Equipos))]
        public virtual EstadoEquipo EstadoNavigation { get; set; }
        [ForeignKey(nameof(Marca))]
        [InverseProperty("Equipos")]
        public virtual Marca MarcaNavigation { get; set; }
        [InverseProperty(nameof(AsignacionEquipoDetalle.IdEquipoNavigation))]
        public virtual ICollection<AsignacionEquipoDetalle> AsignacionEquipoDetalles { get; set; }
        [InverseProperty(nameof(StockAlmacenDetalle.IdEquipoNavigation))]
        public virtual ICollection<StockAlmacenDetalle> StockAlmacenDetalles { get; set; }
    }
}
