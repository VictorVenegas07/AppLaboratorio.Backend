using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Dominio.Interfaces;
using AppLaboratorio.Infraestructura.Datos.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Infraestructura.Datos.Repository
{
    public class ProductoRepository : IRepositoryProducto<Producto>
    {
        private readonly LaboratorioContext context;
        public ProductoRepository(LaboratorioContext context_)
        {
            context = context_;
        }
        public List<Producto> Consultar(Func<Producto, bool> expresion)
        {
           return context.Productos
                .Include(p=> p.Detalles)
                .Include(p=>p.empleado)
                .Where(expresion).ToList();
        }

        public async Task<Producto> ConsultarPorCamposAsync(string codigoProducto, string nombreProducto)
        {
            return await context.Productos.FirstOrDefaultAsync(x=> x.CodigoProducto == codigoProducto || x.NombreProducto == nombreProducto);
        }

        public void Eliminar(Producto entity)
        {
            context.Productos.Remove(entity);
        }

        public async Task<bool> ExisteAsync(string codigoProducto)
        {
            return await context.Productos.AnyAsync(co=> co.CodigoProducto == codigoProducto);
        }

        public async Task<Producto> GuardarAsync(Producto entity)
        {
            await context.Productos.AddAsync(entity);
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

        public async Task<List<Producto>> ListarAsync()
        {
            return await context.Productos.ToListAsync();
        }

        public Producto ModificarAsync(Producto entity)
        {
            context.Productos.Update(entity);
            return entity;
        }

        public Task<Producto> ObtenerPorIdAsync(int id)
        {
            return context.Productos.FirstAsync(x => x.IdProducto == id);
        }
    }
}
