using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Interfaces.IRepository
{
    public interface IDocenteRepository<T>:IRepositoryBase<T>
    {
        Task<bool> ExisteUsuarioAsync(string username);
        Task<bool> ExistAsync(string identificacion);
    }
}
