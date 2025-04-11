using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoutainShop.Domain.Models;
using MoutainShopService;

namespace MoutainShop.WebApi.Controllers
{
    [Route("api/products/")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private ProductService productService;
        public ProductControllers(ProductService productService)
        {
            this.productService = productService;
        }


        [Route("add")]
        [HttpPost(Name = "PostProduct")]
        public async Task<Product> Post(Product product)
        {
            await productService.AddProduct(product);

            return product;
        }

        [Route("get")]
        [HttpGet(Name = "GetProduct")]
        public async Task<Product> Get(int id)
        {
            var product = await productService.GetProductById(id);

            if (product == null) 
            {
                throw new Exception("product not found");
            }

            return product;
        }

        [Route("delete")]
        [HttpDelete(Name = "Delete")]
        public async Task Delete(int id)
        {
            
            await productService.DeleteProduct(id);

        }

        [Route("update")]
        [HttpPut(Name = "UpdateProduct")]
        public async Task<Product> Put(Product product)
        {
            var updatedProduct = await productService.UpdateProduct(product);

            return updatedProduct;
        }

        [Route("getAll")]
        [HttpGet(Name = "getAll")]
        public async Task<List<Product>> GetProducts()
        {
            var allProducts = await productService.GetAllProducts();

            return allProducts;
        }
    }
}
