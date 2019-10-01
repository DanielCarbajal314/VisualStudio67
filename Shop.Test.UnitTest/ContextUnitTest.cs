using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Domain.Entities;
using Shop.Infrastructure.EFDataContext;
using Shop.Services.implementation;
using Shop.Services.Interfaces.Handlers;
using Shop.Services.Interfaces.Requests;

namespace Shop.Test.UnitTest
{
    [TestClass]
    public class ContextUnitTest
    {
        [TestMethod]
        public void CategoryInsertionTest()
        {
            using (var db = new ShopDb())
            {
                Category newCatery = new Category()
                {
                    Name = "Frutas",
                    Description = "Vegetales dulces"
                };
                db.Categories.Add(newCatery);
                db.SaveChanges();
                Assert.IsTrue(newCatery.Id>0);
            }
        }

        [TestMethod]
        public void CreateANewProduct()
        {
            IProductHandler productHandler = new EFProductHandler();
            var newProduct = productHandler.RegisterProduct(new CreateProducto()
            {
                CategoryId = 1,
                Descripcion = "Es roja",
                Name = "Fresa"
            });
            Assert.AreEqual(newProduct.CategoryName, "Frutas");
            Assert.IsTrue(newProduct.Id > 0);
            Assert.AreEqual(newProduct.Name, "Fresa");
            Assert.AreEqual(newProduct.Description, "Es roja");
        }
    }
}
