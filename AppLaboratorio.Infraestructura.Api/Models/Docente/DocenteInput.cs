using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Usuario;

namespace AppLaboratorio.Infraestructura.Api.Models.Docente
{
    public class DocenteInput:Persona
    {
        public UsuarioInput Usuario { get; set; }
        public int IdEmpleado { get; set; }

    }
}
