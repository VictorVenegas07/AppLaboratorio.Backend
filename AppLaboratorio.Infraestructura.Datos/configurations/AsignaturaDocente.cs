using AppLaboratorio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Infraestructura.Datos.configurations
{
    public class ConfigAsignaturaDocente : IEntityTypeConfiguration<AsignaturaDocente>
    {
        public void Configure(EntityTypeBuilder<AsignaturaDocente> builder)
        {
            builder.HasKey(sc => new {sc.IdDocente, sc.IdAsignatura});

            builder
                .HasOne<Docente>(ad => ad.Docente)
                .WithMany(d => d.Asignaturas)
                .HasForeignKey(sd => sd.IdAsignatura)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasOne<Asignatura>(ad => ad.Asignatura)
                .WithMany(a => a.Docentes)
                .HasForeignKey(ad => ad.IdDocente)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
