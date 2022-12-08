using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("AsignacionEquipo_Detalle")]
    public partial class AsignacionEquipoDetalle
    {
        [Key]
        [Column("Id_DetalleAE")]
        public int IdDetalleAe { get; set; }
        [Column("Id_Asignacion")]
        public int IdAsignacion { get; set; }
        [Column("Id_Equipo")]
        public int IdEquipo { get; set; }

        [ForeignKey(nameof(IdAsignacion))]
        [InverseProperty(nameof(Asignacione.AsignacionEquipoDetalles))]
        public virtual Asignacione IdAsignacionNavigation { get; set; }
        [ForeignKey(nameof(IdEquipo))]
        [InverseProperty(nameof(Equipo.AsignacionEquipoDetalles))]
        public virtual Equipo IdEquipoNavigation { get; set; }
    }
}
