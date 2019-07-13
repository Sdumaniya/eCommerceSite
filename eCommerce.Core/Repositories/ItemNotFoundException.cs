﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Repositories
{
    public class ItemNotFoundException : Exception
    {
        public ItemNotFoundException()
        {

        }

        public ItemNotFoundException(string exceptionMessage)
            :base(exceptionMessage)
        {
            
        }
    }
}
