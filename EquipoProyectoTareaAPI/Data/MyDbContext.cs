using EquipoProyectoTareaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipoProyectoTareaAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Dueño> Dueños { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<MiModelo> MiModelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>()
                .HasOne(p => p.Equipo)
                .WithMany(e => e.Proyectos)
                .HasForeignKey(p => p.EquipoId);


            modelBuilder.Entity<Miembro>()
                .HasOne(m => m.Equipo)
                .WithMany(e => e.Miembros)
                .HasForeignKey(m => m.EquipoId);

            modelBuilder.Entity<Dueño>()
            .HasOne(d => d.Proyecto)
            .WithMany(p => p.Dueños)
            .HasForeignKey(d => d.ProyectoId);
        }
    }
}