using MoutainShop.Domain.Models;
using MoutainShopService;

namespace MoutainShop.WebApi
{
    public static class EndpointMapper
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("api/test", () => "test win"); // anonymous function: () =>
            // POST api/products/add
            app.MapPost("api/products/add", async (Product product, IProductService productService) =>
            {
                await productService.AddProduct(product);
                return Results.Ok(product);
            });

            // GET api/products/get?id=1
            app.MapGet("api/products/get", async (int id, IProductService productService) =>
            {
                var product = await productService.GetProductById(id); //czeka az SKONCZY sie metoda GetProd...
                return product is not null ? Results.Ok(product) : Results.NotFound("product not found"); // is not null to to samo co !=
            }).RequireAuthorization(); // po )} daje .RequireAuth...

            // DELETE api/products/delete?id=1
            app.MapDelete("api/products/delete", async (int id, IProductService productService) =>
            {
                await productService.DeleteProduct(id);
                return Results.NoContent();
            });

            // PUT api/products/update
            app.MapPut("api/products/update", async (Product product, IProductService productService) =>
            {
                var updated = await productService.UpdateProduct(product);
                return Results.Ok(updated);
            });

            // GET api/products/getAll
            app.MapGet("api/products/getAll", async (IProductService productService) =>
            {
                var all = await productService.GetAllProducts();
                return Results.Ok(all);
            });
        }
    }
}
