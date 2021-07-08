using abmEmpleados.Models;
using abmEmpleados.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace abmEmpleados.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaEmpleados()
        {
            var result = EmpleadoService.GetAllEmpleados().Select(x => new EmpleadoModel { Apellido = x.Apellido, Codigo = x.Codigo, Nombre = x.Nombre,
                FechaAlta = (DateTime)x.FechaAlta, NumeroDocumento = (int)x.NumDocumento, TipoDocumento = TipoDocumentoModel.GetTipo((int)x.IdTipoDto)
            }).ToList();
            return PartialView("_listaEmpleados", result);
        }

        public ActionResult FormEmpleado()
        {
            return PartialView("_formEmpleado", new EmpleadoModel());
        }
    }
}