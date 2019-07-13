using eCommerce.Core;
using eCommerce.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eCommerce.Service.Controllers
{
    public class ProductCategoryController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                using (ProductRepository res = new ProductRepository())
                {
                    List<ProductCategory> productCategory = res.GetProductCategory();
                    return Ok(productCategory);
                }
            }
            catch (Exception ex)
            {
                //log message here.
                return InternalServerError();
            }
        }
    }
}
