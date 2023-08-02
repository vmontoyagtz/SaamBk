using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class UpdateAdvisorBankRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid BankAccountId { get; set; }
        public bool IsDefault { get; set; }

        public static UpdateAdvisorBankRequest FromDto(AdvisorBankDto advisorBankDto)
        {
            return new UpdateAdvisorBankRequest
            {
                RowId = advisorBankDto.RowId,
                AdvisorId = advisorBankDto.AdvisorId,
                BankAccountId = advisorBankDto.BankAccountId,
                IsDefault = advisorBankDto.IsDefault
            };
        }
    }
}