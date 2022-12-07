using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Persona;
using AppLaboratorio.Infraestructura.Api.Models.Usuario;

namespace AppLaboratorio.Infraestructura.Api.Models.Docente
{
    public class DocenteView: PersonaInput
    {
        public int IdEmpleado { get; set; }
        public UsuarioView Usuario { get; set; }
    }
}
