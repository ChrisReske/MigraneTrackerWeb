using System;
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

        #region Helper methods

        CreateEntryFormModel CreateFakeCreateEntryFormModel()
        {
            var fakeEntryFormModel = new CreateEntryFormModel
            {
                HoursOfActivity = 7.5f
            };

            return fakeEntryFormModel;
        }

        #endregion

    }
}