using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class CreateAdvisorBankTransferInfoResponse : BaseResponse
    {
        public CreateAdvisorBankTransferInfoResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAdvisorBankTransferInfoResponse()
        {
        }

        public AdvisorBankTransferInfoDto AdvisorBankTransferInfo { get; set; } = new();
    }
}