using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using AppLaboratorio.Dominio;
using AppLaboratorio.Dominio.Exceptions;

namespace AppLaboratorio.Infraestructura.Api.Mediator
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var detalle = new DetalleError() { type = exception.GetType(), traceId = Guid.NewGuid() };
            dynamic clase = new ExpandoObject();
            Errors errors = new Errors();
            var bb = exception is ValidatorException;
            switch (exception)
            {
                case ValidatorException e:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    detalle.status = (int)HttpStatusCode.BadRequest;
                    detalle.title = "Datos no validos";
                    errors.DatosNovalidos.Add(e.Message);
                    detalle.errors = errors;
                    break;
                //case ValidatorDTO e:
                //    context.Response.StatusCode = (int)HttpStatusCode.Accepted;
                //    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    detalle.status = (int)HttpStatusCode.BadRequest;
                    detalle.title = "Error en el servidor";
                    errors.DatosNovalidos.Add(exception.Message);
                    detalle.errors = errors;
                    break;
            }
            return context.Response.WriteAsync(JsonConvert.SerializeObject(detalle));
        }
    }

    public class DetalleError
    {
        public Type type { get; set; }
        public int status { get; set; }
        public string title { get; set; }
        public Guid traceId { get; set; }
        public Errors errors { get; set; }
    }

    public class Errors
    {
        public List<string> DatosNovalidos { get; set; }
        public Errors()
        {
            DatosNovalidos = new List<string>();
        }
    }
}
