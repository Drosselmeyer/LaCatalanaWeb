using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LaCatalanaWeb.Models;

#nullable disable

namespace LaCatalanaWeb.Data
{
    public partial class GEAContext : DbContext
    {
        public GEAContext()
        {
        }

        public GEAContext(DbContextOptions<GEAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlmacenInventario> AlmacenInventarios { get; set; }
        public virtual DbSet<AsignacionEquipoDetalle> AsignacionEquipoDetalles { get; set; }
        public virtual DbSet<Asignacione> Asignaciones { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Equipo> Equipos { get; set; }
        public virtual DbSet<EstadoEquipo> EstadoEquipos { get; set; }
        public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; }
        public virtual DbSet<LoginUsuario> LoginUsuarios { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Proceso> Procesos { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StockAlmacenDetalle> StockAlmacenDetalles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KJSRL4B\\SQLEXPRESS;Initial Catalog=GEA;Trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AlmacenInventario>(entity =>
            {
                entity.HasKey(e => e.IdAlmacen)
                    .HasName("PK__Almacen___1E9C729EC09A94CD");
            });

            modelBuilder.Entity<AsignacionEquipoDetalle>(entity =>
            {
                entity.HasOne(d => d.IdAsignacionNavigation)
                    .WithMany(p => p.AsignacionEquipoDetalles)
                    .HasForeignKey(d => d.IdAsignacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AsignacionDatos");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.AsignacionEquipoDetalles)
                    .HasForeignKey(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AsignacionEquipo");
            });

            modelBuilder.Entity<Asignacione>(entity =>
            {
                entity.HasKey(e => e.IdAsignacion)
                    .HasName("PK__Asignaci__B68764437F466DDC");

                entity.HasOne(d => d.EmpleadoNavigation)
                    .WithMany(p => p.Asignaciones)
                    .HasForeignKey(d => d.Empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AsignacionEmpleado");

                entity.HasOne(d => d.TipoProcesoNavigation)
                    .WithMany(p => p.Asignaciones)
                    .HasForeignKey(d => d.TipoProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TProceso");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__CB903349DE13C324");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PK__Color__F0C073539521A4EA");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__Departam__D9F8A911A9FFDF3F");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PK__Empleado__7405622382C85DE9");

                entity.Property(e => e.TelefonoCorporativo)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.DepartamentoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Departamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento");

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empresa");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estado");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rol");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__443B3D9D8AA6FD2C");
            });

            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipo)
                    .HasName("PK__Equipos__4B9119C0FBEAA18E");

                entity.HasOne(d => d.AlmacenNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Almacen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlmacenEquipo");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categoria");

                entity.HasOne(d => d.ColorNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Color)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Color");

                entity.HasOne(d => d.EstadoNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Estado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstadoEquipo");

                entity.HasOne(d => d.MarcaNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Marca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marca");
            });

            modelBuilder.Entity<EstadoEquipo>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado_E__AB2EB6F82EA3756C");
            });

            modelBuilder.Entity<EstadoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__Estado_U__AB2EB6F811BD16A5");

                entity.Property(e => e.NombreEstado)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<LoginUsuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Login_Us__63C76BE2823ACA49");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.LoginUsuario)
                    .HasForeignKey<LoginUsuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__28EFE28AE186EB73");
            });

            modelBuilder.Entity<Proceso>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__Proceso__064163921065E271");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__55932E8644D4EE0A");
            });

            modelBuilder.Entity<StockAlmacenDetalle>(entity =>
            {
                entity.HasKey(e => e.IdStock)
                    .HasName("PK__Stock_Al__4336DD3F04D0434C");

                entity.HasOne(d => d.IdAlmacenNavigation)
                    .WithMany(p => p.StockAlmacenDetalles)
                    .HasForeignKey(d => d.IdAlmacen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlmacenEquipoDetalle");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.StockAlmacenDetalles)
                    .HasForeignKey(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
