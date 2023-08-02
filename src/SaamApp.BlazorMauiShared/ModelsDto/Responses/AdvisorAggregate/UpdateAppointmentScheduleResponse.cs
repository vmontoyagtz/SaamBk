using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class UpdateAppointmentScheduleResponse : BaseResponse
    {
        public UpdateAppointmentScheduleResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAppointmentScheduleResponse()
        {
        }

        public AppointmentScheduleDto AppointmentSchedule { get; set; } = new();
    }
}