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
    public class EmpleadoRepository : IEmpleadoRepository<Empleado>
    {

        private readonly LaboratorioContext context;
        public EmpleadoRepository(LaboratorioContext context_)
        {
            context = context_;
        }
        public List<Empleado> Consultar(Func<Empleado, bool> expresion)
        {
            return context.Empleados
                .Include(p => p.Docentes)
                .Include(p => p.Asignaturas)
                .Include(p => p.Usuario)
                .Include(p => p.Productos)
                .Include(p => p.SolicitudesInsumos)
                .Where(expresion).ToList();
        }

        public void Eliminar(Empleado entity)
        {
            context.Empleados.Remove(entity);
        }

        public async Task<bool> ExistAsync(string identificacion)
        {
            return await context.Empleados.AnyAsync(x => x.Identificacion == identificacion);
        }

        public async Task<bool> ExisteUsuarioAsync(string username)
        {
            return await context.Usuarios.AnyAsync(x => x.NombreUsuario ==  username);

        }

        public async Task<Empleado> GuardarAsync(Empleado entity)
        {
            await context.Empleados.AddAsync(entity);
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

        public async Task<List<Empleado>> ListarAsync()
        {
            return await context.Empleados
                .Include(p => p.Docentes)
                .Include(p => p.Asignaturas)
                .Include(p => p.Usuario)
                .Include(p => p.Productos)
                .Include(p => p.SolicitudesInsumos)
                .ToListAsync();
        }

        public Empleado ModificarAsync(Empleado entity)
        {
            context.Empleados.Update(entity);
            return entity;
        }

        public async Task<Empleado> ObtenerPorIdAsync(int id)
        {
            return await context.Empleados
                .Include(p => p.Docentes)
                .Include(p => p.Asignaturas)
                .Include(p => p.Usuario)
                .Include(p => p.Productos)
                .Include(p => p.SolicitudesInsumos)
                .FirstAsync(x => x.IdEmpleado == id);
        }
    }
}
