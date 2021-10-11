using System;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Utils;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests
{
    [TestFixture]
    public class CustomMapperTests
    {
        #region Fields and constants

        CustomMapper _customMapper;

        #endregion

        [SetUp]
        public void Init()
        {
            _customMapper = new CustomMapper();
        }

        #region Testing CustomMapper > MapFromAccompanyingSymptomDtoAsync

        [Test]
        public void MapFromAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomDtoIsNull_ReturnsNewAccompanyingSymptomObject()
        {
            var result = _customMapper.MapFromAccompanyingSymptomDtoAsync(null);

            Assert.IsTrue(result.Result.CreationDate == DateTime.MinValue);
        }

        [Test]
        public void MapFromAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomDtoIsEmpty_ReturnsEmptyAccompanyingSymptomObject()
        {
            var fakeAccompanyingSymptomsDto = new AccompanyingSymptomDto();

            var result = _customMapper.MapFromAccompanyingSymptomDtoAsync(fakeAccompanyingSymptomsDto);

            Assert.IsTrue(result.Result.CreationDate == DateTime.MinValue);
        }

        [Test]
        public void MapFromAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomDtoHasValues_ReturnsNewAccompanyingSymptomsObjectWithMappedValues()
        {
            var fakeAccompanyingSymptomsDto = CreateFakeAccompanyingSymptomDto();

            var result = _customMapper.MapFromAccompanyingSymptomDtoAsync(fakeAccompanyingSymptomsDto);

            var fakeAccompanyingSymptomsDtoJson = JsonConvert.SerializeObject(fakeAccompanyingSymptomsDto);
            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(fakeAccompanyingSymptomsDtoJson, resultJson);
        }

        #endregion

        #region Helper methods

        private AccompanyingSymptomDto CreateFakeAccompanyingSymptomDto()
        {
            var accompanyingSymptomDto = new AccompanyingSymptomDto
            {
                CreationDate = new DateTime(2021, 1, 2),
                Description = "This is a test description",
                Id = 1,
                LastEditedAt = new DateTime(2021, 1, 3)
            };

            return accompanyingSymptomDto;
        }

        private AccompanyingSymptom CreateFakeAccompanyingSymptom()
        {
            var accompanyingSymptom = new AccompanyingSymptom
            {
                CreationDate = new DateTime(2021, 2, 1),
                Description = "This is a test description",
                Id = 1,
                LastEditedAt = new DateTime(2021, 3, 1)
            };

            return accompanyingSymptom;
        }


        #endregion
    }
}