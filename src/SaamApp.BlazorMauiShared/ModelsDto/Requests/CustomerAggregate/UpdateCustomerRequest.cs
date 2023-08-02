using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Customer
{
    public class UpdateCustomerRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
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

        public static UpdateCustomerRequest FromDto(CustomerDto customerDto)
        {
            return new UpdateCustomerRequest
            {
                CustomerId = customerDto.CustomerId,
                GenderId = customerDto.GenderId,
                CustomerFirstName = customerDto.CustomerFirstName,
                CustomerLastName = customerDto.CustomerLastName,
                CustomerProfileThumbnailPath = customerDto.CustomerProfileThumbnailPath,
                CustomerBirthDate = customerDto.CustomerBirthDate,
                CreatedAt = customerDto.CreatedAt,
                CreatedBy = customerDto.CreatedBy,
                UpdatedAt = customerDto.UpdatedAt,
                UpdatedBy = customerDto.UpdatedBy,
                IsDeleted = customerDto.IsDeleted,
                TenantId = customerDto.TenantId
            };
        }
    }
}