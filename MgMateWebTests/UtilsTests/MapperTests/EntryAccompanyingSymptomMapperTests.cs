using MgMateWeb.Models.EntryModels;
using MgMateWeb.Models.RelationshipModels;
using MgMateWeb.Utils.Mappers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests.MapperTests
{
    [TestFixture]
    public class EntryAccompanyingSymptomMapperTests
    {
        #region Fields and constants

        EntryAccompanyingSymptomMapper _accompanyingSymptomMapper;

        #endregion

        [SetUp]
        public void Init()
        {
            _accompanyingSymptomMapper = new EntryAccompanyingSymptomMapper();
        }

        #region Testing EntryAccompanyingSymptomMapper > MapEntryAccompanyingSymptomAsync

        [Test]
        public void CreateEntryAccompanyingSymptomAsync_ParameterEntryIsNull_ReturnsNewAndEmptyEntryAccompanyingSymptom()
        {
            var dummyEntryAccompanyingSymptom = new EntryAccompanyingSymptom();
            var dummyJson = JsonConvert.SerializeObject(dummyEntryAccompanyingSymptom);

            var result =
                _accompanyingSymptomMapper
                    .MapEntryAccompanyingSymptomAsync(null, new AccompanyingSymptom());

            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(dummyJson, resultJson);
            
        }

        [Test]
        public void CreateEntryAccompanyingSymptomAsync_ParameterAccompanyingSymptomIsNull_ReturnsNewAndEmptyEntryAccompanyingSymptom()
        {
            var dummyEntryAccompanyingSymptom = new EntryAccompanyingSymptom();
            var dummyJson = JsonConvert.SerializeObject(dummyEntryAccompanyingSymptom);

            var result =
                _accompanyingSymptomMapper
                    .MapEntryAccompanyingSymptomAsync(new Entry(), null);

            var resultJson = JsonConvert.SerializeObject(result.Result);

            Assert.AreEqual(dummyJson, resultJson);

        }


        [Test]
        public void
            CreateEntryAccompanyingSymptomAsync_ParametersEntryAndAccompanyingSymptomBothHaveValues_ReturnsEntryAccompanyingSymptomWithMappedProperties()
        {
            var fakeEntry = new Entry()
            {
                HoursOfActivity = 7,
                Id = 42
            };

            var fakeAccompanyingSymptom = new AccompanyingSymptom()
            {
                Description = "This is a test description",
                Id = 24
            };

            var result =
                _accompanyingSymptomMapper
                    .MapEntryAccompanyingSymptomAsync(fakeEntry, fakeAccompanyingSymptom);

            Assert.AreEqual(fakeAccompanyingSymptom.Description, result.Result.AccompanyingSymptom.Description);

        }

        #endregion

    }
}