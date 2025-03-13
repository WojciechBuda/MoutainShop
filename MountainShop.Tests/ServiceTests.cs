using MoutainShop.Domain.Models;
using MoutainShopService;

//tetsy 2 na dole zroibc

namespace MountainShop.Tests;

public class ServiceTests
{
    private ProductService productService;

    [SetUp]
    public void Setup()
    {
        productService = new ProductService();
    }

    [Test]
    public void AddBackPackTest()
    {
        //Arange

        var backpack = new Backpack()
        {
            Id = 1,
            Name = "Test",
            Brand = "D1"
        };

        //Act

        
        productService.AddProduct(backpack);
        var addedBackPack = productService.GetProductById(backpack.Id);
        
        //Assert

        Assert.IsNotNull(addedBackPack);
        Assert.AreEqual(1, addedBackPack.Id);
        Assert.AreEqual(backpack.Name, addedBackPack.Name);
        //Assert.AreEqual(backpack.Brand, addedBackPack.Brand);
    }
    [Test]
    public void RemoveBackPackTest() { }

    [Test]
    public void AddAndUpdateBackpackTest() 
    {
        //Arange

        var backpack = new Backpack()
        {
            Id = 1,
            Name = "Test",
            Brand = "D1"
        };

        //Act


        productService.AddProduct(backpack);
        var addedBackPack = productService.GetProductById(backpack.Id);
        if (addedBackPack == null)
        {
            Assert.Fail("backpack failed to retrive");
        }
        addedBackPack.Name = "Updated Name";
        productService.UpdateProduct(addedBackPack);
        var updatedBackpack = productService.GetProductById(addedBackPack.Id);
        //Assert

        Assert.IsNotNull(updatedBackpack);
        Assert.AreEqual("Updated Name", updatedBackpack.Name);
    }

    [Test]
    public void AddMultipleBackpacksAndGetAllTest() { }
}
