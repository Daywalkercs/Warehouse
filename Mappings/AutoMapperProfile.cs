using AutoMapper;
using Warehouse.DTOs;
using Warehouse.Migrations;
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
            CreateMap<CreateUnitDto, CreateUnitDto>();
            CreateMap<UpdateUnitDto, CreateUnitDto>();
        }
    }
}
