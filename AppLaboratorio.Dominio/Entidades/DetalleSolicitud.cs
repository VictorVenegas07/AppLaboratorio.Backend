using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class DetalleSolicitud
    {
        [Key]
        public int IdDetalleSolicitud { get; set; }
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public int IdSolicitud { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
