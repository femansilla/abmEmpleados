using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace abmEmpleados.Services
{
    public class EmpleadoService
    {
        private static EpleadosEntities _context = new EpleadosEntities();

        public static List<empleados> GetAllEmpleados()
        {
            return _context.empleados.Where(x => x.Estado == "A").ToList();
        }

        public static List<tiposDocumentos> GetAllTiposDocumento()
        {
            return _context.tiposDocumentos.Where(x => x.Estado == "A").ToList();
        }

        public static void SaveEmpleado(empleados value)
        {
            try
            {
                string date = value.FechaAlta.Value.ToString("dd-MM-yyyy");
                _context.SP_SaveEmpleado(value.Codigo, value.Apellido, value.Nombre, date, value.IdTipoDto, value.NumDocumento);
                //_context.empleados.Add(value);
                //_context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidateCode(string codigo)
        {
            try
            {
                return _context.empleados.FirstOrDefault(x => x.Codigo == codigo) != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void EliminarEmpleado(string codigo)
        {
            try
            {
                var deleted = _context.empleados.FirstOrDefault(x => x.Codigo == codigo);
                deleted.Estado = "I";
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}