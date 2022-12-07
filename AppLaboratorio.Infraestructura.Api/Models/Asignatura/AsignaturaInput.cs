using AppLaboratorio.Dominio.Entidades;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppLaboratorio.Infraestructura.Api.Models.Asignatura
{
    public class AsignaturaInput
    {
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(20, ErrorMessage = "Nombre debe tener 20 caracteres o 7 por lo menos "), MinLength(7, ErrorMessage = "Identificacion debe tener 10 caracteres o 6 por lo menos")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El grupo es requerido")]
        [MaxLength(5, ErrorMessage = "grupo debe tener 5 caracteres o 3 por lo menos "), MinLength(3, ErrorMessage = "Identificacion debe tener 5 caracteres o 3 por lo menos")]
        public string Grupo { get; set; }
        [Required(ErrorMessage = "El grupo es requerido")]
        public DateTime HorasLaboratorio { get; set; }
        [Required(ErrorMessage = "El Id de empleado es requerido")]
        public int IdEmpleado { get; set; }
    }
}
