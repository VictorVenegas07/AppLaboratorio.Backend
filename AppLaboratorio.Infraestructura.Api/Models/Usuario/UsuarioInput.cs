using System.ComponentModel.DataAnnotations;

namespace AppLaboratorio.Infraestructura.Api.Models.Usuario
{
    public class UsuarioInput
    {
        [Required(ErrorMessage = "el Nombre Usuario apellido es requerido")]
        [MaxLength(20, ErrorMessage = "Nombre Usuario debe tener 20 caracteres o 8 por lo menos "), MinLength(8, ErrorMessage = "Nombre Usuario debe tener 20 caracteres o 8 por lo menos")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "la Contraseña es requerido")]
        [MaxLength(15, ErrorMessage = "contraseña  debe tener 15 caracteres o 8 por lo menos "), MinLength(8, ErrorMessage = "contraseña debe tener 15 caracteres o 8 por lo menos")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "el email es requerido")]
        [MaxLength(30, ErrorMessage = "email debe tener 30 caracteres o 10 por lo menos "), MinLength(10, ErrorMessage = "Nombre Usuario debe tener 30 caracteres o 10 por lo menos")]
        [RegularExpression(@"^[\w-_]+(\.[\w!#$%'*+\/=?\^`{|}]+)*@((([\-\w]+\.)+[a-zA-Z]{2,20})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$")]
        public string Email { get; set; }
        public int IdCargo { get; set; }
    }
}
