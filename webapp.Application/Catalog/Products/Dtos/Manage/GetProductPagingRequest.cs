﻿using System;
using System.Collections.Generic;
using System.Text;
using Webapp.Application.Dtos;

namespace Webapp.Application.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
