using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class GetByIdAppointmentScheduleResponse : BaseResponse
    {
        public GetByIdAppointmentScheduleResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAppointmentScheduleResponse()
        {
        }

        public AppointmentScheduleDto AppointmentSchedule { get; set; } = new();
    }
}