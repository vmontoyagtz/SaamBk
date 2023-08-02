using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class UpdateAdvisorBankTransferInfoRequest : BaseRequest
    {
        public Guid AdvisorBankTransferInfoId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
        public string? BankTransferNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }

        public static UpdateAdvisorBankTransferInfoRequest FromDto(
            AdvisorBankTransferInfoDto advisorBankTransferInfoDto)
        {
            return new UpdateAdvisorBankTransferInfoRequest
            {
                AdvisorBankTransferInfoId = advisorBankTransferInfoDto.AdvisorBankTransferInfoId,
                AdvisorId = advisorBankTransferInfoDto.AdvisorId,
                BankAccountId = advisorBankTransferInfoDto.BankAccountId,
                BankTransferNotes = advisorBankTransferInfoDto.BankTransferNotes,
                CreatedAt = advisorBankTransferInfoDto.CreatedAt,
                CreatedBy = advisorBankTransferInfoDto.CreatedBy,
                UpdatedAt = advisorBankTransferInfoDto.UpdatedAt,
                UpdatedBy = advisorBankTransferInfoDto.UpdatedBy,
                IsDeleted = advisorBankTransferInfoDto.IsDeleted
            };
        }
    }
}