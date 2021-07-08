using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace abmEmpleados.Models
{
    public class EmpleadoModel
    {
        [Required]
        [DisplayName("Codigo")]
        public string Codigo { get; set; }
        [Required]
        [DisplayName("Apellido")]
        public string Apellido { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Fecha de alta")]
        public DateTime FechaAlta { get; set; }
        [Required]
        [DisplayName("Tipo de documento")]
        public TipoDocumentoModel TipoDocumento { get; set; }
        [Required]
        [DisplayName("Número de documento")]
        public int NumeroDocumento { get; set; }

        public string FechaAltaString
        {
            get
            {
                if (FechaAlta != null)
                {
                    return FechaAlta.ToString("yyyy-MM-dd");
                }
                return string.Empty;
            }
        }

        public empleados ToEmpleadoDB()
        {
            empleados result = new empleados()
            {
                Codigo = this.Codigo.ToString(),
                Apellido = this.Apellido,
                Nombre = this.Nombre,
                FechaAlta = this.FechaAlta,
                IdTipoDto = this.TipoDocumento.Codigo,
                NumDocumento = this.NumeroDocumento,
                Estado = "A",
            };
            return result;
        }

        public EmpleadoModel()
        {
        }

        public EmpleadoModel(string code)
        {
            using (var _context = new EpleadosEntities())
            {
                var exist = _context.empleados.FirstOrDefault(x => x.Estado == "A" && x.Codigo == code);

                this.Codigo = exist.Codigo;
                this.Apellido = exist.Apellido;
                this.Nombre = exist.Nombre;
                this.FechaAlta = (DateTime)exist.FechaAlta;
                this.TipoDocumento = TipoDocumentoModel.GetTipo((int)exist.IdTipoDto);
                this.NumeroDocumento = (int)exist.NumDocumento;
            }
        }
    }
}