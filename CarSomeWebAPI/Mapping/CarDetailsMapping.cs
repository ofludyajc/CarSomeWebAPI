using AutoMapper;
using CarSomeWebAPI.Data.Entities;
using CarSomeWebAPI.Infrastructure.Dto;

namespace CarSomeWebAPI.Mapping
{
    public class CarDetailsMapping : Profile
    {
        public CarDetailsMapping()
        {
            CreateMap<CarDetailsDto, CarDetails>()
                .ForMember(dest => dest.CarDetailID, opt => opt.MapFrom(src => src.CarDetailID))
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.CarInformation, opt => opt.MapFrom(src => src.CarInformation))
                .ForPath(dest => dest.CustomerInfo.CustomerID, opt => opt.MapFrom(src => src.CustomerInfo.CustomerID))
                .ForPath(dest => dest.CustomerInfo.CustomerName, opt => opt.MapFrom(src => src.CustomerInfo.CustomerName))
                .ForPath(dest => dest.CustomerInfo.ContactInfo, opt => opt.MapFrom(src => src.CustomerInfo.ContactInfo));

            CreateMap<CarDetails, CarDetailsDto>()
                .ForMember(dest => dest.CarDetailID, opt => opt.MapFrom(src => src.CarDetailID))
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.CarInformation, opt => opt.MapFrom(src => src.CarInformation))
                .ForPath(dest => dest.CustomerInfo.CustomerID, opt => opt.MapFrom(src => src.CustomerInfo.CustomerID))
                .ForPath(dest => dest.CustomerInfo.CustomerName, opt => opt.MapFrom(src => src.CustomerInfo.CustomerName))
                .ForPath(dest => dest.CustomerInfo.ContactInfo, opt => opt.MapFrom(src => src.CustomerInfo.ContactInfo));
        }
    }
}
