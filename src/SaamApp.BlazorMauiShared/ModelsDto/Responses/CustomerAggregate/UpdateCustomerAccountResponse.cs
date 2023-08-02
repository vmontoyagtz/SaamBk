using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class UpdateCustomerAccountResponse : BaseResponse
    {
        public UpdateCustomerAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerAccountResponse()
        {
        }

        public CustomerAccountDto CustomerAccount { get; set; } = new();
    }
}