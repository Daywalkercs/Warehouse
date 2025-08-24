using AutoMapper;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Resource, ResourceDto>().ReverseMap();
            CreateMap<CreateResourceDto, Resource>();
            CreateMap<UpdateResourceDto, Resource>();

            CreateMap<UnitOfMeasurement, UnitDto>().ReverseMap();
            CreateMap<CreateUnitDto, UnitOfMeasurement>();
            CreateMap<UpdateUnitDto, UnitOfMeasurement>();

            CreateMap<Arrival, ArrivalDto>().ForMember
                (dest => dest.ResourceName, opt => opt.MapFrom(src => src.Resource.Name));
            CreateMap<CreateArrivalDto, Arrival>();
            CreateMap<UpdateArrivalDto, Arrival>();
        }
    }
}
