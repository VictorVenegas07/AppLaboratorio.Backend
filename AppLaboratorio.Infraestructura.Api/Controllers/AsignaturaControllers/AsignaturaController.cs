using AppLaboratorio.Aplicacion.Services;
using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Asignatura;
using AppLaboratorio.Infraestructura.Api.Models.Docente;
using AppLaboratorio.Infraestructura.Datos.context;
using AppLaboratorio.Infraestructura.Datos.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppLaboratorio.Infraestructura.Api.Controllers.AsignaturaControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private readonly AsignaturaService service;
        private readonly AsignaturaRepository repository;
        private readonly IMapper mapper;
        public AsignaturaController(LaboratorioContext context, IMapper mapper_)
        {
            repository = new AsignaturaRepository(context);
            service = new AsignaturaService(repository);
            mapper = mapper_;

        }
        // GET: api/<AsignaturaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignaturaView>>> Get()
        {
            var response = await service.ListarAsync();
            return Ok(response.Select(x => mapper.Map<AsignaturaView>(x)));
        }

        // GET api/<AsignaturaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignaturaView>> Get(int id)
        {
            var response = await service.ObtenerPorIdAsync(id);
            return Ok(mapper.Map<AsignaturaView>(response));
        }


        // POST api/<AsignaturaController>
        [HttpPost]
        public async Task<ActionResult<AsignaturaView>> Post(AsignaturaInput asignaturaInput)
        {
            var docente = mapper.Map<Asignatura>(asignaturaInput);
            var reponse = await service.GuardarAsync(docente);
            return Ok(mapper.Map<AsignaturaView>(reponse));
        }

        // PUT api/<AsignaturaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AsignaturaView>> Put(int id, AsignaturaInput asignaturaInput)
        {
            var resp = await service.ModificarAsync(id, mapper.Map<Asignatura>(asignaturaInput));
            return Ok(mapper.Map<AsignaturaView>(resp));
        }

        // DELETE api/<AsignaturaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            await service.Eliminar(id);
            return Ok("Se elimino con exito!!");
        }
    }
}
