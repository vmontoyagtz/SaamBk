using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class GetByIdAdvisorBankTransferInfoResponse : BaseResponse
    {
        public GetByIdAdvisorBankTransferInfoResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAdvisorBankTransferInfoResponse()
        {
        }

        public AdvisorBankTransferInfoDto AdvisorBankTransferInfo { get; set; } = new();
    }
}