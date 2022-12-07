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
    public class ConfigUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasOne<Empleado>(u => u.Empleado)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Empleado>(u => u.IdUsuario); 

            builder
            .HasOne<Docente>(u => u.Docente)
            .WithOne(e => e.Usuario)
            .HasForeignKey<Docente>(u => u.IdUsuario)
            .OnDelete(DeleteBehavior.ClientNoAction)
            .HasConstraintName("Fk_Docente_DocenteID");

            builder
                .HasOne<Cargo>(u => u.Cargo)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.IdCargo);
        }
    }
}
