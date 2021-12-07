using eShopSolution.Application.Catalog.Products.DTO;
using eShopSolution.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int producId);
        Task<bool> UpdatePrice(int productId,decimal newPrice);
        Task<bool> UpdateStock(int productId,int addedQuantity);
        Task addViewCount(int productId);
        Task<List<ProductViewModel>> GetAll();
        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest re);
    }
}
