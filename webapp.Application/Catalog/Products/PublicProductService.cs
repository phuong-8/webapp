using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapp.Data.EF;
using Microsoft.EntityFrameworkCore;
using Webapp.Application.Catalog.Dtos;
using Webapp.Application.Catalog.Products.Dtos;
using Webapp.Application.Catalog.Products.Dtos.Public;

namespace Webapp.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly WebappDBContext _context;
        public PublicProductService(WebappDBContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
          
            //filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p =>p.pic.CategoryId == request.CategoryId);
            }
            //paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(
                    x => new ProductViewModel()
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
    }
}
