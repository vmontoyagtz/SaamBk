using System;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class CreateAdvisorRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
        public Guid GenderId { get; set; }
        public Guid PaymentFrequencyId { get; set; }
        public Guid TaxInformationId { get; set; }
        public string AdvisorFirstName { get; set; }
        public string AdvisorLastName { get; set; }
        public string? AdvisorNote { get; set; }
        public string AdvisorTitle { get; set; }
        public string AdvisorJsonResume { get; set; }
        public bool IsNaturalPerson { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}