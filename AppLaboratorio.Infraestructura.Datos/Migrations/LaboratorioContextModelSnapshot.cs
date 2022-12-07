﻿// <auto-generated />
using System;
using AppLaboratorio.Infraestructura.Datos.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppLaboratorio.Infraestructura.Datos.Migrations
{
    [DbContext(typeof(LaboratorioContext))]
    partial class LaboratorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Asignatura", b =>
                {
                    b.Property<int>("IdAsignatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Grupo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HorasLaboratorio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAsignatura");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Asignaturas");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.AsignaturaDocente", b =>
                {
                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int");

                    b.HasKey("IdDocente", "IdAsignatura");

                    b.HasIndex("IdAsignatura");

                    b.ToTable("AsignaturaDocentes");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Cargo", b =>
                {
                    b.Property<int>("IdCargo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NombreCargo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCargo");

                    b.ToTable("Cargos");

                    b.HasData(
                        new
                        {
                            IdCargo = 1,
                            NombreCargo = "Administrador"
                        });
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("IVA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdSolicitudIsumo")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCompra");

                    b.HasIndex("IdSolicitudIsumo")
                        .IsUnique();

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.DetalleInsumo", b =>
                {
                    b.Property<int>("IdDetalleInsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdSolicitudIsumo")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdDetalleInsumo");

                    b.HasIndex("IdSolicitudIsumo");

                    b.ToTable("DetallesInsumos");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.DetalleSolicitud", b =>
                {
                    b.Property<int>("IdDetalleSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdSolicitud")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleSolicitud");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdSolicitud");

                    b.ToTable("DetalleSolicitudes");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Docente", b =>
                {
                    b.Property<int>("IdDocente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDocente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Docentes");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("IdUsuario")
                        .IsUnique();

                    b.ToTable("Empleados");

                    b.HasData(
                        new
                        {
                            IdEmpleado = 1,
                            IdUsuario = 1,
                            Identificacion = "1121328342",
                            PrimerApellido = "Velandia",
                            PrimerNombre = "Nemer",
                            SegundoApellido = "Soto",
                            SegundoNombre = "Jose"
                        });
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("CodigoProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.RespuestaSolicitud", b =>
                {
                    b.Property<int>("IdRespuestaSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdSolicitud")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoIdProducto")
                        .HasColumnType("int");

                    b.HasKey("IdRespuestaSolicitud");

                    b.HasIndex("IdSolicitud")
                        .IsUnique();

                    b.HasIndex("ProductoIdProducto");

                    b.ToTable("RespuestaSolicitudes");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Solicitud", b =>
                {
                    b.Property<int>("IdSolicitud")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaLimite")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDocente")
                        .HasColumnType("int");

                    b.Property<string>("NombreAsignatura")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSolicitud");

                    b.HasIndex("IdDocente");

                    b.ToTable("solicitudes");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.SolicitudInsumo", b =>
                {
                    b.Property<int>("IdSolicitudIsumo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSolicitudIsumo");

                    b.HasIndex("IdEmpleado");

                    b.ToTable("SolicitudeInsumos");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdCargo");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            Contraseña = "12345678",
                            Email = "nvelandia@unicesar.edu.co",
                            IdCargo = 1,
                            NombreUsuario = "vnemer"
                        });
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Asignatura", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Empleado", "Empleado")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.AsignaturaDocente", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Docente", "Docente")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdAsignatura")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("AppLaboratorio.Dominio.Entidades.Asignatura", "Asignatura")
                        .WithMany("Docentes")
                        .HasForeignKey("IdDocente")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Asignatura");

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Compra", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.SolicitudInsumo", "Insumo")
                        .WithOne("Compra")
                        .HasForeignKey("AppLaboratorio.Dominio.Entidades.Compra", "IdSolicitudIsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumo");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.DetalleInsumo", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.SolicitudInsumo", "SolicitudInsumo")
                        .WithMany("Insumos")
                        .HasForeignKey("IdSolicitudIsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SolicitudInsumo");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.DetalleSolicitud", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Producto", "Producto")
                        .WithMany("Detalles")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppLaboratorio.Dominio.Entidades.Solicitud", "Solicitud")
                        .WithMany("DetalleSolicitudes")
                        .HasForeignKey("IdSolicitud")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Solicitud");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Docente", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Empleado", "Empleado")
                        .WithMany("Docentes")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppLaboratorio.Dominio.Entidades.Usuario", "Usuario")
                        .WithOne("Docente")
                        .HasForeignKey("AppLaboratorio.Dominio.Entidades.Docente", "IdUsuario")
                        .HasConstraintName("Fk_Docente_DocenteID")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Empleado");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Empleado", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Usuario", "Usuario")
                        .WithOne("Empleado")
                        .HasForeignKey("AppLaboratorio.Dominio.Entidades.Empleado", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Producto", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Empleado", "empleado")
                        .WithMany("Productos")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("empleado");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.RespuestaSolicitud", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Solicitud", "Solicitud")
                        .WithOne("Respuesta")
                        .HasForeignKey("AppLaboratorio.Dominio.Entidades.RespuestaSolicitud", "IdSolicitud")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppLaboratorio.Dominio.Entidades.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoIdProducto");

                    b.Navigation("Producto");

                    b.Navigation("Solicitud");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Solicitud", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Docente", "Docente")
                        .WithMany("Solicitudes")
                        .HasForeignKey("IdDocente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Docente");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.SolicitudInsumo", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Empleado", "Empleado")
                        .WithMany("SolicitudesInsumos")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("AppLaboratorio.Dominio.Entidades.Cargo", "Cargo")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Asignatura", b =>
                {
                    b.Navigation("Docentes");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Cargo", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Docente", b =>
                {
                    b.Navigation("Asignaturas");

                    b.Navigation("Solicitudes");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Empleado", b =>
                {
                    b.Navigation("Asignaturas");

                    b.Navigation("Docentes");

                    b.Navigation("Productos");

                    b.Navigation("SolicitudesInsumos");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Producto", b =>
                {
                    b.Navigation("Detalles");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Solicitud", b =>
                {
                    b.Navigation("DetalleSolicitudes");

                    b.Navigation("Respuesta");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.SolicitudInsumo", b =>
                {
                    b.Navigation("Compra");

                    b.Navigation("Insumos");
                });

            modelBuilder.Entity("AppLaboratorio.Dominio.Entidades.Usuario", b =>
                {
                    b.Navigation("Docente");

                    b.Navigation("Empleado");
                });
#pragma warning restore 612, 618
        }
    }
}