using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef
{
    public class UpdateAccountAdjustmentRefRequest : BaseRequest
    {
        public Guid AccountAdjustmentRefId { get; set; }
        public string AccountAdjustmentRefName { get; set; }
        public string AccountAdjustmentRefDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAccountAdjustmentRefRequest FromDto(AccountAdjustmentRefDto accountAdjustmentRefDto)
        {
            return new UpdateAccountAdjustmentRefRequest
            {
                AccountAdjustmentRefId = accountAdjustmentRefDto.AccountAdjustmentRefId,
                AccountAdjustmentRefName = accountAdjustmentRefDto.AccountAdjustmentRefName,
                AccountAdjustmentRefDescription = accountAdjustmentRefDto.AccountAdjustmentRefDescription,
                TenantId = accountAdjustmentRefDto.TenantId
            };
        }
    }
}