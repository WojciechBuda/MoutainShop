using System;
using System.Collections.Generic;
using System.Globalization;
using MoutainShop.Domain.Models;
using MoutainShopService;



namespace MoutainShop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("dej imie:");
            //var imie = Console.ReadLine();

            //var wojtek = new Person(imie, "opis");
            //var piotrek = new Person("piotrek", "opis2");

            //wojtek.Name = "wojtek2";
            //Console.WriteLine("podaj opis");
            //var opis = Console.ReadLine();

            //wojtek.Description = opis;
            //Console.WriteLine(wojtek.Name);

            var service = new ProductService();
                       
            var plecak = new Backpack();
            plecak.Brand = "deuter";
            
            var plecak2 = new Backpack();
            plecak2.Brand = "ospray"; 

            var nazwyplecaków = new List<string>()
            {
                "A","B","C","D","F","G"

            };
            for (int i = 0; i < nazwyplecaków.Count; i++)
            {
                var backpack = new Backpack()
                {
                    Brand = nazwyplecaków[i],
                    Name = nazwyplecaków[i],
                    Id = i
                };
                service.AddProduct(backpack);
                Console.WriteLine(" dodano " + backpack.Name);

            }
            Console.WriteLine(" lista produktów ");
            foreach (var product in service.ProductsBasket)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine("wybierz produkt");
            var producttoremove = Console.ReadLine();
            service.DeleteProduct(Convert.ToInt32(producttoremove));
            foreach (var product in service.ProductsBasket)
            {
                Console.WriteLine(product.Name);
            }
            Console.ReadLine();

            var productToUpdate = service.GetProductById(2);
            Console.WriteLine(productToUpdate.Name);
            productToUpdate.Name = "dupa";
            Console.WriteLine(service.UpdateProduct(productToUpdate).Name); 


        } 
    }
}

