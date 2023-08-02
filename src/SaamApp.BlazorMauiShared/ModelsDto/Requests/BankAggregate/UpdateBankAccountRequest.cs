using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BankAccount
{
    public class UpdateBankAccountRequest : BaseRequest
    {
        public Guid BankAccountId { get; set; }
        public Guid BankId { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankAccountNotificationPhoneNumber { get; set; }
        public string BankAccountNotificationEmailAddress { get; set; }
        public string? Description { get; set; }
        public bool IsDefault { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateBankAccountRequest FromDto(BankAccountDto bankAccountDto)
        {
            return new UpdateBankAccountRequest
            {
                BankAccountId = bankAccountDto.BankAccountId,
                BankId = bankAccountDto.BankId,
                BankAccountName = bankAccountDto.BankAccountName,
                BankAccountNumber = bankAccountDto.BankAccountNumber,
                BankAccountNotificationPhoneNumber = bankAccountDto.BankAccountNotificationPhoneNumber,
                BankAccountNotificationEmailAddress = bankAccountDto.BankAccountNotificationEmailAddress,
                Description = bankAccountDto.Description,
                IsDefault = bankAccountDto.IsDefault,
                TenantId = bankAccountDto.TenantId
            };
        }
    }
}