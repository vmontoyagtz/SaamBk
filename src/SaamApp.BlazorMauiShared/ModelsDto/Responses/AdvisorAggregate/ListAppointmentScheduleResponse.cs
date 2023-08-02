using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppointmentSchedule
{
    public class ListAppointmentScheduleResponse : BaseResponse
    {
        public ListAppointmentScheduleResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAppointmentScheduleResponse()
        {
        }

        public List<AppointmentScheduleDto> AppointmentSchedules { get; set; } = new();

        public int Count { get; set; }
    }
}