using System;

namespace SaamApp.BlazorMauiShared.Models.TemplateCategory
{
    public class GetByRelsIdsTemplateCategoryRequest : BaseRequest
    {
        public Guid RegionAreaAdvisorCategoryId { get; set; }
        public Guid ComissionId { get; set; }
        public Guid TemplateId { get; set; }
        public Guid TenantId { get; set; }
    }
}