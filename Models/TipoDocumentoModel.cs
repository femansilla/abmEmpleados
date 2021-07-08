using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace abmEmpleados.Models
{
    public class TipoDocumentoModel
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }

        public static TipoDocumentoModel GetTipo(int id)
        {
            var ret = new TipoDocumentoModel();
            ret.Codigo = id;

            using (var _context = new EpleadosEntities())
            {
                ret.Descripcion = _context.tiposDocumentos.FirstOrDefault(x => x.Estado == "A" && x.Id == ret.Codigo).Descripcion;
            }

            return ret;
        }
    }

    
}