namespace AppLaboratorio.Infraestructura.Api.Models.Producto
{
    public class ProductoInput
    {
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int IdEmpleado { get; set; }
    }
}
