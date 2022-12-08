using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Proceso")]
    public partial class Proceso
    {
        public Proceso()
        {
            Asignaciones = new HashSet<Asignacione>();
        }

        [Key]
        [Column("Id_Tipo")]
        public int IdTipo { get; set; }
        [Required]
        [Column("Nombre_Proceso")]
        [StringLength(20)]
        public string NombreProceso { get; set; }

        [InverseProperty(nameof(Asignacione.TipoProcesoNavigation))]
        public virtual ICollection<Asignacione> Asignaciones { get; set; }
    }
}
