using AppLaboratorio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Infraestructura.Datos.configurations
{
    internal class ConfigSolicitudInsumos : IEntityTypeConfiguration<SolicitudInsumo>
    {
        public void Configure(EntityTypeBuilder<SolicitudInsumo> builder)
        {
            builder
                .HasOne<Empleado>(s => s.Empleado)
                .WithMany(e => e.SolicitudesInsumos)
                .HasForeignKey(s => s.IdEmpleado);
            builder
                .HasOne<Compra>(s => s.Compra)
                .WithOne(c=> c.Insumo)
                .HasForeignKey<Compra>(s => s.IdSolicitudIsumo);

        }
    }
}
