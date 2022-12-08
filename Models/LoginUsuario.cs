using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace LaCatalanaWeb.Models
{
    [Table("Login_Usuarios")]
    public partial class LoginUsuario
    {
        [Key]
        [Column("Id_Usuario")]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(15)]
        public string Usuario { get; set; }
        [Required]
        public byte[] Contraseña { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Empleado.LoginUsuario))]
        public virtual Empleado IdUsuarioNavigation { get; set; }
    }
}
