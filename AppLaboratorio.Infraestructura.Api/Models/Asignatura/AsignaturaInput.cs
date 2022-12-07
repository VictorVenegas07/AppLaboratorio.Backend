using AppLaboratorio.Dominio.Entidades;
using System.Collections.Generic;
using System;

namespace AppLaboratorio.Infraestructura.Api.Models.Asignatura
{
    public class AsignaturaInput
    {
        public string Nombre { get; set; }
        public string Grupo { get; set; }
        public DateTime HorasLaboratorio { get; set; }
        public int IdEmpleado { get; set; }
    }
}
