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
    public class DocenteService : IDocenteService<Docente>
    {
        private readonly IDocenteRepository<Docente> repository;
        public DocenteService(IDocenteRepository<Docente> _docenteRepository)
        {
            repository = _docenteRepository;
        }
        public List<Docente> Consultar(Func<Docente, bool> expresion)
        {
            var productos = repository.Consultar(expresion);
            return productos.ToList();
        }

        public async Task Eliminar(int id)
        {
            var producto = await repository.ObtenerPorIdAsync(id);
            if (producto is null)
                throw new ValidatorException("El producto no existe");

            repository.Eliminar(producto);
            await repository.GuardarCambiosAsync();
        }
        public async Task<Docente> GuardarAsync(Docente entity)
        {
            await ValidarEmpleado(entity);
            //await ValidarUsuario(entity);
            var response = await repository.GuardarAsync(entity);
            await repository.GuardarCambiosAsync();
            return response;
        }

        private async Task ValidarUsuario(Docente entity)
        {
            var reponse = await repository.ExisteUsuarioAsync(entity.Usuario.NombreUsuario);
            if (reponse)
                throw new ValidatorException($"El usuario {entity.Usuario.NombreUsuario} ya existe");
        }
        private async Task ValidarEmpleado(Docente empleado)
        {
            var reponse = await repository.ExistAsync(empleado.Identificacion);
            if (reponse)
                throw new ValidatorException($"El docente con identificacion {empleado.Identificacion} ya existe");
        }

        public async Task<List<Docente>> ListarAsync()
        {
            return await repository.ListarAsync();
        }

        public async Task<Docente> ModificarAsync(int id, Docente entity)
        {
            var produc = await repository.ObtenerPorIdAsync(id);
            produc.ActualizarDatos(entity.PrimerNombre, entity.SegundoNombre, entity.PrimerApellido, entity.SegundoApellido);
            await repository.GuardarCambiosAsync();
            return repository.ModificarAsync(entity);
        }

        public async Task<Docente> ObtenerPorIdAsync(int id)
        {
            return await repository.ObtenerPorIdAsync(id);
        }
    }
}
