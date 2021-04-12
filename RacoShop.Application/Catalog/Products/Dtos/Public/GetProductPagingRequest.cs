using System;
using System.Collections.Generic;
using System.Text;
using RacoShop.Application.Dtos;

namespace RacoShop.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
