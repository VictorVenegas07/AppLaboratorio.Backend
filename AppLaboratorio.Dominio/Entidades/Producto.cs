using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppLaboratorio.Dominio.Entidades
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int IdEmpleado { get; set; }
        [JsonIgnore]
        public Empleado empleado { get; set; }
        public List<DetalleSolicitud> Detalles { get; set; }

        public void ActualizarDatos(string nombreProducto, string descripcion)
        {
            NombreProducto = nombreProducto;
            Descripcion = descripcion;
        }
        public void ModificarCantidad(int cantidad)
        {
            Cantidad = cantidad;
        }
    }
}
