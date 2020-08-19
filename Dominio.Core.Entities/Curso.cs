using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entities
{
    public class Curso
    {

        [DisplayName("Codigo de curso")]
        public int Id_cur { get; set; }
        [DisplayName("Nombre del curso")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "No mas de 03 caracteres")]
        public string Nombre_c { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Correro_c { get; set; }
        public int Credito_c { get; set; }


    }
}
