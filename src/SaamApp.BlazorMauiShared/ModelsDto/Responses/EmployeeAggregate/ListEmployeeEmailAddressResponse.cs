using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeEmailAddress
{
    public class ListEmployeeEmailAddressResponse : BaseResponse
    {
        public ListEmployeeEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListEmployeeEmailAddressResponse()
        {
        }

        public List<EmployeeEmailAddressDto> EmployeeEmailAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}