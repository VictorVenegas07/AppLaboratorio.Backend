using AppLaboratorio.Infraestructura.Api.Controllers.EmpleadoControllers;
using AppLaboratorio.Infraestructura.Api.Controllers.ProductoController;
using AppLaboratorio.Infraestructura.Api.Models.Producto;
using AppLaboratorio.Infraestructura.Api.Utilidades;
using AppLaboratorio.Infraestructura.Datos.context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace TestLaboratorio
{
    public class TestProducto
    {
        private static IMapper _mapper;
        private readonly ProductoController controller;
        public TestProducto()
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
            controller = new ProductoController(new LaboratorioContext(), _mapper);
        }
        [Fact]
        public async void TestGuardadoProducto()
        {
            var producto = new ProductoInput
            {
                CodigoProducto = "12JASD",
                NombreProducto = "Alchol 1L",
                Cantidad = 10,
                Descripcion = "Ninguna",
                IdEmpleado = 1
            };
            var res = await controller.Post(producto);
            Assert.IsNotType<ActionResult<ProductoView>>(res);
        }
    }
}
