using System;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class CreateCategoryRequest : BaseRequest
    {
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
        public int CategoryStage { get; set; }
        public Guid TenantId { get; set; }
    }
}