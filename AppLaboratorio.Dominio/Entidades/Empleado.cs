using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Empleado:Persona
    {
        [Key]
        public int IdEmpleado { get; set; }
        [JsonIgnore]
        public List<Docente> Docentes { get; set; }
        [JsonIgnore]
        public List<Asignatura> Asignaturas { get; set; }
        [JsonIgnore]
        public List<Producto> Productos { get; set; }
        [JsonIgnore]
        public List<SolicitudInsumo> SolicitudesInsumos { get; set; }

    }
}
