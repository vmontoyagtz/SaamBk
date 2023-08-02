using System;

namespace SaamApp.BlazorMauiShared.Models.ProductCategory
{
    public class CreateProductCategoryRequest : BaseRequest
    {
        public Guid ComissionId { get; set; }
        public Guid ProductId { get; set; }
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid TenantId { get; set; }
    }
}