using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAccount
{
    public class GetByIdCustomerAccountResponse : BaseResponse
    {
        public GetByIdCustomerAccountResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerAccountResponse()
        {
        }

        public CustomerAccountDto CustomerAccount { get; set; } = new();
    }
}