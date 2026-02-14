using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserCRUDAPIs.ProductsDTOs
{
    public class ProductsDTOs
    {
        [Required]
        public int Id {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public decimal Price {get; set;}
        [Required]
        public int Stock {get; set;}
        [Required]
        public string State {get; set;}
    }
}