using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<T> GuardarAsync(T entity);
        T ModificarAsync(T entity);
        void Eliminar(T entity);
        Task<List<T>> ListarAsync();
        Task<T> ObtenerPorIdAsync(int id);
        List<T> Consultar(Func<T, bool> expresion);
        Task GuardarCambiosAsync();

    }
}
