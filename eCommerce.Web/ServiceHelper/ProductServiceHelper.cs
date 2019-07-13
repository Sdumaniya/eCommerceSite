using eCommerce.Core;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using eCommerce.Web.Models;

namespace eCommerce.Web.ServiceHelper
{
    internal class ProductServiceHelper : ServiceHelper
    {
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                List<Product> products = await GetServiceDataAsync<List<Product>>("Product");
                return products;
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }

        public async Task<Product> GetProductById(long id)
        {
            try
            {
                Product product = await GetServiceDataAsync<Product>("Product/" + id);
                return product;
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }

        public void CreateProduct(Product product)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ServiceUrl);
                    HttpResponseMessage res = client.PostAsJsonAsync("Product", product).Result;
                }

            }
            catch (Exception ex)
            {
                //log

            }
        }

        public async Task<List<ProductCategory>> GetProductCategory()
        {
            try
            {
                List<ProductCategory> ProductCategory = await GetServiceDataAsync<List<ProductCategory>>("ProductCategory");

                return ProductCategory;
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }

        public async Task<List<ProductAttributeLookup>> GetProductAttributeLookup(int id)
        {
            try
            {
                List<ProductAttributeLookup> productAttributeLookups = await GetServiceDataAsync<List<ProductAttributeLookup>>("ProductAttributeLookup/" + id);

                return productAttributeLookups;
            }
            catch (Exception ex)
            {
                //log
                return null;
            }
        }

        internal void UpdateProfile(Product product)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ServiceUrl);
                    HttpResponseMessage res = client.PutAsJsonAsync("Product", product).Result;
                }
            }
            catch (Exception ex)
            {
                //log

            }
        }
    }
}