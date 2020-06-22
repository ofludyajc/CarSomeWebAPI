using AutoMapper;
using CarSomeWebAPI.Data.Entities;
using CarSomeWebAPI.Infrastructure.Dto;

namespace CarSomeWebAPI.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                .ForPath(dest => dest.CarDetails.CarDetailID, opt => opt.MapFrom(src => src.CarDetails.CarDetailID))
                .ForPath(dest => dest.CarDetails.CarInformation, opt => opt.MapFrom(src => src.CarDetails.CarInformation));

            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
                .ForPath(dest => dest.CarDetails.CarDetailID, opt => opt.MapFrom(src => src.CarDetails.CarDetailID))
                .ForPath(dest => dest.CarDetails.CarInformation, opt => opt.MapFrom(src => src.CarDetails.CarInformation));
        }
    }
}
