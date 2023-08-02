using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class ListAdvisorBankTransferInfoResponse : BaseResponse
    {
        public ListAdvisorBankTransferInfoResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorBankTransferInfoResponse()
        {
        }

        public List<AdvisorBankTransferInfoDto> AdvisorBankTransferInfoes { get; set; } = new();

        public int Count { get; set; }
    }
}