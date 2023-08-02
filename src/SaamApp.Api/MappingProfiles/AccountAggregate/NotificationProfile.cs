using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Notification;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationDto, Notification>();
            CreateMap<CreateNotificationRequest, Notification>();
            CreateMap<UpdateNotificationRequest, Notification>();
            CreateMap<DeleteNotificationRequest, Notification>();
        }
    }
}