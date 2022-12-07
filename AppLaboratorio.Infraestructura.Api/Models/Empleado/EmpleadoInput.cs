using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Usuario;

namespace AppLaboratorio.Infraestructura.Api.Models.Empleado
{
    public class EmpleadoInput:Persona
    {
        public UsuarioInput Usuario { get; set; }
    }
}
