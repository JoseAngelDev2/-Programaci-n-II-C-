using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserCRUDAPIs.api.ProductsDTOs
{
    public class ProductListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}