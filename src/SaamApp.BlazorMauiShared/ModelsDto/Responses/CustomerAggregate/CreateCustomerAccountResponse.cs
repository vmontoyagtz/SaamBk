using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class CreateCustomerAccountResponse : BaseResponse
    {
        public CreateCustomerAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerAccountResponse()
        {
        }

        public CustomerAccountDto CustomerAccount { get; set; } = new();
    }
}