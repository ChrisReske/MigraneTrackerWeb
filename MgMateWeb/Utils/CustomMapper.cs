using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Utils
{
    public class CustomMapper : ICustomMapper
    {
        public async Task<AccompanyingSymptom> MapFromAccompanyingSymptomDto(AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if(accompanyingSymptomDto is null)
            {
                return new AccompanyingSymptom();
            }

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

        public async Task<AccompanyingSymptomDto> MapToAccompanyingSymptomDto(AccompanyingSymptom accompanyingSymptom)
        {
            if (accompanyingSymptom is null)
            {
                return new AccompanyingSymptomDto();
            }

            var accompanyingSymptomDto = new AccompanyingSymptomDto()
            {
                CreationDate = accompanyingSymptom.CreationDate,
                Description = accompanyingSymptom.Description,
                Id = accompanyingSymptom.Id
            };

            return await Task
                .FromResult(accompanyingSymptomDto)
                .ConfigureAwait(false);

        }
    }
}