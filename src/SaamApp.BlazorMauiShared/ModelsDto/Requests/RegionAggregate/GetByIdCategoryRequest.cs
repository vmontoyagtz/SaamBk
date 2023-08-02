using System;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class GetByIdCategoryRequest : BaseRequest
    {
        public Guid CategoryId { get; set; }
    }
}