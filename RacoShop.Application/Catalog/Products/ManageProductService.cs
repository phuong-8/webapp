using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RacoShop.Data.EF;
using RacoShop.Data.Entities;
using RacoShop.Application.Catalog.Dtos;
using RacoShop.Application.Catalog.Products;
using RacoShop.Application.Catalog.Products.Dtos;
using RacoShop.Application.Catalog.Products.Dtos.Manage;
using RacoShop.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace RacoShop.Application.Catalog
{
    public class ManageProductService : IManageProductService
    {
        private readonly RacoShopDBContext _context;
        public ManageProductService(RacoShopDBContext context)
        {
            _context = context;
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    }
                }
            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new RacoShopException($"Can't not find product {productId}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));
            //filter
            if(request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //paging
            int totalRow = await query.CountAsync();
            var data =await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(
                    x=> new ProductViewModel()
                    {
                           Id = x.p.Id,
                          Price = x.p.Price,
                          OriginalPrice = x.p.OriginalPrice,
                          Stock = x.p.Stock,
                          ViewCount = x.p.ViewCount,
                          DateCreated = x.p.DateCreated,

                          Name = x.pt.Name,
                          Description = x.pt.Description,
                          Details = x.pt.Details,
                          SeoDescription = x.pt.SeoDescription,
                          SeoTitle = x.pt.SeoTitle,

                          SeoAlias = x.pt.SeoAlias,
                          LanguageId = x.pt.LanguageId
                    }
                ).ToListAsync();
            // select
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pagedResult;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranlations = await _context.ProductTranslations
                .FirstOrDefaultAsync(x => x.ProductId == request.Id && x.LanguageId == request.LanguageId);
            if(product == null || productTranlations == null) throw new RacoShopException($"Can't not find product with Id: {request.Id}");
            productTranlations.Name = request.Name;
            productTranlations.SeoAlias = request.SeoAlias;
            productTranlations.Details = request.Details;
            productTranlations.Description = request.Description;
            productTranlations.SeoDescription = request.SeoDescription;
            productTranlations.SeoTitle = request.SeoTitle;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new RacoShopException($"Can't not find product with Id: {productId}");
            product.Price = newPrice;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuatity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new RacoShopException($"Can't not find product with Id: {productId}");
            product.Stock += addedQuatity;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
