using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapp.Application.Catalog.Dtos;
using Webapp.Application.Catalog.Products.Dtos;
using Webapp.Application.Catalog.Products.Dtos.Public;

namespace Webapp.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
