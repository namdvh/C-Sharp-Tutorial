using eShopSolution.Application.Catalog.Products.DTO;
using eShopSolution.Application.DTO;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbCOntext cOntext;
        public ManageProductService(EShopDbCOntext context)
        {
            cOntext = context;

        }

        public async Task addViewCount(int productId)
        {
            var product = await cOntext.Products.FindAsync(productId);
            product.ViewCount += 1;
            await cOntext.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginialPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                new ProductTranslation()
                {
                    Name=request.Name,
                    Description=request.Description,
                    Details=request.Details,
                    SeoDescription=request.SeoDescription,
                    SeoAlias=request.SeoAlias,
                    SeoTitle=request.SeoTitle,
                    LanguageId=request.LanguageId
                } }
            };
            cOntext.Products.Add(product);
            return await cOntext.SaveChangesAsync();
        }

        public async Task<int> Delete(int producId)
        {
            var product = await cOntext.Products.FindAsync(producId);
            if (product == null) throw new eShopException($"cannot find product: {producId}");
            cOntext.Products.Remove(product);
            return await cOntext.SaveChangesAsync();

        }

        public Task<List<ProductViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1 Select Join
            var query = from p in cOntext.Products
                        join pt in cOntext.ProductTranslations on p.Id equals pt.ProductId
                        join pic in cOntext.ProductInCategorys on p.Id equals pic.ProductId
                        join c in cOntext.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2.filter
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.pt.Name.Contains(request.keyword));
            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //3 Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).Select(x=>new ProductViewModel(){
                Id=x.p.Id,
                Name=x.pt.Name,
                DateCreated=x.p.DateCreated,
                Description=x.pt.Description,
                Details=x.pt.Details,
                LanguageId=x.pt.LanguageId,
                OriginalPrice=x.p.OriginalPrice,
                Price=x.p.Price,
                SeoAlias=x.p.SeoAlias,
                SeoDescription=x.pt.SeoDescription,
                SeoTitle=x.pt.SeoTitle,
                Stock=x.p.Stock,
                ViewCount=x.p.ViewCount
            }).ToListAsync();
            //Select and projection
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };
            return pageResult;
        }

        public Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            throw new NotImplementedException();
        }
    }
}
