using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class DetalleInsumo
    {
        [Key]
        public int IdDetalleInsumo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int IdSolicitudIsumo { get; set; }
        public SolicitudInsumo SolicitudInsumo { get; set; }
    }
}
