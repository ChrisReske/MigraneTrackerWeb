using AutoMapper;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region AccompanyingSymptom

            CreateMap<AccompanyingSymptom, AccompanyingSymptomDto>();
            CreateMap<AccompanyingSymptomDto, AccompanyingSymptom>();

            #endregion



        }
    }
}