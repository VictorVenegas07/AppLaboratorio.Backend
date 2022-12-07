using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Dominio.Interfaces.IRepository;
using AppLaboratorio.Infraestructura.Datos.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Infraestructura.Datos.Repository
{
    public class AsignaturaRepository : IAsignaturaRepository<Asignatura>
    {
        private readonly LaboratorioContext context;
        public AsignaturaRepository(LaboratorioContext context_)
        {
            context = context_;
        }
        public List<Asignatura> Consultar(Func<Asignatura, bool> expresion)
        {
            return context.Asignaturas
                .Include(a => a.Docentes)
                .Include(a => a.Empleado)
                .Where(expresion)
                .ToList();
        }

        public void Eliminar(Asignatura entity)
        {
            context.Asignaturas
                .Remove(entity);

        }

        public async Task<bool> ExisteAsync(string nombre)
        {
            return await context.Asignaturas.AnyAsync(x => x.Nombre == nombre);
            
        }

        public async Task<Asignatura> GuardarAsync(Asignatura entity)
        {
            await context.Asignaturas.AddAsync(entity);
            return entity;
        }

        public async Task GuardarCambiosAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception($"Ocurrio el siguiente error: {e.Message}");
            }
        }

        public async Task<List<Asignatura>> ListarAsync()
        {
            return await context.Asignaturas
                .Include(a => a.Docentes)
                .Include(a => a.Empleado)
                .ToListAsync();
        }

        public Asignatura ModificarAsync(Asignatura entity)
        {
            context.Asignaturas.Update(entity);
            return entity;
        }

        public async Task<Asignatura> ObtenerPorIdAsync(int id)
        {
            return await context.Asignaturas
               .Include(a => a.Docentes)
               .Include(a => a.Empleado)
               .FirstAsync(x => x.IdAsignatura == id);
        }
    }
}
