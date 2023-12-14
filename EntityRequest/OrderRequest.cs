using System.ComponentModel.DataAnnotations;

namespace EntityRequest
{
    public class OrderRequest
    {
        public int Id { get; set; }
        [Required]
        public int IdCustomer { get; set; }
        [Required]
        public string Descripcion { get; set; } = string.Empty;
    }
}
