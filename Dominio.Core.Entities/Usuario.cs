using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Usuario
    {
        [DisplayName("Usuario")]
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Usuario_u { get; set; }
        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Clave_u { get; set; }
        [DisplayName("Nombre de Usuario")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombreUsiario_u { get; set; }

    }
}
