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
    public class ProductAttributeLookupController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            try
            {
                using (ProductRepository res = new ProductRepository())
                {
                    List<ProductAttributeLookup> productCategory = res.GetProductAttributes(id);
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
