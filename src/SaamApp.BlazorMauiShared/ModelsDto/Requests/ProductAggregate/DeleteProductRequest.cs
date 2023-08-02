using System;

namespace SaamApp.BlazorMauiShared.Models.Product
{
    public class DeleteProductRequest : BaseRequest
    {
        public Guid ProductId { get; set; }
    }
}