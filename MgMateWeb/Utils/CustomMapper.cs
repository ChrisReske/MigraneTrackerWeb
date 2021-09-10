using System;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Utils
{
    public class CustomMapper : ICustomMapper
    {
        public async Task<AccompanyingSymptom> CreateNewAccompanyingSymptomFromDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if(accompanyingSymptomDto is null)
            {
                return new AccompanyingSymptom();
            }

            accompanyingSymptomDto.CreationDate = DateTime.Now;

            var accompanyingSymptom = new AccompanyingSymptom
            {
                CreationDate = accompanyingSymptomDto.CreationDate,
                Description = accompanyingSymptomDto.Description,
                Id = accompanyingSymptomDto.Id
            };

            return await Task
                .FromResult(accompanyingSymptom)
                .ConfigureAwait(false);
        }
    }
}