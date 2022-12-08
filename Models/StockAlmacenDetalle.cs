using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Stock_Almacen_Detalle")]
    public partial class StockAlmacenDetalle
    {
        [Key]
        [Column("Id_Stock")]
        public int IdStock { get; set; }
        [Column("Id_Equipo")]
        public int IdEquipo { get; set; }
        [Column("Id_Almacen")]
        public int IdAlmacen { get; set; }
        [Column("Cantidad_Stock")]
        public int CantidadStock { get; set; }

        [ForeignKey(nameof(IdAlmacen))]
        [InverseProperty(nameof(AlmacenInventario.StockAlmacenDetalles))]
        public virtual AlmacenInventario IdAlmacenNavigation { get; set; }
        [ForeignKey(nameof(IdEquipo))]
        [InverseProperty(nameof(Equipo.StockAlmacenDetalles))]
        public virtual Equipo IdEquipoNavigation { get; set; }
    }
}
