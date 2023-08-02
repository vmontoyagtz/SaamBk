using System;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class GetByIdProductRequest : BaseRequest
    {
        public Guid ProductId { get; set; }
    }
}