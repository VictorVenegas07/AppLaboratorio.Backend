using AppLaboratorio.Aplicacion.Services;
using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Empleado;
using AppLaboratorio.Infraestructura.Api.Models.Producto;
using AppLaboratorio.Infraestructura.Datos.context;
using AppLaboratorio.Infraestructura.Datos.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppLaboratorio.Infraestructura.Api.Controllers.EmpleadoControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoService service;
        private readonly EmpleadoRepository repository;
        private readonly IMapper mapper;

        public EmpleadoController(LaboratorioContext context, IMapper mapper_)
        {
            repository = new EmpleadoRepository(context);
            service = new EmpleadoService(repository);
            mapper = mapper_;

        }
        // GET: api/<EmpleadoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoView>>>  Get()
        {
            var response = await service.ListarAsync();
            return Ok(response.Select(x => mapper.Map<EmpleadoView>(x)));
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoView>> Get(int id)
        {
            var response = await service.ObtenerPorIdAsync(id);
            return Ok(mapper.Map<EmpleadoView>(response));
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public async Task<ActionResult<EmpleadoView>>  Post(EmpleadoInput empleadoInput)
        {
            var empleado = mapper.Map<Empleado>(empleadoInput);
            var reponse = await service.GuardarAsync(empleado);
            return Ok(mapper.Map<EmpleadoView>(reponse));
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadoView>> Put(int id, EmpleadoInput empleadoInput)
        {
            var resp = await service.ModificarAsync(id, mapper.Map<Empleado>(empleadoInput));
            return Ok(mapper.Map<EmpleadoView>(resp));
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            await service.Eliminar(id);
            return Ok("Se elimino con exito!!");
        }
    }
}
