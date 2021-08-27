using AutoMapper;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccompanyingSymptom, AccompanyingSymptomDto>();
            CreateMap<AccompanyingSymptomDto, AccompanyingSymptom>();

        }
    }
}