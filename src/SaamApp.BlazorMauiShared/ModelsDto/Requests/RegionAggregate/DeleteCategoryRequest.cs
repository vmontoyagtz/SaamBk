using System;

namespace SaamApp.BlazorMauiShared.Models.Category
{
    public class DeleteCategoryRequest : BaseRequest
    {
        public Guid CategoryId { get; set; }
    }
}