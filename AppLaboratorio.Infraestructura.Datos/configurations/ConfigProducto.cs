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
    public class ConfigProducto : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder
                .HasOne<Empleado>(p => p.empleado)
                .WithMany(e => e.Productos)
                .HasForeignKey(p => p.IdEmpleado);
        }
    }
}
