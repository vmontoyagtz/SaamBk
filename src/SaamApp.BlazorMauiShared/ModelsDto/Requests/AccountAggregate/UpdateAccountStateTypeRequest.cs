using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountStateType
{
    public class UpdateAccountStateTypeRequest : BaseRequest
    {
        public Guid AccountStateTypeId { get; set; }
        public string AccountStateTypeCode { get; set; }
        public string AccountStateTypeName { get; set; }
        public string? AccountStateTypeDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAccountStateTypeRequest FromDto(AccountStateTypeDto accountStateTypeDto)
        {
            return new UpdateAccountStateTypeRequest
            {
                AccountStateTypeId = accountStateTypeDto.AccountStateTypeId,
                AccountStateTypeCode = accountStateTypeDto.AccountStateTypeCode,
                AccountStateTypeName = accountStateTypeDto.AccountStateTypeName,
                AccountStateTypeDescription = accountStateTypeDto.AccountStateTypeDescription,
                TenantId = accountStateTypeDto.TenantId
            };
        }
    }
}