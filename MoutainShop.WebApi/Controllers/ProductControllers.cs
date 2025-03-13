using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoutainShop.Domain.Models;
using MoutainShopService;

namespace MoutainShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private ProductService productService;
        public ProductControllers()
        {
            productService = new ProductService();
        }
        //dodać kontrolery do delete, getall, update i tyle 
        [HttpPost(Name = "PostProduct")]
        public Product Post(Product product)
        {
            productService.AddProduct(product);
            
            return product;
        }

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
    }
}
