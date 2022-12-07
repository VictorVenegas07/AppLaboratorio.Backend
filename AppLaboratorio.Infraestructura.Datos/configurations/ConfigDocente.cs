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
    public class ConfigDocente : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {
            builder
                .HasOne<Empleado>(d => d.Empleado)
                .WithMany(e => e.Docentes)
                .HasForeignKey(d => d.IdEmpleado);
        }
    }
}
