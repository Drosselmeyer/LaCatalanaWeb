using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    public partial class Asignacione
    {
        public Asignacione()
        {
            AsignacionEquipoDetalles = new HashSet<AsignacionEquipoDetalle>();
        }

        [Key]
        [Column("Id_Asignacion")]
        public int IdAsignacion { get; set; }
        [Column("Fecha_Asignacion", TypeName = "datetime")]
        public DateTime FechaAsignacion { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Column("Tipo_Proceso")]
        public int TipoProceso { get; set; }
        public int Empleado { get; set; }
        [Column("Empleado_Anterior")]
        public int? EmpleadoAnterior { get; set; }
        [Required]
        [Column("Detalles_Asignaciones")]
        [StringLength(100)]
        public string DetallesAsignaciones { get; set; }
        [Column("URL_QR")]
        [StringLength(200)]
        public string UrlQr { get; set; }

        [ForeignKey(nameof(Empleado))]
        [InverseProperty("Asignaciones")]
        public virtual Empleado EmpleadoNavigation { get; set; }
        [ForeignKey(nameof(TipoProceso))]
        [InverseProperty(nameof(Proceso.Asignaciones))]
        public virtual Proceso TipoProcesoNavigation { get; set; }
        [InverseProperty(nameof(AsignacionEquipoDetalle.IdAsignacionNavigation))]
        public virtual ICollection<AsignacionEquipoDetalle> AsignacionEquipoDetalles { get; set; }
    }
}
