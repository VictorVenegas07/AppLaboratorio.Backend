using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public int IdSolicitudIsumo { get; set; }
        public SolicitudInsumo Insumo { get; set; }
    }
}
