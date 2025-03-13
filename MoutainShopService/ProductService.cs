using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoutainShop.Domain.Models;


namespace MoutainShopService
{
    public class ProductService
    {
        public List<Product> ProductsBasket { get; set; }
        public ProductService()
        {
            ProductsBasket = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            ProductsBasket.Add(product);

        }
        public void DeleteProduct(int productId)
        {
            var productToRemove = ProductsBasket.FirstOrDefault(p => p.Id == productId); 

            if (productToRemove != null)
            {
                ProductsBasket.Remove(productToRemove);
            }
        }
        public Product GetProductById(int productId) 
        {
            var product = ProductsBasket.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }

        }

        public List<Product> GetAllProducts()
        {
            return ProductsBasket;
        }

        public Product UpdateProduct(Product product) 
        {
            var existingProduct = ProductsBasket.FirstOrDefault(p => p.Id == product.Id);
            ProductsBasket.Remove(existingProduct);

            ProductsBasket.Add(product);

            return product; 
        }
    }
}
//dodać funkcje do aktualizacji produktu i drugą ktora bedzie zwracala cala liste i funkcje ktore zwraca jeden proudkt po id

//GetProductById();
//GetAllProducts();
//UpdateProduct();
