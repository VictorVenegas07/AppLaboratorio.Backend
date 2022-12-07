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
    public class ProductoService : IProductoService<Producto>
    {
        private readonly IRepositoryProducto<Producto> repositoryProducto;
        public ProductoService(IRepositoryProducto<Producto> _repositoryProducto)
        {
            repositoryProducto = _repositoryProducto;
        }
        public List<Producto> Consultar(Func<Producto, bool> expresion)
        {
            var productos = repositoryProducto.Consultar(expresion);
            return productos.ToList();
        }

        public async Task Eliminar(int id)
        {
            var producto = await repositoryProducto.ObtenerPorIdAsync(id);
            if (producto is null)
                throw new ValidatorException("El producto no existe");

            repositoryProducto.Eliminar(producto);
            await repositoryProducto.GuardarCambiosAsync();
        }   

        public async Task<Producto> GuardarAsync(Producto entity)
        {
            var response = await repositoryProducto.GuardarAsync(entity);
            await ValidarExistencia(entity.CodigoProducto);
            await repositoryProducto.GuardarCambiosAsync();
            return response;
        }
        private async Task ValidarExistencia(string codigoProducto)
        {
            var resp = await repositoryProducto.ExisteAsync(codigoProducto);
            if (resp)
                throw new ValidatorException("El producto ya existe");
        }

        public async Task<List<Producto>> ListarAsync()
        {
          return await repositoryProducto.ListarAsync();  
        }

        public async Task<Producto> ModificarAsync(int id, Producto entity)
        {
            var produc = await repositoryProducto.ObtenerPorIdAsync(id);
            produc.ActualizarDatos(entity.NombreProducto, entity.Descripcion);
            await repositoryProducto.GuardarCambiosAsync();
            return repositoryProducto.ModificarAsync(entity);
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
          return await repositoryProducto.ObtenerPorIdAsync(id);
        }
    }
}
