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
    public class ConfigDetalleIsumos : IEntityTypeConfiguration<DetalleInsumo>
    {
        public void Configure(EntityTypeBuilder<DetalleInsumo> builder)
        {
            builder
                .HasOne<SolicitudInsumo>(d => d.SolicitudInsumo)
                .WithMany(s => s.Insumos)
                .HasForeignKey(d => d.IdSolicitudIsumo);
        }
    }
}
