using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Dominio.Interfaces.IRepository;
using AppLaboratorio.Infraestructura.Datos.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Infraestructura.Datos.Repository
{
    public class AsignaturaDocenteRepository : IAsingnaturaDocenteRepository<AsignaturaDocente>
    {
        private readonly LaboratorioContext contexto;
        public AsignaturaDocenteRepository(LaboratorioContext context_)
        {
            contexto = context_;
        }
        public List<AsignaturaDocente> Consultar(Func<AsignaturaDocente, bool> expresion)
        {
           return contexto.AsignaturaDocentes
                .Include(x=> x.Docente)
                .Include(x => x.Asignatura)
                .Where(expresion).ToList();
        }

        public void Eliminar(AsignaturaDocente entity)
        {
            contexto.AsignaturaDocentes.Remove(entity);
        }

        public async Task<AsignaturaDocente> GuardarAsync(AsignaturaDocente entity)
        {
            await contexto.AsignaturaDocentes.AddAsync(entity);
            return entity;
        }

        public async Task GuardarCambiosAsync()
        {
             await contexto.SaveChangesAsync();
        }

        public async Task<List<AsignaturaDocente>> ListarAsync()
        {
            return await contexto.AsignaturaDocentes
                .Include(x => x.Docente)
                .Include(x => x.Asignatura)
                .ToListAsync();
        }

        public AsignaturaDocente ModificarAsync(AsignaturaDocente entity)
        {
            contexto.AsignaturaDocentes.Update(entity);
            return entity;
        }

        public async Task<AsignaturaDocente> ObtenerPorIdAsync(int id)
        {
           return await contexto.AsignaturaDocentes.FirstAsync(x=> x.IdAsignatura == id);

        }
    }
}
