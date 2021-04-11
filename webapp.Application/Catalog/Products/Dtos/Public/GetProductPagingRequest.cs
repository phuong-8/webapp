using System;
using System.Collections.Generic;
using System.Text;
using Webapp.Application.Dtos;

namespace Webapp.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
