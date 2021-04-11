using System;
using System.Collections.Generic;
using System.Text;
using Webapp.Application.Catalog.Dtos;
using Webapp.Application.Catalog.Products.Dtos;
using Webapp.Application.Catalog.Products.Dtos.Public;

namespace Webapp.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PagedResult<ProductViewModel> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
