using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RacoShop.Application.Catalog.Dtos;
using RacoShop.Application.Catalog.Products.Dtos;
using RacoShop.Application.Catalog.Products.Dtos.Manage;

namespace RacoShop.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<bool> UpdatePrice(int productId,decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuatity);

        Task AddViewCount(int productId);

        Task<int> Delete(int productId);

        Task<PagedResult<ProductViewModel>>  GetAllPaging(GetProductPagingRequest request);
    }
}
