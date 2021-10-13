using System;
using MgMateWeb.Dto;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.FormModels;
using MgMateWeb.Utils.Mappers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests.MapperTests
{
    [TestFixture]
    public class EntryMapperTests
    {
        #region Fields and constants

        EntryMapper _entryMapper;

        #endregion

        [SetUp]
        public void Init()
        {
            _entryMapper = new EntryMapper();

        }

        #region Testing EntryMapper > CreateInitialEntryAsync

        [Test]
        public void CreateInitialEntryAsync_ParameterCreateEntryFormModelIsNull_ReturnsNewAndEmptyEntry()
        {
            var emptyEntry = new Entry{ };

            var result = _entryMapper.CreateInitialEntryAsync(null);

            var emptyEntryJson = JsonConvert.SerializeObject(emptyEntry);
            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(emptyEntryJson, resultJson);

        }

        [Test]
        public void CreateInitialEntryAsync_ParameterCreateEntryFormModelIsEmpty_ReturnsNewEntryWithCreationDateSetToCurrentDate()
        {
            var minDate = DateTime.MinValue;

            var result = _entryMapper
                .CreateInitialEntryAsync(new CreateEntryFormModel());

            Assert.AreNotEqual(minDate, result.Result.CreationDate);

        }

        [Test]
        public void CreateInitialEntryAsync_ParameterCreateEntryFormModelHasValues_ReturnsNewEntryWithMappedProperties()
        {
           
            var fakeEntryFormModel = CreateFakeCreateEntryFormModel();

            var result = _entryMapper
                .CreateInitialEntryAsync(fakeEntryFormModel);

            Assert.AreEqual(fakeEntryFormModel.HoursOfActivity, result.Result.HoursOfActivity);

        }

        #endregion

        #region Testing EntryMapper > MapEntryToEntryDtoAsync

        [Test]
        public void MapEntryToEntryDtoAsync_ParameterEntryIsNull_ReturnsNewAndEmptyEntryDto()
        {
            var emptyDto = new EntryDto();
            var emptyDtoJson = JsonConvert.SerializeObject(emptyDto);

            var result = _entryMapper.MapEntryToEntryDtoAsync(null);
            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(emptyDtoJson, resultJson);

        }

        [Test]
        public void MapEntryToEntryDtoAsync_ParameterEntryIsNewEntry_ReturnsNewAndEmptyEntryDto()
        {
            var emptyDto = new EntryDto();
            var emptyDtoJson = JsonConvert.SerializeObject(emptyDto);

            var result = _entryMapper.MapEntryToEntryDtoAsync(new Entry());
            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(emptyDtoJson, resultJson);

        }

        [Test]
        public void MapEntryToEntryDtoAsync_ParameterEntryHasValues_ReturnsNewDtoWithMappedValues()
        {
            var fakeEntryModel = CreateFakeEntry();

            var result = _entryMapper.MapEntryToEntryDtoAsync(fakeEntryModel);

            Assert.AreEqual(fakeEntryModel.HoursOfActivity, result.Result.HoursOfActivity);
        }

        #endregion

        #region Helper methods

        private CreateEntryFormModel CreateFakeCreateEntryFormModel()
        {
            var fakeEntryFormModel = new CreateEntryFormModel
            {
                HoursOfActivity = 7.5f
            };

            return fakeEntryFormModel;
        }

        private Entry CreateFakeEntry()
        {
            var entry = new Entry
            {
                HoursOfActivity = 5.5f
            };

            return entry;

        }

        #endregion

    }
}