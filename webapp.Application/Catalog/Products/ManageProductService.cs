using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Webapp.Data.EF;
using Webapp.Data.Entities;
using Webapp.Application.Catalog.Dtos;
using Webapp.Application.Catalog.Products;
using Webapp.Application.Catalog.Products.Dtos;
using Webapp.Application.Catalog.Products.Dtos.Manage;
using Webapp.Utilities.Exceptions;

namespace Webapp.Application.Catalog
{
    public class ManageProductService : IManageProductService
    {
        private readonly WebappDBContext _context;
        public ManageProductService(WebappDBContext context)
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

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = new Product()
            {

            };
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new WebappException($"Can't not find product {productId}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            /*var query = from p in _context.Products
                        join pt in _context.ProductTranslations 
                        join pic in _context.ProductInCategories on p.Id equals pic.Productld
                        join c in _context.Categories on pic.Categoryld equals c.Id
                        select new { p, pt, pic };
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));*/
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStock(int productId, int addedQuatity)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }
    }
}
