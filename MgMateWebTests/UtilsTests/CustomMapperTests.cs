using System;
using MgMateWeb.Utils;
using MgMateWebTests.UtilsTests.ControllerUtilsTests;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests
{
    [TestFixture]
    public class CustomMapperTests
    {
        #region Fields and constants

        private CustomMapper _customMapper;

        #endregion

        [SetUp]
        public void Init()
        {
            _customMapper = new CustomMapper();

        }

        #region Testing CustomMapper > MapAccompanyingSymptomFromDtoAsync

        [Test]
        public void MapAccompanyingSymptomFromDtoAsync_ParameterAccompanyingSymptomDtoIsNull_ReturnsNewAndEmptyAccompanyingSymptomObject()
        {
            var expectedDate = DateTime.MinValue;

            var result = _customMapper.MapAccompanyingSymptomFromDtoAsync(null);

            Assert.AreEqual(expectedDate, result.Result.CreationDate);
        }

        [Test]
        public void MapAccompanyingSymptomFromDtoAsync_ParameterAccompanyingSymptomIsNotNull_ReturnsMappedAccompanyingSymptomObject()
        {
            var fakeDto = TestHelper.CreateFakeAccompanyingSymptomDto();

            var result = _customMapper.MapAccompanyingSymptomFromDtoAsync(fakeDto);

            Assert.AreEqual(fakeDto.Description, result.Result.Description);

        }

        #endregion
    }
}