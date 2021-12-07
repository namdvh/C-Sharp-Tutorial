using eShopSolution.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.DTO.Public
{
    public class GetProducPagingRequest:PagingRequestBase
    {
        public int CategoryId { get; set; }

    }
}
