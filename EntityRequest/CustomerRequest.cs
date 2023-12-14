using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRequest
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]

        public string Nombre { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        public string Documento { get; set; } = string.Empty;
        public string Telefno { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
