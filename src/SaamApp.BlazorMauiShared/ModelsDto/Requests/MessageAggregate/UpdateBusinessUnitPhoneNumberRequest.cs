using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class UpdateBusinessUnitPhoneNumberRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberTypeId { get; set; }

        public static UpdateBusinessUnitPhoneNumberRequest FromDto(
            BusinessUnitPhoneNumberDto businessUnitPhoneNumberDto)
        {
            return new UpdateBusinessUnitPhoneNumberRequest
            {
                RowId = businessUnitPhoneNumberDto.RowId,
                BusinessUnitId = businessUnitPhoneNumberDto.BusinessUnitId,
                PhoneNumberId = businessUnitPhoneNumberDto.PhoneNumberId,
                PhoneNumberTypeId = businessUnitPhoneNumberDto.PhoneNumberTypeId
            };
        }
    }
}