using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using UserCRUDAPIs.Entities;
using UserCRUDAPIs.ProductsDTOs;
using UserCRUDAPIs.api.ProductsDTOs;
using AppProductDb = UserCRUDAPIs.Data.DbContextProduct.AppDbContextProduct;

namespace UserCRUDAPIs.ProductsControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppProductDb appProduct;

        public ProductsController(AppProductDb _db) 
        {
            appProduct = _db;
        } 

        [HttpGet]
        public ActionResult<IEnumerable<ProductListDTO>> GetAllProducts()
        {
            var products = appProduct.products.AsNoTracking().ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Products> GetProductById(int id)
        {
            var product = appProduct.products.Where(x => x.Id == id)
            .FirstOrDefault();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductsDTOs.ProductsDTOs product, int id)
        {
            var p = new Products
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                State = product.State
            };

            appProduct.products.Add(p);
            await appProduct.SaveChangesAsync();

             var response = new ProductsDTOs.ProductsDTOs
            {
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                State = product.State
            };
            return CreatedAtAction(nameof(GetProductById), new {id = product.Id}, response);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Products>> UpdateProducts(int id, Products products)
        {
            var p = await appProduct.products.FindAsync(id);

            if (p is null)
            {
                return NotFound();
            }

            p.Name = products.Name;
            p.Price = products.Price;
            p.State = products.State;
            p.Stock = products.Stock;

            appProduct.Entry(p).State = EntityState.Modified;

            try
            {
                await appProduct.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (!appProduct.products.Any(p => p.Id == id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProduct(int id)
        {
            var product = await appProduct.products.FindAsync(id);

            if (product is null)
            {
                return NotFound();
            }

            appProduct.products.Remove(product);
            await appProduct.SaveChangesAsync();

            return NoContent();

        }
    }
}