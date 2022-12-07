using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Dominio.Exceptions;
using AppLaboratorio.Dominio.Interfaces;
using AppLaboratorio.Dominio.Interfaces.IRepository;
using AppLaboratorio.Dominio.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Aplicacion.Services
{
    public class EmpleadoService : IEmpleadoService<Empleado>
    {
        private readonly IEmpleadoRepository<Empleado> repository;
        public EmpleadoService(IEmpleadoRepository<Empleado> repository_)
        {
            repository = repository_;
        }
        public List<Empleado> Consultar(Func<Empleado, bool> expresion)
        {
            var productos = repository.Consultar(expresion);
            return productos.ToList();
        }

        public async Task Eliminar(int id)
        {
            var producto = await repository.ObtenerPorIdAsync(id);
            if (producto is null)
                throw new ValidatorException("El empleado no existe");

            repository.Eliminar(producto);
            await repository.GuardarCambiosAsync();
        }

        public async Task<Empleado> GuardarAsync(Empleado entity)
        {
            var response = await repository.GuardarAsync(entity);
            await ValidarEmpleado(entity);
            await ValidarUsuario(entity);
            await repository.GuardarCambiosAsync();
            return response;
        }

        private async Task ValidarUsuario(Empleado entity)
        {
            var reponse = await repository.ExisteUsuarioAsync(entity.Usuario.NombreUsuario);
            if (reponse)
                throw new ValidatorException($"El usuario {entity.Usuario.NombreUsuario} ya existe");
        }
        private async Task ValidarEmpleado(Empleado empleado)
        {
            var reponse = await repository.ExistAsync(empleado.Identificacion);
            if (reponse)
                throw new ValidatorException($"El empleado con identificacion {empleado.Identificacion} ya existe");
        }
        public async Task<List<Empleado>> ListarAsync()
        {
            return await repository.ListarAsync();
        }

        public async Task<Empleado> ModificarAsync(int id, Empleado entity)
        {
            var produc = await repository.ObtenerPorIdAsync(id);
            produc.ActualizarDatos(entity.PrimerNombre, entity.SegundoNombre, entity.PrimerApellido, entity.SegundoApellido);
            await repository.GuardarCambiosAsync();
            return repository.ModificarAsync(entity);
        }

        public async Task<Empleado> ObtenerPorIdAsync(int id)
        {
            return await repository.ObtenerPorIdAsync(id);
        }
    }
}
