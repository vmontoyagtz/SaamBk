using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class UpdateBusinessUnitTypeRequest : BaseRequest
    {
        public Guid BusinessUnitTypeId { get; set; }
        public string BusinessUnitTypeName { get; set; }
        public string? BusinessUnitTypeDescription { get; set; }

        public static UpdateBusinessUnitTypeRequest FromDto(BusinessUnitTypeDto businessUnitTypeDto)
        {
            return new UpdateBusinessUnitTypeRequest
            {
                BusinessUnitTypeId = businessUnitTypeDto.BusinessUnitTypeId,
                BusinessUnitTypeName = businessUnitTypeDto.BusinessUnitTypeName,
                BusinessUnitTypeDescription = businessUnitTypeDto.BusinessUnitTypeDescription
            };
        }
    }
}