using eCommerce.Core;
using eCommerce.Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eCommerce.Service.Controllers
{
    public class ProductController : ApiController
    {
        //Read
        ProductRepository res = new ProductRepository();

        public IHttpActionResult Get()
        {
            try
            {
                List<Product> products = res.GetProducts();
                return Ok(products);
            }
            catch (ItemNotFoundException ex)
            {
                //log message here.
                return NotFound();
            }
            catch (Exception ex)
            {
                //log message here.
                return InternalServerError();
            }
        }
        
        public IHttpActionResult GetProductById(long id)
        {
            try
            {
                Product product = res.GetProductById(id);
                product.ProductAttributes = res.GetProductAttribute(id);
                foreach(ProductAttribute pa in product.ProductAttributes)
                {
                    pa.ProductAttributeLookup= res.GetProductAttributeLookup(product.ProdCatId, pa.AttributeId);
                }
                    
                return Ok(product);
            }
            catch (ItemNotFoundException ex)
            {
                //log message here.
                return NotFound();
            }
            catch (Exception ex)
            {
                //log message here.
                return InternalServerError();
            }
        }

        //Create
        public IHttpActionResult Post(Product product)
        {
            try
            {
                //validate.
                using (ProductRepository res = new ProductRepository())
                {
                    res.InsertProduct(product);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                //log message here.
                return InternalServerError();
            }
        }

        //Update
        public IHttpActionResult Put(Product product)
        {
            try
            {
                //validate.
                using (ProductRepository res = new ProductRepository())
                {
                    res.UpdateProduct(product);
                    return Ok();
                }
            }
            catch (ItemNotFoundException ex)
            {
                //log message here.
                return NotFound();
            }
            catch (Exception ex)
            {
                //log message here.
                return InternalServerError();
            }
        }

        //Delete
        public IHttpActionResult Delete(long id)
        {
            try
            {
                //validate.
                using (ProductRepository res = new ProductRepository())
                {
                    res.DeleteProduct(id);
                    return Ok();
                }
            }
            catch (ItemNotFoundException ex)
            {
                //log message here.
                return NotFound();
            }
            catch (Exception ex)
            {
                //log message here.
                return InternalServerError();
            }
        }
    }
}
