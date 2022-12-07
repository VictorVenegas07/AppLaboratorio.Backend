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
    public class ConfigSolicitud : IEntityTypeConfiguration<Solicitud>
    {
        public void Configure(EntityTypeBuilder<Solicitud> builder)
        {
            builder
                .HasOne<Docente>(s => s.Docente)
                .WithMany(d => d.Solicitudes)
                .HasForeignKey(s => s.IdDocente);
            builder
                .HasOne<RespuestaSolicitud>(s=> s.Respuesta)
                .WithOne(rp => rp.Solicitud)
                .HasForeignKey<RespuestaSolicitud>(rp=> rp.IdSolicitud);

        }
    }
}
