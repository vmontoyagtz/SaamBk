using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Bank
{
    public class UpdateBankRequest : BaseRequest
    {
        public Guid BankId { get; set; }
        public string BankName { get; set; }
        public string? BankSwiftCodeInfo { get; set; }
        public string BankAddress { get; set; }
        public string BankPhoneNumber { get; set; }
        public string BankEmailAddress { get; set; }
        public string BankNotes { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateBankRequest FromDto(BankDto bankDto)
        {
            return new UpdateBankRequest
            {
                BankId = bankDto.BankId,
                BankName = bankDto.BankName,
                BankSwiftCodeInfo = bankDto.BankSwiftCodeInfo,
                BankAddress = bankDto.BankAddress,
                BankPhoneNumber = bankDto.BankPhoneNumber,
                BankEmailAddress = bankDto.BankEmailAddress,
                BankNotes = bankDto.BankNotes,
                CreatedAt = bankDto.CreatedAt,
                CreatedBy = bankDto.CreatedBy,
                UpdatedAt = bankDto.UpdatedAt,
                UpdatedBy = bankDto.UpdatedBy,
                IsDeleted = bankDto.IsDeleted,
                TenantId = bankDto.TenantId
            };
        }
    }
}