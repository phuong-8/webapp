using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RacoShop.Application.Catalog.Dtos;
using RacoShop.Application.Catalog.Products.Dtos;
using RacoShop.Application.Catalog.Products.Dtos.Public;

namespace RacoShop.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        public Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
