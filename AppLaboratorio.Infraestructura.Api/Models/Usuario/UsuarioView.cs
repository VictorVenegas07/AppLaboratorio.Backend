using AppLaboratorio.Infraestructura.Api.Models.Cargo;

namespace AppLaboratorio.Infraestructura.Api.Models.Usuario
{
    public class UsuarioView
    {
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public int IdCargo { get; set; }
        public CargoView Cargo { get; set; }
    }
}
