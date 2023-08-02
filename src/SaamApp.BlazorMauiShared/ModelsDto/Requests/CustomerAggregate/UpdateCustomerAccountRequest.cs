using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class UpdateCustomerAccountRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }

        public static UpdateCustomerAccountRequest FromDto(CustomerAccountDto customerAccountDto)
        {
            return new UpdateCustomerAccountRequest
            {
                RowId = customerAccountDto.RowId,
                AccountId = customerAccountDto.AccountId,
                CustomerId = customerAccountDto.CustomerId
            };
        }
    }
}