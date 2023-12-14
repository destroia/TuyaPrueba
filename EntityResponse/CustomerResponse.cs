using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EntityResponse
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public  string Telefno { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}
