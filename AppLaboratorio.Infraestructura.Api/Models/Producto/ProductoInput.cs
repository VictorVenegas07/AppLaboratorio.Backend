using System.ComponentModel.DataAnnotations;

namespace AppLaboratorio.Infraestructura.Api.Models.Producto
{
    public class ProductoInput
    {
        [Required(ErrorMessage = "la codigo del producto es requerido")]
        [MaxLength(8, ErrorMessage = "Nombre Usuario debe tener 15 caracteres o 8 por lo menos ")]
        public string CodigoProducto { get; set; }
        [Required(ErrorMessage ="El nombre del producto es requerido")]
        [MaxLength(30, ErrorMessage = "El nombre de producto debe tener 30 caracteres o por lo menos 3")]
        [MinLength(3, ErrorMessage ="El nombre de producto debe tener 30  caracteres o por lo menos 3")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [MaxLength(50, ErrorMessage = "El nombre de producto debe tener 50 caracteres o por lo menos 3")]
        [MinLength(7, ErrorMessage = "El nombre de producto debe tener 50 caracteres o por lo menos 7")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "la cantidad del producto es requerido")]
        [Range(1, 100)]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El id empleado del producto es requerido")]
        public int IdEmpleado { get; set; }
    }
}
