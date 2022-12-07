namespace AppLaboratorio.Infraestructura.Api.Models.Usuario
{
    public class UsuarioInput
    {
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public int IdCargo { get; set; }
    }
}
