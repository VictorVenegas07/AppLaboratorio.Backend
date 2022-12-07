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
    public class DocenteRepository: IDocenteRepository<Docente>
    {
        private readonly LaboratorioContext context;
        public DocenteRepository(LaboratorioContext context_)
        {
            context = context_;
        }
        public List<Docente> Consultar(Func<Docente, bool> expresion)
        {
            return context.Docentes
                .Include(d=> d.Asignaturas)
                .Include(d=> d.Asignaturas)
                .Include(d=> d.Empleado)
                .Include(d=> d.Usuario)
                .Where(expresion).ToList();
        }

        public void Eliminar(Docente entity)
        {
            context.Docentes.Remove(entity);
        }

        public async Task<bool> ExistAsync(string identificacion)
        {
            return await context.Docentes.AnyAsync(x => x.Identificacion == identificacion);
        }

        public async Task<bool> ExisteUsuarioAsync(string username)
        {
            return await context.Usuarios.AnyAsync(x => x.NombreUsuario == username);

        }

        public async Task<Docente> GuardarAsync(Docente entity)
        {
            await context.Docentes.AddAsync(entity);
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

        public async Task<List<Docente>> ListarAsync()
        {
            return await context.Docentes
                .Include(d => d.Asignaturas)
                .Include(d => d.Asignaturas)
                .Include(d=> d.Usuario)
                .Include(d => d.Empleado)
                .ToListAsync();
        }

        public Docente ModificarAsync(Docente entity)
        {
            context.Docentes.Update(entity);
            return entity;
        }

        public async Task<Docente> ObtenerPorIdAsync(int id)
        {
            return await context.Docentes
                 .Include(d => d.Asignaturas)
                .Include(d => d.Asignaturas)
                .Include(d=> d.Usuario)
                .Include(d => d.Empleado)
                .FirstAsync(x => x.IdEmpleado == id);
        }
    }
}
