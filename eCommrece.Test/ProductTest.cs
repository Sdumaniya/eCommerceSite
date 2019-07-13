using Microsoft.VisualStudio.TestTools.UnitTesting;
using eCommerce.Core.Repositories;
using eCommerce.Core;
using System.Collections.Generic;

namespace eCommrece.Test
{
    [TestClass]
    public class ProductTest
    {
        ProductRepository repo = new ProductRepository();

        [TestMethod]
        public void TestInsertProdct()
        {
            ProductCategory pc = new ProductCategory()
            {
                CategoryName = "Item1"
            };
            Product p = new Product()
            {
                ProdName = "Prod1",
                ProductCategory = pc
            };

            repo.InsertProductCategory(pc);
            repo.InsertProduct(p);
        }

        [TestMethod]
        public void TestUpdateProdct()
        {
            Product prod = repo.GetProductById(26);
            prod.ProdDescription = "Hello 123 Somin";
            repo.UpdateProduct(prod);
        }


        [TestMethod]
        public void TestDeleteProdct()
        {
        }

        [TestMethod]
        public void TestGetAllProdct()
        {
            List<Product> p1 = repo.GetProducts();

            //Product prod = repo.GetProductById(1);

            //List<Product> p = repo.GetProducts();

            //List<Product> p = repo.GetProducts();
        }
    }
}
