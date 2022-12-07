using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Interfaces.IService
{
    public interface IServiceBase<T>
    {
        Task<T> GuardarAsync(T entity);
        Task<T> ModificarAsync(int id, T entity);
        Task Eliminar(int id);
        Task<List<T>> ListarAsync();
        Task<T> ObtenerPorIdAsync(int id);
        List<T> Consultar(Func<T, bool> expresion);
    }
}
