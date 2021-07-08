using abmEmpleados.Models;
using abmEmpleados.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace abmEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        public JsonResult GetAllTiposDocumentos()
        {
            var result = EmpleadoService.GetAllTiposDocumento();
            return Json(result.Select(x => new { code = x.Id, description = x.Descripcion}), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Edit(EmpleadoModel model)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                try
                {
                    EmpleadoService.SaveEmpleado(model.ToEmpleadoDB());
                    result = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ValidateDuplicateCode(string codigo)
        {
            var exist = EmpleadoService.ValidateCode(codigo);
            if (exist)
                return Json(true, JsonRequestBehavior.AllowGet);
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Eliminar(string codigo)
        {
            try
            {
                EmpleadoService.EliminarEmpleado(codigo);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmpleado(string codigo)
        {
            try
            {
                var ret = new EmpleadoModel(codigo);
                return Json(new { status = "Ok", value = ret}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}