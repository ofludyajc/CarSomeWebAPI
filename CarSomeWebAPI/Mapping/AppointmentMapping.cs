using AutoMapper;
using CarSomeWebAPI.Data.Entities;
using CarSomeWebAPI.Infrastructure.Dto;

namespace CarSomeWebAPI.Mapping
{
    public class AppointmentMapping : Profile
    {
        public AppointmentMapping()
        {
            CreateMap<AppointmentDto, Appointment>()
                .ForMember(dest => dest.AppointmentID, opt => opt.MapFrom(src => src.AppointmentID))
                .ForMember(dest => dest.InspectionCenterID, opt => opt.MapFrom(src => src.InspectionCenterID))
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.InspectionDate, opt => opt.MapFrom(src => src.InspectionDate));
                //.ForPath(dest => dest.InspectionCentre.ICName, opt => opt.MapFrom(src => src.ICName))
                //.ForPath(dest => dest.InspectionCentre.ICAddress, opt => opt.MapFrom(src => src.ICAddress))
                //.ForPath(dest => dest.InspectionCentre.ICContactNumber, opt => opt.MapFrom(src => src.ICContactNumber))
                //.ForPath(dest => dest.CustomerInfo.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                //.ForPath(dest => dest.CustomerInfo.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo));

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.AppointmentID, opt => opt.MapFrom(src => src.AppointmentID))
                .ForMember(dest => dest.InspectionCenterID, opt => opt.MapFrom(src => src.InspectionCenterID))
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.InspectionDate, opt => opt.MapFrom(src => src.InspectionDate));
                //.ForPath(dest => dest.ICName, opt => opt.MapFrom(src => src.InspectionCentre.ICName))
                //.ForPath(dest => dest.ICAddress, opt => opt.MapFrom(src => src.InspectionCentre.ICAddress))
                //.ForPath(dest => dest.ICContactNumber, opt => opt.MapFrom(src => src.InspectionCentre.ICContactNumber))
                //.ForPath(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerInfo.CustomerName))
                //.ForPath(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.CustomerInfo.ContactInfo))
        }
    }
}
