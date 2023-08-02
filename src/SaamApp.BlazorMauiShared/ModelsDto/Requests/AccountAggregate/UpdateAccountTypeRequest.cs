using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AccountType
{
    public class UpdateAccountTypeRequest : BaseRequest
    {
        public Guid AccountTypeId { get; set; }
        public string AccountTypeCode { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeDescription { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAccountTypeRequest FromDto(AccountTypeDto accountTypeDto)
        {
            return new UpdateAccountTypeRequest
            {
                AccountTypeId = accountTypeDto.AccountTypeId,
                AccountTypeCode = accountTypeDto.AccountTypeCode,
                AccountTypeName = accountTypeDto.AccountTypeName,
                AccountTypeDescription = accountTypeDto.AccountTypeDescription,
                TenantId = accountTypeDto.TenantId
            };
        }
    }
}