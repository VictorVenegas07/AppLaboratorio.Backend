using System.ComponentModel.DataAnnotations;

namespace AppLaboratorio.Infraestructura.Api.Models.Persona
{
    public class PersonaInput
    {
        [Required(ErrorMessage = "la Identificacion es requerido")]
        [MaxLength(10, ErrorMessage = "Identificacion debe tener 10 caracteres o 6 por lo menos "), MinLength(6, ErrorMessage = "Identificacion debe tener 10 caracteres o 6 por lo menos")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "el Primer Nombre es requerido")]
        [MaxLength(10, ErrorMessage = "Primer Nombre debe tener 10 caracteres o 3 por lo menos "), MinLength(3, ErrorMessage = "Primer Nombre debe tener 10 caracteres o 3 por lo menos")]
        public string PrimerNombre { get; set; }
        [Required(ErrorMessage = "el Segundo Nombre es requerido")]
        [MaxLength(10, ErrorMessage = "Segundo Nombre debe tener 10 caracteres o 3 por lo menos "), MinLength(3, ErrorMessage = "Segundo Nombre debe tener 10 caracteres o 3 por lo menos")]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "el Primer apellido es requerido")]
        [MaxLength(10, ErrorMessage = "Primer apellido debe tener 10 caracteres o 3 por lo menos "), MinLength(3, ErrorMessage = "Primer apellido debe tener 10 caracteres o 3 por lo menos")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "el primer apellido es requerido")]
        [MaxLength(10, ErrorMessage = "Primer apellido debe tener 10 caracteres o 3 por lo menos "), MinLength(3, ErrorMessage = "Primer apellido debe tener 10 caracteres o 3 por lo menos")]
        public string SegundoApellido { get; set; }
        public int IdUsuario { get; set; }
    }
}
