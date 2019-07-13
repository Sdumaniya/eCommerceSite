using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace eCommerce.Core.Repositories
{
    public class ProductRepository : IDisposable
    {
        #region Property
        private ECommerceDb _context = new ECommerceDb();
        #endregion

        #region Constructor
        public ProductRepository()
        {
            _context.Configuration.ProxyCreationEnabled = false;
        }
        #endregion

        #region Product Functions
        public List<Product> GetProducts()
        {
            return _context.Products
                .Include("ProductCategory")
                .Include("ProductAttributes")
                .ToList();
        }
        public List<Product> GetProducts(Func<Product, bool> predict)
        {
            return _context.Products.Where(predict).ToList();
        }
        public Product GetProductById(long productId)
        {
            return _context.Products.Find(productId);
        }
        public Product GetProduct(params object[] items)
        {
            return _context.Products.Find(items);
        }

        public List<ProductAttribute> GetProductAttribute(long productId)
        {
            return _context.ProductAttributes.Where(x => x.ProductId == productId).ToList();
        }

        public List<ProductAttributeLookup> GetProductAttributes(int id)
        {
            return _context.ProductAttributeLookups.Where(x => x.ProdCatId == id).ToList();
        }

        public void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product is null");

            List<ProductAttribute> listPrdouctAttribute = product.ProductAttributes.ToList();
            product.ProductAttributes = null;
            _context.Products.Add(product);
            _context.SaveChanges();

            foreach (ProductAttribute pa in listPrdouctAttribute)
            {
                pa.ProductId = product.ProductId;
                pa.Product = null; pa.ProductAttributeLookup = null;

                _context.ProductAttributes.Add(pa);
            }
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product is null");
            
            List<ProductAttribute> listPrdouctAttribute = product.ProductAttributes.ToList();
            product.ProductAttributes = new List<ProductAttribute>();
            
            _context.Entry(product).State = System.Data.EntityState.Modified;

            _context.SaveChanges();

            foreach (ProductAttribute pa in listPrdouctAttribute)
            {
                pa.Product = null; pa.ProductAttributeLookup = null;
                _context.Entry(pa).State = System.Data.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(long productId)
        {
            if (productId == 0)
                throw new ArgumentNullException("Product is null");
            Product prod = GetProductById(productId);
            if (prod == null)
                throw new Exception("Product not found");

            List<ProductAttribute> palist = _context.ProductAttributes.Where(x => x.ProductId == productId).ToList();
            foreach (ProductAttribute pa in palist)
            {
                _context.ProductAttributes.Remove(pa);
                _context.SaveChanges();
            }

            _context.Products.Remove(prod);
            _context.SaveChanges();
        }
        #endregion

        #region ProductCategory Functions

        public void InsertProductCategory(ProductCategory productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("Product is null");
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
        }

        public List<ProductCategory> GetProductCategory()
        {
            return _context.ProductCategories.ToList();
        }

        public ProductAttributeLookup GetProductAttributeLookup(long productCateId, long attributeId)
        {
            return _context.ProductAttributeLookups.Where(x => x.AttributeId == attributeId && x.ProdCatId == productCateId).FirstOrDefault();
        }

        #endregion

        #region Dispose
        public void Dispose()
        {
            //dispose
        }
        #endregion
    }
}
