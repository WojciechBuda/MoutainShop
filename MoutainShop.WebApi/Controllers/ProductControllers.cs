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
        public ProductControllers()
        {
            productService = StaticProductService.ProductService;
        }


        [Route("add")]
        [HttpPost(Name = "PostProduct")]
        public Product Post(Product product)
        {
            productService.AddProduct(product);

            return product;
        }

        [Route("get")]
        [HttpGet(Name = "GetProduct")]
        public Product Get(int id)
        {
            var product = productService.GetProductById(id);

            if (product == null) 
            {
                throw new Exception("product not found");
            }

            return product;
        }

        [Route("delete")]
        [HttpDelete(Name = "Delete")]
        public void Delete(int id)
        {
            
            productService.DeleteProduct(id);

        }

        [Route("update")]
        [HttpPut(Name = "UpdateProduct")]
        public Product Put(Product product)
        {
            var updatedProduct = productService.UpdateProduct(product);

            return updatedProduct;
        }

        [Route("getAll")]
        [HttpGet(Name = "getAll")]
        public List<Product> GetProducts()
        {
            var allProducts = productService.GetAllProducts();

            return allProducts;
        }
    }
}
