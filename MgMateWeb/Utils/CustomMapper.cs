using System.Collections.Generic;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;

namespace MgMateWeb.Utils
{
    public class CustomMapper : ICustomMapper
    {
        #region AccompanyingSymptom

        public async Task<AccompanyingSymptom> MapFromAccompanyingSymptomDtoAsync(AccompanyingSymptomDto accompanyingSymptomDto)
        {
            if(accompanyingSymptomDto is null)
            {
                return new AccompanyingSymptom();
            }

            var accompanyingSymptom = new AccompanyingSymptom
            {
                CreationDate = accompanyingSymptomDto.CreationDate,
                Description = accompanyingSymptomDto.Description,
                Id = accompanyingSymptomDto.Id,
                LastEditedAt = accompanyingSymptomDto.LastEditedAt
            };

            return await Task
                .FromResult(accompanyingSymptom)
                .ConfigureAwait(false);
        }

        public async Task<AccompanyingSymptomDto> MapToAccompanyingSymptomDtoAsync(AccompanyingSymptom accompanyingSymptom)
        {
            if (accompanyingSymptom is null)
            {
                return new AccompanyingSymptomDto();
            }

            var accompanyingSymptomDto = new AccompanyingSymptomDto()
            {
                CreationDate = accompanyingSymptom.CreationDate,
                Description = accompanyingSymptom.Description,
                Id = accompanyingSymptom.Id,
                LastEditedAt = accompanyingSymptom.LastEditedAt,
            };

            return await Task
                .FromResult(accompanyingSymptomDto)
                .ConfigureAwait(false);

        }

        public async Task<IEnumerable<AccompanyingSymptom>> MapFromMultipleAccompanyingSymptomsDtoAsync(
            IEnumerable<AccompanyingSymptomDto> accompanyingSymptomDtos)
        {
            if(accompanyingSymptomDtos is null)
            {
                return new List<AccompanyingSymptom>();
            }

            var accompanyingSymptoms = new List<AccompanyingSymptom>();

            foreach (var accompanyingSymptomDto in accompanyingSymptomDtos)
            {
                var accompanyingSymptom = await MapFromAccompanyingSymptomDtoAsync(accompanyingSymptomDto)
                    .ConfigureAwait(false);
                
                accompanyingSymptoms.Add(accompanyingSymptom);
            }

            return await Task.FromResult(accompanyingSymptoms);
        }

        public async Task<IEnumerable<AccompanyingSymptomDto>> MapToMultipleAccompanyingSymptomsDtoAsync(
            IEnumerable<AccompanyingSymptom> accompanyingSymptoms)
        {
            if (accompanyingSymptoms is null)
            {
                return new List<AccompanyingSymptomDto>();
            }

            var accompanyingSymptomDtos = new List<AccompanyingSymptomDto>();

            foreach (var accompanyingSymptom in accompanyingSymptoms)
            {
                var accompanyingSymptomDto = await MapToAccompanyingSymptomDtoAsync(accompanyingSymptom)
                    .ConfigureAwait(false);

                accompanyingSymptomDtos.Add(accompanyingSymptomDto);
            }

            return await Task.FromResult(accompanyingSymptomDtos);
        }

        #endregion
    }
}