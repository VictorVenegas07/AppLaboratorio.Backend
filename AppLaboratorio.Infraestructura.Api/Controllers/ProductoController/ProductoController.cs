using AppLaboratorio.Aplicacion.Services;
using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Producto;
using AppLaboratorio.Infraestructura.Datos.context;
using AppLaboratorio.Infraestructura.Datos.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppLaboratorio.Infraestructura.Api.Controllers.ProductoController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService service;
        private readonly ProductoRepository repository;
        private readonly IMapper mapper;
        public ProductoController(LaboratorioContext context, IMapper mapper_)
        {
            repository = new ProductoRepository(context);
            service = new ProductoService(repository);
            mapper = mapper_;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoView>>> Get()
        {
            var response = await service.ListarAsync();
            return Ok(response.Select(x=> mapper.Map<ProductoView>(x)));
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoView>> GetProductoId(int id)
        {
           var response = await service.ObtenerPorIdAsync(id);
            return Ok(mapper.Map<ProductoView>(response));

        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<ActionResult<ProductoView>> Post(ProductoInput productoInput)
        {
            var producto = mapper.Map<Producto>(productoInput);
            var reponse  = await service.GuardarAsync(producto);
            return Ok(mapper.Map<ProductoView>(reponse));
            
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoView>> PutProducto(int id, ProductoInput productoInput )
        {
            var resp = await service.ModificarAsync(id, mapper.Map<Producto>(productoInput));
            return Ok(mapper.Map<ProductoView>(resp));
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            await service.Eliminar(id);
            return Ok("Se elimino con exito!!");
        }
    }
}
