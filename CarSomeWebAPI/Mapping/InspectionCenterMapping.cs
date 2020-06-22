using AutoMapper;
using CarSomeWebAPI.Data.Entities;
using CarSomeWebAPI.Infrastructure.Dto;

namespace CarSomeWebAPI.Mapping
{
    public class InspectionCenterMapping : Profile
    {
        public InspectionCenterMapping()
        {
            CreateMap<InspectionCenterDto, InspectionCenter>()
                .ForMember(dest => dest.InspectionCenterID, opt => opt.MapFrom(src => src.InspectionCenterID))
                .ForMember(dest => dest.ICName, opt => opt.MapFrom(src => src.ICName))
                .ForMember(dest => dest.ICAddress, opt => opt.MapFrom(src => src.ICAddress))
                .ForMember(dest => dest.ICContactNumber, opt => opt.MapFrom(src => src.ICContactNumber));

            CreateMap<InspectionCenter, InspectionCenterDto>()
                .ForMember(dest => dest.InspectionCenterID, opt => opt.MapFrom(src => src.InspectionCenterID))
                .ForMember(dest => dest.ICName, opt => opt.MapFrom(src => src.ICName))
                .ForMember(dest => dest.ICAddress, opt => opt.MapFrom(src => src.ICAddress))
                .ForMember(dest => dest.ICContactNumber, opt => opt.MapFrom(src => src.ICContactNumber));
        }
    }
}
