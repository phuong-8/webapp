using Microsoft.AspNetCore.Http;
using RacoShop.ViewModel.Catalog.ProductImages;
using RacoShop.ViewModel.Catalog.Products;
using RacoShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RacoShop.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<bool> UpdatePrice(int productId,decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuatity);

        Task AddViewCount(int productId);

        Task<ProductViewModel> GetById(int productId, string languageId);

        Task<int> Delete(int productId);

        Task<PagedResult<ProductViewModel>>  GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImages(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImages(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImage(int productId);

        public Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);

    }
}
