using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBContext
{
    public partial class PruebaBusinessProContext : DbContext
    {
        public PruebaBusinessProContext()
        {
        }

        public PruebaBusinessProContext(DbContextOptions<PruebaBusinessProContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<ListarArticulos> Listar { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HUQJ775\\DATOS;Initial Catalog=PruebaBusinessPro;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.HasKey(e => e.IdArticulo)
                    .HasName("PK__Articulo__F8FF5D52A66BDF1B");

                entity.Property(e => e.CodigoArticulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoActivo).HasMaxLength(50);

                entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");

                entity.Property(e => e.NombreArticulo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdProveedor)
                    .HasConstraintName("FK_proveedor_articulo");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PK__Proveedo__E8B631AFE33DEEED");

                entity.Property(e => e.CodigoProveedor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        //Metodos para Actualizar los datos ne la tabla de articulos y proveedores 
        public void ActualizarArticulos(Articulos Articulos_param)
        {
            this.Articulos.Update(Articulos_param);
        }



        public void ActualizarProvedores(Proveedor Proveedores_param)
        {
            this.Proveedor.Update(Proveedores_param);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
