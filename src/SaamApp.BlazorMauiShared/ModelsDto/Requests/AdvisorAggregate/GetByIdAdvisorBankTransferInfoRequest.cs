using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class GetByIdAdvisorBankTransferInfoRequest : BaseRequest
    {
        public Guid AdvisorBankTransferInfoId { get; set; }
    }
}