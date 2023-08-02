using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class DeleteAdvisorBankTransferInfoRequest : BaseRequest
    {
        public Guid AdvisorBankTransferInfoId { get; set; }
    }
}