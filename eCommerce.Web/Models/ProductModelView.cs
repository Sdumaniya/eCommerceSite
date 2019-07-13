using eCommerce.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Web.Models
{
    public class ProductModelView : Product
    {
        public List<int> AttributeKey { get; set; }
        public List<string> AttributeValue { get; set; }
    }
}