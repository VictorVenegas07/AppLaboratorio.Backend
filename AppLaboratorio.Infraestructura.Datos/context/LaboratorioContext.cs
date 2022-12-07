using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Datos.configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Infraestructura.Datos.context
{
    public class LaboratorioContext : DbContext
    {
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleInsumo> DetallesInsumos { get; set; }
        public DbSet<DetalleSolicitud> DetalleSolicitudes { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<RespuestaSolicitud> RespuestaSolicitudes { get; set; }
        public DbSet<Solicitud> solicitudes { get; set; }
        public DbSet<SolicitudInsumo> SolicitudeInsumos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AsignaturaDocente> AsignaturaDocentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = VICTOR; Database = LaboratorioDB; Trusted_Connection = True; MultipleActiveResultSets = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigAsignaturaDocente());
            modelBuilder.ApplyConfiguration(new ConfigAsignatura());
            modelBuilder.ApplyConfiguration(new ConfigDetalleIsumos());
            modelBuilder.ApplyConfiguration(new ConfigDetalleSolicitud());
            modelBuilder.ApplyConfiguration(new ConfigDocente());
            modelBuilder.ApplyConfiguration(new ConfigProducto());
            modelBuilder.ApplyConfiguration(new ConfigSolicitud());
            modelBuilder.ApplyConfiguration(new ConfigSolicitudInsumos());
            modelBuilder.ApplyConfiguration(new ConfigUsuario());

            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    IdEmpleado = 1,
                    Identificacion = "1121328342",
                    PrimerNombre = "Nemer",
                    SegundoNombre = "Jose",
                    PrimerApellido = "Velandia",
                    SegundoApellido = "Soto",
                    IdUsuario = 1
                });
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    IdUsuario = 1,
                    IdCargo = 1,
                    NombreUsuario = "vnemer",
                    Contraseña = "12345678",
                    Email = "nvelandia@unicesar.edu.co"
                }
                );
            modelBuilder.Entity<Cargo>().HasData(
                new Cargo
                {
                    IdCargo = 1,
                    NombreCargo = "Administrador"
                });

        }
    }
}
