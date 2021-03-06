﻿using RacoShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RacoShop.ViewModel.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
