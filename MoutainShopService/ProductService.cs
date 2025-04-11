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
        //public List<Product> ProductBasket { get; set; } //wyjac i wpisac

        private readonly MoutainShopDbContext _context;
        public ProductService(MoutainShopDbContext context) //konstruktor - odpala w momencie tworzenia instancji klasy
        {
            
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);

        }
        public void DeleteProduct(int productId)
        {
            var productToRemove = _context.Products.FirstOrDefault(p => p.Id == productId); 

            if (productToRemove != null)
            {
                _context.Products.Remove(productToRemove);
            }
        }

        public Product GetProductById(int productId) 
        {
            
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);

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
            return _context.Products.ToList();
        }

        public Product UpdateProduct(Product product) 
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            _context.Products.Remove(existingProduct);

            _context.Products.Add(product);

            return product; 
        }
    }
}
//dodać funkcje do aktualizacji produktu i drugą ktora bedzie zwracala cala liste i funkcje ktore zwraca jeden proudkt po id

//GetProductById();
//GetAllProducts();
//UpdateProduct();
