using AppLaboratorio.Infraestructura.Api.Controllers.DocenteControllers;
using AppLaboratorio.Infraestructura.Api.Controllers.ProductoController;
using AppLaboratorio.Infraestructura.Api.Models.Docente;
using AppLaboratorio.Infraestructura.Api.Models.Producto;
using AppLaboratorio.Infraestructura.Api.Utilidades;
using AppLaboratorio.Infraestructura.Datos.context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestLaboratorio
{
    public class TestDocente
    {
        private static IMapper _mapper;
        private readonly DocenteController controller;
        public TestDocente()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMap());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            controller = new DocenteController(new LaboratorioContext(), _mapper);
        }
        [Fact]
        public async void TestGuardadoDocente()
        {
            var docenteInput = new DocenteInput
            {
               IdEmpleado = 1,
               PrimerNombre = "Nemer",
               SegundoNombre = "Jose",
               PrimerApellido = "Velandia",
               SegundoApellido = "Soto",
               Identificacion = "119234423",
               IdUsuario = 1
            };
            var res = await controller.Post(docenteInput);
            Assert.IsNotType<ActionResult<ProductoView>>(res);
        }
    }
}
