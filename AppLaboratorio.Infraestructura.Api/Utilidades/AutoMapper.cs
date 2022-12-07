using AppLaboratorio.Dominio.Entidades;
using AppLaboratorio.Infraestructura.Api.Models.Asignatura;
using AppLaboratorio.Infraestructura.Api.Models.Cargo;
using AppLaboratorio.Infraestructura.Api.Models.Docente;
using AppLaboratorio.Infraestructura.Api.Models.Empleado;
using AppLaboratorio.Infraestructura.Api.Models.Producto;
using AppLaboratorio.Infraestructura.Api.Models.Usuario;
using AutoMapper;

namespace AppLaboratorio.Infraestructura.Api.Utilidades
{
    public class AutoMap:Profile
    {
        public AutoMap()
        {
            #region "Mapeo del Producto"
            //Inputn
            CreateMap<ProductoInput, Producto>();
            //Output - view
            CreateMap<Producto, ProductoView>();
            #endregion

            #region "Mapeo del Empleado"
            //Inputn
            CreateMap<EmpleadoInput, Empleado>();
            //Output - view
            CreateMap<Empleado, EmpleadoView>();
            #endregion

            #region "Mapeo del Docente"
            //Inputn
            CreateMap<DocenteInput, Docente>();
            //Output - view
            CreateMap<Docente, DocenteView>();
            #endregion

            #region "Mapeo del Usuario"
            //Inputn
            CreateMap<UsuarioInput, Usuario>();
            //Output - view
            CreateMap<Usuario, UsuarioView>();

            #endregion

            #region "Mapeo del Cargo"
            //Inputn
            //Output - view
            CreateMap<Cargo, CargoView>();

            #endregion
            #region "Mapeo del Asignatura"
            //Inputn
            CreateMap<AsignaturaInput, Asignatura>();
            //Output - view
            CreateMap<Asignatura, AsignaturaView>();


            #endregion
        }
    }
}
