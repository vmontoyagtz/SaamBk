using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Account
{
    public class UpdateAccountRequest : BaseRequest
    {
        public Guid AccountId { get; set; }
        public Guid AccountStateTypeId { get; set; }
        public Guid AccountTypeId { get; set; }
        public Guid TaxInformationId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string AccountDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateAccountRequest FromDto(AccountDto accountDto)
        {
            return new UpdateAccountRequest
            {
                AccountId = accountDto.AccountId,
                AccountStateTypeId = accountDto.AccountStateTypeId,
                AccountTypeId = accountDto.AccountTypeId,
                TaxInformationId = accountDto.TaxInformationId,
                AccountNumber = accountDto.AccountNumber,
                AccountName = accountDto.AccountName,
                AccountDescription = accountDto.AccountDescription,
                CreatedAt = accountDto.CreatedAt,
                CreatedBy = accountDto.CreatedBy,
                UpdatedAt = accountDto.UpdatedAt,
                UpdatedBy = accountDto.UpdatedBy,
                IsDeleted = accountDto.IsDeleted,
                TenantId = accountDto.TenantId
            };
        }
    }
}