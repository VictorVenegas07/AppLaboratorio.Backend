using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class AsignaturaDocente
    {
        public int IdAsignatura { get; set; }
        public Asignatura Asignatura { get; set; }

        public int IdDocente { get; set; }
        public Docente Docente { get; set; }
    }
}
