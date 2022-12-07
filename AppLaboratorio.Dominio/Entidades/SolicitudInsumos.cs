using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class SolicitudInsumo
    {
        [Key]
        public int IdSolicitudIsumo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public Compra Compra { get; set; }
        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }
        public List<DetalleInsumo> Insumos { get; set; }
    }
}
