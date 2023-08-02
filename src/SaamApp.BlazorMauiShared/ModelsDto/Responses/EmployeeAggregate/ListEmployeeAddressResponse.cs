using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmployeeAddress
{
    public class ListEmployeeAddressResponse : BaseResponse
    {
        public ListEmployeeAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListEmployeeAddressResponse()
        {
        }

        public List<EmployeeAddressDto> EmployeeAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}