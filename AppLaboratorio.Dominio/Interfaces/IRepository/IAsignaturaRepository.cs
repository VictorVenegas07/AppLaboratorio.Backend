using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Interfaces.IRepository
{
    public interface IAsignaturaRepository<T>:IRepositoryBase<T>
    {
        Task<bool> ExisteAsync(string nombre);
    }
}
