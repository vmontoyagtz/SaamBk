using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace SaamApp.Domain.ModelsDto
{
    public class AdvisorDto
    {
        public AdvisorDto() { } // AutoMapper required

        public AdvisorDto(Guid advisorId, Guid businessUnitId, Guid genderId, Guid paymentFrequencyId,
            Guid taxInformationId, string advisorFirstName, string advisorLastName, string? advisorNote,
            string advisorTitle, string advisorJsonResume, bool isNaturalPerson, DateTime createdAt, Guid createdBy,
            DateTime? updatedAt, Guid? updatedBy, bool? isDeleted, Guid tenantId)
        {
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            BusinessUnitId = Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));
            GenderId = Guard.Against.NullOrEmpty(genderId, nameof(genderId));
            PaymentFrequencyId = Guard.Against.NullOrEmpty(paymentFrequencyId, nameof(paymentFrequencyId));
            TaxInformationId = Guard.Against.NullOrEmpty(taxInformationId, nameof(taxInformationId));
            AdvisorFirstName = Guard.Against.NullOrWhiteSpace(advisorFirstName, nameof(advisorFirstName));
            AdvisorLastName = Guard.Against.NullOrWhiteSpace(advisorLastName, nameof(advisorLastName));
            AdvisorNote = advisorNote;
            AdvisorTitle = Guard.Against.NullOrWhiteSpace(advisorTitle, nameof(advisorTitle));
            AdvisorJsonResume = Guard.Against.NullOrWhiteSpace(advisorJsonResume, nameof(advisorJsonResume));
            IsNaturalPerson = Guard.Against.Null(isNaturalPerson, nameof(isNaturalPerson));
            CreatedAt = Guard.Against.OutOfSQLDateRange(createdAt, nameof(createdAt));
            CreatedBy = Guard.Against.NullOrEmpty(createdBy, nameof(createdBy));
            UpdatedAt = updatedAt;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            TenantId = Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));
        }

        public Guid AdvisorId { get; set; }

        [Required(ErrorMessage = "Advisor First Name is required")]
        [MaxLength(100)]
        public string AdvisorFirstName { get; set; }

        [Required(ErrorMessage = "Advisor Last Name is required")]
        [MaxLength(100)]
        public string AdvisorLastName { get; set; }

        [MaxLength(100)] public string? AdvisorNote { get; set; }

        [Required(ErrorMessage = "Advisor Title is required")]
        [MaxLength(100)]
        public string AdvisorTitle { get; set; }

        [Required(ErrorMessage = "Advisor Json Resume is required")]
        [MaxLength(100)]
        public string AdvisorJsonResume { get; set; }

        [Required(ErrorMessage = "Is Natural Person is required")]
        public bool IsNaturalPerson { get; set; }

        [Required(ErrorMessage = "Created At is required")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public Guid CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "Tenant Id is required")]
        public Guid TenantId { get; set; }

        public BusinessUnitDto BusinessUnit { get; set; }

        [Required(ErrorMessage = "Business Unit is required")]
        public Guid BusinessUnitId { get; set; }

        public GenderDto Gender { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public Guid GenderId { get; set; }

        public PaymentFrequencyDto PaymentFrequency { get; set; }

        [Required(ErrorMessage = "Payment Frequency is required")]
        public Guid PaymentFrequencyId { get; set; }

        public TaxInformationDto TaxInformation { get; set; }

        [Required(ErrorMessage = "Tax Information is required")]
        public Guid TaxInformationId { get; set; }

        public List<AdvisorAddressDto> AdvisorAddresses { get; set; } = new();
        public List<AdvisorBankDto> AdvisorBanks { get; set; } = new();
        public List<AdvisorBankTransferInfoDto> AdvisorBankTransferInfoes { get; set; } = new();
        public List<AdvisorCustomerDto> AdvisorCustomers { get; set; } = new();
        public List<AdvisorDocumentDto> AdvisorDocuments { get; set; } = new();
        public List<AdvisorEmailAddressDto> AdvisorEmailAddresses { get; set; } = new();
        public List<AdvisorIdentityDocumentDto> AdvisorIdentityDocuments { get; set; } = new();
        public List<AdvisorLoginDto> AdvisorLogins { get; set; } = new();
        public List<AdvisorPaymentDto> AdvisorPayments { get; set; } = new();
        public List<AdvisorPhoneNumberDto> AdvisorPhoneNumbers { get; set; } = new();
        public List<AdvisorRatingDto> AdvisorRatings { get; set; } = new();
        public List<AppointmentScheduleDto> AppointmentSchedules { get; set; } = new();
        public List<CustomerReviewDto> CustomerReviews { get; set; } = new();
        public List<MessageDto> Messages { get; set; } = new();
        public List<RegionAreaAdvisorCategoryDto> RegionAreaAdvisorCategories { get; set; } = new();
        public List<TrainingProgressDto> TrainingProgresses { get; set; } = new();
        public List<TrainingQuizHistoryDto> TrainingQuizHistories { get; set; } = new();
    }
}