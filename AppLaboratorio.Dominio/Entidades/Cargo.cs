using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }
        [JsonIgnore]
        public List<Usuario> Usuarios { get; set; }
    }
}
