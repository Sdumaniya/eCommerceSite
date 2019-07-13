using eCommerce.Core;
using eCommerce.Web.Models;
using eCommerce.Web.ServiceHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private ProductServiceHelper psh = new ProductServiceHelper();
        // GET: Product
        public async Task<ActionResult> Index()
        {
            await FillCategories();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModelView product)
        {
            ProductServiceHelper psh = new ProductServiceHelper();

            Product pd = new Product();
            pd.ProdCatId = product.ProdCatId;
            pd.ProdDescription = product.ProdDescription;
            pd.ProdName = product.ProdName;
            pd.ProductCategory = product.ProductCategory;

            pd.ProductAttributes = new List<ProductAttribute>();
            for (int i = 0; i < product.AttributeValue.Count; i++)
            {
                pd.ProductAttributes.Add(new ProductAttribute
                {
                    AttributeId = product.AttributeKey[i],
                    AttributeValue = product.AttributeValue[i],
                    ProductId = product.ProductId,
                });
            }

            psh.CreateProduct(pd);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateProduct(long id)
        {
            await FillCategories();

            ProductServiceHelper psh = new ProductServiceHelper();
            Product prod = await psh.GetProductById(id);

            ProductModelView pvm = new ProductModelView();
            pvm.ProductId = prod.ProductId;
            pvm.ProdCatId = prod.ProdCatId;
            pvm.ProdDescription = prod.ProdDescription;
            pvm.ProdName = prod.ProdName;
            pvm.AttributeValue = new List<string>();
            pvm.AttributeKey = new List<int>();
            pvm.ProductAttributes = prod.ProductAttributes;
            foreach (var item in prod.ProductAttributes)
            {
                pvm.AttributeValue.Add(item.AttributeValue);
                pvm.AttributeKey.Add(item.AttributeId);
            }
            return View(pvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductModelView product)
        {
            try
            {
                ProductServiceHelper psh = new ProductServiceHelper();
                Product prod = new Product();

                prod.ProdCatId = product.ProdCatId;
                prod.ProductId= product.ProductId;
                prod.ProdDescription = product.ProdDescription;
                prod.ProdName = product.ProdName;
                prod.ProductCategory = product.ProductCategory;
                prod.ProductAttributes = new List<ProductAttribute>();
                for (int i = 0; i < product.AttributeValue.Count; i++)
                {
                    prod.ProductAttributes.Add(new ProductAttribute
                    {
                        AttributeId = product.AttributeKey[i],
                        AttributeValue = product.AttributeValue[i],
                        ProductId = product.ProductId,
                    });
                }
                psh.UpdateProfile(prod);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //log here
                return View();
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetProductAttributes(int id)
        {
            ProductServiceHelper psh = new ProductServiceHelper();
            List<ProductAttributeLookup> productAttributeLookups = await psh.GetProductAttributeLookup(id);
            return Json(productAttributeLookups);
        }

        private async Task FillCategories()
        {
            try
            {
                IEnumerable<ProductCategory> pcs = await psh.GetProductCategory();
                IEnumerable<SelectListItem> items = pcs.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.ProdCatId.ToString()
                });

                ViewData.Add("ProductCategory", items);
            }
            catch (Exception ex)
            {

            }
        }
    }
}