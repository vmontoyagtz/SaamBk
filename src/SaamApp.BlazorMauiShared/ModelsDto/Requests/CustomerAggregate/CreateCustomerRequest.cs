using System;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class CreateCustomerRequest : BaseRequest
    {
        public Guid GenderId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string? CustomerProfileThumbnailPath { get; set; }
        public DateTime? CustomerBirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}