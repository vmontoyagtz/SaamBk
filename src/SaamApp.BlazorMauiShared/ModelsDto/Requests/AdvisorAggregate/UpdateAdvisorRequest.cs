using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class UpdateAdvisorRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
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

        public static UpdateAdvisorRequest FromDto(AdvisorDto advisorDto)
        {
            return new UpdateAdvisorRequest
            {
                AdvisorId = advisorDto.AdvisorId,
                BusinessUnitId = advisorDto.BusinessUnitId,
                GenderId = advisorDto.GenderId,
                PaymentFrequencyId = advisorDto.PaymentFrequencyId,
                TaxInformationId = advisorDto.TaxInformationId,
                AdvisorFirstName = advisorDto.AdvisorFirstName,
                AdvisorLastName = advisorDto.AdvisorLastName,
                AdvisorNote = advisorDto.AdvisorNote,
                AdvisorTitle = advisorDto.AdvisorTitle,
                AdvisorJsonResume = advisorDto.AdvisorJsonResume,
                IsNaturalPerson = advisorDto.IsNaturalPerson,
                CreatedAt = advisorDto.CreatedAt,
                CreatedBy = advisorDto.CreatedBy,
                UpdatedAt = advisorDto.UpdatedAt,
                UpdatedBy = advisorDto.UpdatedBy,
                IsDeleted = advisorDto.IsDeleted,
                TenantId = advisorDto.TenantId
            };
        }
    }
}