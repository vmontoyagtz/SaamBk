using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class CreateAppointmentScheduleResponse : BaseResponse
    {
        public CreateAppointmentScheduleResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAppointmentScheduleResponse()
        {
        }

        public AppointmentScheduleDto AppointmentSchedule { get; set; } = new();
    }
}