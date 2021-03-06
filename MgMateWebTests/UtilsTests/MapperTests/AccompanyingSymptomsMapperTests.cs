using System;
using System.Collections.Generic;
using System.Linq;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.MapperInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Utils.Mappers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests.MapperTests
{
    [TestFixture]
    public class AccompanyingSymptomsMapperTests
    {
        #region Fields and constants

        private IAccompanyingSymptomMapper _accompanyingSymptomMapper;

        #endregion

        [SetUp]
        public void Init()
        {
            _accompanyingSymptomMapper = new AccompanyingSymptomMapper();

        }

        #region Testing CustomMapper > MapFromAccompanyingSymptomDtoAsync

        [Test]
        public void MapFromAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomDtoIsNull_ReturnsNewAccompanyingSymptomObject()
        {
            var result = _accompanyingSymptomMapper.MapFromAccompanyingSymptomDtoAsync(null);

            Assert.IsTrue(result.Result.CreationDate == DateTime.MinValue);
        }

        [Test]
        public void MapFromAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomDtoIsEmpty_ReturnsEmptyAccompanyingSymptomObject()
        {
            var fakeAccompanyingSymptomsDto = new AccompanyingSymptomDto();

            var result = _accompanyingSymptomMapper.MapFromAccompanyingSymptomDtoAsync(fakeAccompanyingSymptomsDto);

            Assert.IsTrue(result.Result.CreationDate == DateTime.MinValue);
        }

        [Test]
        public void MapFromAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomDtoHasValues_ReturnsNewAccompanyingSymptomsObjectWithMappedValues()
        {
            var fakeAccompanyingSymptomsDto = CreateFakeAccompanyingSymptomDto();

            var result = _accompanyingSymptomMapper.MapFromAccompanyingSymptomDtoAsync(fakeAccompanyingSymptomsDto);

            var fakeAccompanyingSymptomsDtoJson = JsonConvert.SerializeObject(fakeAccompanyingSymptomsDto);
            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(fakeAccompanyingSymptomsDtoJson, resultJson);
        }

        #endregion

        #region Testing CustomMapper > MapToAccompanyingSymptomDtoAsync

        [Test]
        public void MapToAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomIsNull_ReturnsNewAccompanyingSymptomDtoObject()
        {
            var result = _accompanyingSymptomMapper.MapToAccompanyingSymptomDtoAsync(null);

            Assert.IsTrue(result.Result.CreationDate == DateTime.MinValue);
        }

        [Test]
        public void MapToAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomIsEmpty_ReturnsNewAccompanyingSymptomDtoObject()
        {
            var fakeAccompanyingSymptom = new AccompanyingSymptom();

            var result = _accompanyingSymptomMapper
                .MapToAccompanyingSymptomDtoAsync(fakeAccompanyingSymptom);

            Assert.IsTrue(result.Result.CreationDate == DateTime.MinValue);
        }

        [Test]
        public void MapToAccompanyingSymptomDtoAsync_ParameterAccompanyingSymptomDtoHasValues_ReturnsMappedAccompanyingSymptomsDtoObject()
        {
            var fakeAccompanyingSymptom = CreateFakeAccompanyingSymptom();

            var result = _accompanyingSymptomMapper.MapToAccompanyingSymptomDtoAsync(fakeAccompanyingSymptom);

            var fakeAccompanyingSymptomJson = JsonConvert.SerializeObject(CreateFakeAccompanyingSymptom());
            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(fakeAccompanyingSymptomJson, resultJson);
        }

        #endregion

        #region Testing CustomMapper > MapFromMultipleAccompanyingSymptomsDtoAsync

        [Test]
        public void MapFromMultipleAccompanyingSymptomsDtoAsync_ListOfAccompanyingSymptomsDtoIsNull_ReturnsNewListOfAccompanyingSymptoms()
        {
            const int expectedNumberOfListItems = 0;

            var result = _accompanyingSymptomMapper.MapFromMultipleAccompanyingSymptomsDtoAsync(null);

            Assert.AreEqual(expectedNumberOfListItems, result.Result.Count());

        }

        [Test]
        public void MapFromMultipleAccompanyingSymptomsDtoAsync_ListOfAccompanyingSymptomsDtoIsEmpty_ReturnsEmptyListOfAccompanyingSymptoms()
        {
            const int expectedNumberOfListItems = 0;

            var result = _accompanyingSymptomMapper.MapFromMultipleAccompanyingSymptomsDtoAsync(new List<AccompanyingSymptomDto>());

            Assert.AreEqual(expectedNumberOfListItems, result.Result.Count());
        }

        [Test]
        public void MapFromMultipleAccompanyingSymptomsDtoAsync_ListOfAccompanyingSymptomsDtoHasItems_ReturnsListOfMappedAccompanyingSymptomsObjects()
        {
            const int expectedNumberOfMappedListItems = 2;

            var listOfFakeAccompanyingSymptomsDto = CreateListOfFakeAccompanyingSymptomDtos();

            var result = _accompanyingSymptomMapper.MapFromMultipleAccompanyingSymptomsDtoAsync(listOfFakeAccompanyingSymptomsDto);

            Assert.AreEqual(expectedNumberOfMappedListItems, result.Result.Count());
        }

        #endregion

        #region Testing CustomMapper > MapToMultipleAccompanyingSymptomsDtoAsync

        [Test]
        public void MapToMultipleAccompanyingSymptomsDtoAsync_ParameterListOfAccompanyingSymptomsIsNull_ReturnsNewListOfAccompanyingSymptomsDto()
        {
            const int expectedNumberOfListItems = 0;

            var result = _accompanyingSymptomMapper.MapToMultipleAccompanyingSymptomsDtoAsync(null);

            Assert.AreEqual(expectedNumberOfListItems, result.Result.Count());
        }

        [Test]
        public void MapToMultipleAccompanyingSymptomsDtoAsync_ParameterListOfAccompanyingSymptomsIsEmpty_ReturnsEmptyListOfAccompanyingSymptomsDto()
        {
            const int expectedNumberOfListItems = 0;

            var result = _accompanyingSymptomMapper
                .MapToMultipleAccompanyingSymptomsDtoAsync(new List<AccompanyingSymptom>());

            Assert.AreEqual(expectedNumberOfListItems, result.Result.Count());
        }

        [Test]
        public void
            MapToMultipleAccompanyingSymptomsDtoAsync_ParameterListOfAccompanyingSymptomsHasItems_ReturnsListOfMappedAccompanyingSymptomsDtoObjects()
        {
            const int expectedNumberOfMappedListItems = 2;
            var fakeListOfAccompanyingSymptoms = CreateListOfFakeAccompanyingSymptoms();

            var result = _accompanyingSymptomMapper
                .MapToMultipleAccompanyingSymptomsDtoAsync(fakeListOfAccompanyingSymptoms);

            Assert.AreEqual(expectedNumberOfMappedListItems, result.Result.Count());
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

        private List<AccompanyingSymptomDto> CreateListOfFakeAccompanyingSymptomDtos()
        {
            var accompanyingSymptomsDto = new List<AccompanyingSymptomDto>
            {
                new AccompanyingSymptomDto
                {
                    CreationDate = new DateTime(2021, 12, 13),
                    Description = "This is fake description 001",
                    Id = 1,
                    LastEditedAt = new DateTime(2021, 12, 14)
                },
                new AccompanyingSymptomDto
                {
                    CreationDate = new DateTime(2021, 11, 15),
                    Description = "This is fake description 002",
                    Id = 2,
                    LastEditedAt = new DateTime(2021, 11, 16)
                }
            };

            return accompanyingSymptomsDto;
        }

        private List<AccompanyingSymptom> CreateListOfFakeAccompanyingSymptoms()
        {
            var accompanyingSymptoms = new List<AccompanyingSymptom>
            {
                new AccompanyingSymptom
                {
                    CreationDate = new DateTime(2019, 12, 13),
                    Description = "This is fake description 001",
                    Id = 1,
                    LastEditedAt = new DateTime(2019, 12, 14)
                },
                new AccompanyingSymptom
                {
                    CreationDate = new DateTime(2019, 11, 15),
                    Description = "This is fake description 002",
                    Id = 2,
                    LastEditedAt = new DateTime(2019, 11, 16)
                }
            };

            return accompanyingSymptoms;
        }


        #endregion
    }
}