using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Docente:Persona
    {
        [Key]
        public int IdDocente { get; set; }
        public int IdEmpleado { get; set; }
        public List<AsignaturaDocente> Asignaturas { get; set; }
        public List<Solicitud> Solicitudes { get; set; }
        public Empleado Empleado { get; set; }
    }
}
