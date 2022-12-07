using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Interfaces
{
    public interface IRepositoryProducto<T> : IRepositoryBase<T>
    {
        Task<bool> ExisteAsync(string codigoProducto);
        Task<T> ConsultarPorCamposAsync( string codigoProducto, string nombreProducto);

    }
}
