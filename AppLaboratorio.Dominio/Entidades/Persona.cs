using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Persona
    {
        public string Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int IdUsuario { get; set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }

        public void ActualizarDatos(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
        {
            PrimerApellido = primerApellido;
            PrimerNombre = primerNombre;
            SegundoApellido = segundoApellido;
            SegundoNombre = segundoNombre;
        }
    }
}
