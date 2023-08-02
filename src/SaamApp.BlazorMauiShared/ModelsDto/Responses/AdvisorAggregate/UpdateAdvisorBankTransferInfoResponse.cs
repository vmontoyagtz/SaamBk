using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class UpdateAdvisorBankTransferInfoResponse : BaseResponse
    {
        public UpdateAdvisorBankTransferInfoResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAdvisorBankTransferInfoResponse()
        {
        }

        public AdvisorBankTransferInfoDto AdvisorBankTransferInfo { get; set; } = new();
    }
}