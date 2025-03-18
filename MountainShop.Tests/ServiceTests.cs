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
    public void RemoveBackPackTest()
    {
        //Arrange

        var backpack = new Backpack()
        {
            Id = 1,
            Name = "Test_Remove",
            Brand = "D2"
        };

        //Act

        productService.AddProduct(backpack);
        var addedBackpack = productService.GetProductById(backpack.Id);
        if (addedBackpack == null)
        {
            Assert.Fail("backpack failed to retrive");
        }
        addedBackpack.Name = "Test_Remove";
        productService.DeleteProduct(backpack.Id);
        var deletedBackpack = productService.GetProductById(backpack.Id);

        //Assert

        Assert.IsNull(deletedBackpack);

    }

    [Test]
    public void AddAndUpdateBackpackTest()
    {
        //Arange

        var backpack = new Backpack()
        {
            Id = 1,
            Name = "Test1",
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
    public void AddMultipleBackpacksAndGetAllTest()
    {

        //Arrange 

        var backpack1 = new Backpack()
        {
            Id = 1,
            Name = "Test1",
            Brand = "D1",
        };

        var backpack2 = new Backpack()
        {
            Id = 2,
            Name = "Test2",
            Brand = "D2",
        };

        var backpack3 = new Backpack()
        {
            Id = 3,
            Name = "Test3",
            Brand = "D3",
        };

        //Act

        productService.AddProduct(backpack1);
        productService.AddProduct(backpack2);
        productService.AddProduct(backpack3);

        var allProducts = productService.GetAllProducts();

        //Assert

        Assert.IsNotNull(allProducts);
        Assert.AreEqual(3, allProducts.Count());
        Assert.IsTrue(allProducts.Any(p => p.Id == backpack1.Id && p.Name == backpack1.Name));
        Assert.IsTrue(allProducts.Any(p => p.Id == backpack2.Id && p.Name == backpack2.Name));
        Assert.IsTrue(allProducts.Any(p => p.Id == backpack3.Id && p.Name == backpack3.Name));

    }
}
