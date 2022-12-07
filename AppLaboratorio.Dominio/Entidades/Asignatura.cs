using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Asignatura
    {
        [Key]
        public int IdAsignatura { get; set; }
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public DateTime HorasLaboratorio { get; set; }
        public List<AsignaturaDocente> Docentes { get; set; }
        public int IdEmpleado { get; set; }
        [JsonIgnore]
        public Empleado Empleado { get; set; }

        public void ActualizarDatos(string grupo, DateTime horasLaboratorio)
        {
            Grupo = grupo;
            HorasLaboratorio = horasLaboratorio;
        }
    }
}
