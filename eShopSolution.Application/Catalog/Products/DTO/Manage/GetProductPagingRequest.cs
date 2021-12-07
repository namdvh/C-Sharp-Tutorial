using eShopSolution.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.DTO
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public string keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
