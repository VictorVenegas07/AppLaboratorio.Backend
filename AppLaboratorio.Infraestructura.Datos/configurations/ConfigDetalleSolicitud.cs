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
    public class ConfigDetalleSolicitud : IEntityTypeConfiguration<DetalleSolicitud>
    {
        public void Configure(EntityTypeBuilder<DetalleSolicitud> builder)
        {
            builder
                .HasOne<Producto>(d => d.Producto)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.IdProducto);
            builder
                .HasOne<Solicitud>(d => d.Solicitud)
                .WithMany(s => s.DetalleSolicitudes)
                .HasForeignKey(d => d.IdSolicitud)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
