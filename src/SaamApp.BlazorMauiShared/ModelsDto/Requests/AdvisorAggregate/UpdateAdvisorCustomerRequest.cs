using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorCustomer
{
    public class UpdateAdvisorCustomerRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid CustomerId { get; set; }

        public static UpdateAdvisorCustomerRequest FromDto(AdvisorCustomerDto advisorCustomerDto)
        {
            return new UpdateAdvisorCustomerRequest
            {
                RowId = advisorCustomerDto.RowId,
                AdvisorId = advisorCustomerDto.AdvisorId,
                CustomerId = advisorCustomerDto.CustomerId
            };
        }
    }
}