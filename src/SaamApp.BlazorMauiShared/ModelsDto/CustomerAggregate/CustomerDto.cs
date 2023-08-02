using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class CustomerDto
    {
        public CustomerDto() { } // AutoMapper required

        public CustomerDto(Guid customerId, Guid genderId, string customerFirstName, string customerLastName,
            string? customerProfileThumbnailPath, DateTime? customerBirthDate, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            GenderId = Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            CustomerFirstName = Guard.Against.NullOrWhiteSpace(customerFirstName, nameof(customerFirstName));
            CustomerLastName = Guard.Against.NullOrWhiteSpace(customerLastName, nameof(customerLastName));
            CustomerProfileThumbnailPath = customerProfileThumbnailPath;
            CustomerBirthDate = customerBirthDate;
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Customer First Name is required")]
        [MaxLength(100)]
        public string CustomerFirstName { get; set; }

        [Required(ErrorMessage = "Customer Last Name is required")]
        [MaxLength(100)]
        public string CustomerLastName { get; set; }

        [MaxLength(100)] public string? CustomerProfileThumbnailPath { get; set; }

        public DateTime? CustomerBirthDate { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public GenderDto Gender { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Guid GenderId { get; set; }

        public List<AdvisorCustomerDto> AdvisorCustomers { get; set; } = new();
        public List<AdvisorRatingDto> AdvisorRatings { get; set; } = new();
        public List<AiFeedbackDto> AiFeedbacks { get; set; } = new();
        public List<AiInteractionDto> AiInteractions { get; set; } = new();
        public List<AiSessionDto> AiSessions { get; set; } = new();
        public List<AppointmentScheduleDto> AppointmentSchedules { get; set; } = new();
        public List<CustomerAccountDto> CustomerAccounts { get; set; } = new();
        public List<CustomerAddressDto> CustomerAddresses { get; set; } = new();
        public List<CustomerAiHistoryDto> CustomerAiHistories { get; set; } = new();
        public List<CustomerDocumentDto> CustomerDocuments { get; set; } = new();
        public List<CustomerEmailAddressDto> CustomerEmailAddresses { get; set; } = new();
        public List<CustomerFeedbackDto> CustomerFeedbacks { get; set; } = new();
        public List<CustomerPhoneNumberDto> CustomerPhoneNumbers { get; set; } = new();
        public List<CustomerPurchaseDto> CustomerPurchases { get; set; } = new();
        public List<CustomerReviewDto> CustomerReviews { get; set; } = new();
        public List<DiscountCodeRedemptionDto> DiscountCodeRedemptions { get; set; } = new();
        public List<GiftCodeRedemptionDto> GiftCodeRedemptions { get; set; } = new();
        public List<MessageDto> Messages { get; set; } = new();
        public List<PrepaidPackageRedemptionDto> PrepaidPackageRedemptions { get; set; } = new();
        public List<SerfinsaPaymentDto> SerfinsaPayments { get; set; } = new();
        public List<UnansweredConversationDto> UnansweredConversations { get; set; } = new();
    }
}