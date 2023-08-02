using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AppointmentSchedule;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AppointmentScheduleProfile : Profile
    {
        public AppointmentScheduleProfile()
        {
            CreateMap<AppointmentSchedule, AppointmentScheduleDto>();
            CreateMap<AppointmentScheduleDto, AppointmentSchedule>();
            CreateMap<CreateAppointmentScheduleRequest, AppointmentSchedule>();
            CreateMap<UpdateAppointmentScheduleRequest, AppointmentSchedule>();
            CreateMap<DeleteAppointmentScheduleRequest, AppointmentSchedule>();
        }
    }
}