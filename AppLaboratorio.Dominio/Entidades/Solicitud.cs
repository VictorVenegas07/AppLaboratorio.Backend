using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Solicitud
    {
        [Key]
        public int IdSolicitud { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Estado { get; set; }
        public string NombreAsignatura { get; set; }
        public int IdDocente { get; set; }
        public Docente Docente { get; set; }
        public RespuestaSolicitud Respuesta { get; set; }
        public List<DetalleSolicitud> DetalleSolicitudes { get; set; }
    }
}
