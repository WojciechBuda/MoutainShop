

using MoutainShop.Domain.Models;

namespace MountainShop.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //public void Test1()
        //{

        //    var wynik = 2 + 2;
        //    Assert.AreEqual(1, wynik);

        //}

        [Test]
        public void Test2()
        {
            var plecak = new Backpack()
            {
                Name = "nowy plecak"
            };

            var klonplecak = new Backpack()
            {
                Name = "nowy plecak"
            };

            var tensamplecak = plecak;

            Assert.AreEqual(plecak.Name, klonplecak.Name);
            Assert.AreSame(plecak.Name, klonplecak.Name);

        }

    }
}
