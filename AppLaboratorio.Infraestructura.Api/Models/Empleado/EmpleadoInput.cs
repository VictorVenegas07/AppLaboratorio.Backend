using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Persona;
using AppLaboratorio.Infraestructura.Api.Models.Usuario;

namespace AppLaboratorio.Infraestructura.Api.Models.Empleado
{
    public class EmpleadoInput: PersonaInput
    {
        public UsuarioInput Usuario { get; set; }
    }
}
