//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eCommerce.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductAttributeLookup
    {
        public ProductAttributeLookup()
        {
            this.ProductAttributes = new HashSet<ProductAttribute>();
        }
    
        public int AttributeId { get; set; }
        public int ProdCatId { get; set; }
        public string AttributeName { get; set; }
    
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
