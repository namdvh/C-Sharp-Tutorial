using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.DTO
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal OriginialPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
    }
}
