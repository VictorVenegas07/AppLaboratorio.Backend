using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Dominio.Exceptions;
using AppLaboratorio.Dominio.Interfaces.IRepository;
using AppLaboratorio.Dominio.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Aplicacion.Services
{
    public class AsignaturaService : IAsignaturaService<Asignatura>
    {
        private readonly IAsignaturaRepository<Asignatura> repository;
        public AsignaturaService(IAsignaturaRepository<Asignatura> repository_)
        {
            repository = repository_;
        }
        public List<Asignatura> Consultar(Func<Asignatura, bool> expresion)
        {
            var productos = repository.Consultar(expresion);
            return productos.ToList();
        }

        public async Task Eliminar(int id)
        {
            var producto = await repository.ObtenerPorIdAsync(id);
            if (producto is null)
                throw new ValidatorException("El docente no existe");

            repository.Eliminar(producto);
            await repository.GuardarCambiosAsync();
        }

        public async Task<Asignatura> GuardarAsync(Asignatura entity)
        {
            await ValidarExistenciaAsignatura(entity.Nombre);
            var response = await repository.GuardarAsync(entity);
            await repository.GuardarCambiosAsync();
            return response;
        }
        private async Task ValidarExistenciaAsignatura(string nombre)
        {
            var respo = await repository.ExisteAsync(nombre);
            if (respo)
                throw new ValidatorException($"La asignatura {nombre} ya existe"); 
        }
        public async Task<List<Asignatura>> ListarAsync()
        {
            return await repository.ListarAsync();
        }

        public async Task<Asignatura> ModificarAsync(int id, Asignatura entity)
        {
            var asignatura = await repository.ObtenerPorIdAsync(id);
            asignatura.ActualizarDatos(entity.Grupo, entity.HorasLaboratorio);
            var resp =  repository.ModificarAsync(asignatura);
            await repository.GuardarCambiosAsync();
            return resp;
        }

        public async Task<Asignatura> ObtenerPorIdAsync(int id)
        {
            return await repository.ObtenerPorIdAsync(id);
        }
    }
}
