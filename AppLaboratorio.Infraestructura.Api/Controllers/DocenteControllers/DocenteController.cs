using AppLaboratorio.Aplicacion.Services;
using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Docente;
using AppLaboratorio.Infraestructura.Api.Models.Empleado;
using AppLaboratorio.Infraestructura.Datos.context;
using AppLaboratorio.Infraestructura.Datos.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppLaboratorio.Infraestructura.Api.Controllers.DocenteControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly DocenteService service;
        private readonly DocenteRepository repository;
        private readonly IMapper mapper;

        public DocenteController(LaboratorioContext context, IMapper mapper_)
        {
            repository = new DocenteRepository(context);
            service = new DocenteService(repository);
            mapper = mapper_;

        }
        // GET: api/<DocenteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocenteView>>> Get()
        {
            var response = await service.ListarAsync();
            return Ok(response.Select(x => mapper.Map<DocenteView>(x)));
        }

        // GET api/<DocenteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocenteView>> Get(int id)
        {
            var response = await service.ObtenerPorIdAsync(id);
            return Ok(mapper.Map<DocenteView>(response));
        }

        // POST api/<DocenteController>
        [HttpPost]
        public async Task<ActionResult<DocenteView>> Post(DocenteInput docenteInput)
        {
            var docente = mapper.Map<Docente>(docenteInput);
            var reponse = await service.GuardarAsync(docente);
            return Ok(mapper.Map<DocenteView>(reponse));
        }

        // PUT api/<DocenteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DocenteView>> Put(int id, DocenteInput docenteInput)
        {
            var resp = await service.ModificarAsync(id, mapper.Map<Docente>(docenteInput));
            return Ok(mapper.Map<DocenteView>(resp));
        }

        // DELETE api/<DocenteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            await service.Eliminar(id);
            return Ok("Se elimino con exito!!");
        }
    }
}
