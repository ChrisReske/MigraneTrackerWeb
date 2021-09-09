using System;
using System.Threading.Tasks;
using MgMateWeb.Dto;
using MgMateWeb.Interfaces.UtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Interfaces;
using MgMateWeb.Utils.ControllerUtils;
using Moq;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests.ControllerUtilsTests
{
    [TestFixture]
    public class AccompanyingSymptomsControllerUtilsTests
    {
        #region Fields and constants

        private Mock<ICustomMapper> _fakeCustomMapper;
        private Mock<IUnitOfWork> _fakeUnitOfWork;

        private AccompanyingSymptomsControllerUtils _accompanyingSymptomsControllerUtils;

        #endregion

        [SetUp]
        public void Init()
        {
            _fakeCustomMapper = new Mock<ICustomMapper>();
            _fakeUnitOfWork = new Mock<IUnitOfWork>();

            _accompanyingSymptomsControllerUtils =
                new AccompanyingSymptomsControllerUtils(_fakeUnitOfWork.Object, _fakeCustomMapper.Object);

        }

        #region Testing AccompanyingSymptomsControllerUtilsTests > Constructor(s)

        [Test]
        public void Constructor_ParameterCustomMapperIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var accompanyingSymptomsControllerUtils = 
                    new AccompanyingSymptomsControllerUtils(
                        _fakeUnitOfWork.Object, null);
            });

        }

        [Test]
        public void Constructor_ParameterUnitOfWorkIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var accompanyingSymptomsControllerUtils =
                    new AccompanyingSymptomsControllerUtils(null, _fakeCustomMapper.Object);
            });

        }

        #endregion

        #region Testing AccompanyingSymptomsControllerUtilsTests > MapAccompanyingSymptomFromDtoAsync

        [Test]
        public void MapAccompanyingSymptomFromDtoAsync_ParameterAccompanyingSymptomDtoIsNull_ReturnsNewAndEmptyAccompanyingSymptom()
        {
            var expectedDate = DateTime.MinValue;

            var result = 
                _accompanyingSymptomsControllerUtils
                    .MapAccompanyingSymptomFromDtoAsync(null);

            Assert.AreEqual(expectedDate, result.Result.CreationDate);

        }

        [Test]
        public void MapAccompanyingSymptomFromDtoAsync_CustomMapperReturnsNull_ReturnsNewAndEmptyAccompanyingSymptom()
        {
            var expectedDate = DateTime.MinValue;
            var fakeDto = TestHelper.CreateFakeAccompanyingSymptomDto();

            _fakeCustomMapper.Setup(fcm => fcm
                .MapAccompanyingSymptomFromDtoAsync(fakeDto))
                .Returns((Task<AccompanyingSymptom>)null);

            var result =
                _accompanyingSymptomsControllerUtils
                    .MapAccompanyingSymptomFromDtoAsync(null);

            Assert.AreEqual(expectedDate, result.Result.CreationDate);

        }

        [Test]
        public void MapAccompanyingSymptomFromDtoAsync_ParameterAccompanyingSymptomIsNotNull_ReturnsMappedAccompanyingSymptomsObject()
        {
            var fakeDto = TestHelper.CreateFakeAccompanyingSymptomDto();
            var fakeAccompanyingSymptomObject = TestHelper.CreateFakeAccompanyingSymptomObject();

            _fakeCustomMapper.Setup(fcm => fcm
                .MapAccompanyingSymptomFromDtoAsync(fakeDto))
                .Returns(Task.FromResult(fakeAccompanyingSymptomObject));

            var result = _accompanyingSymptomsControllerUtils
                .MapAccompanyingSymptomFromDtoAsync(fakeDto);

            Assert.AreEqual(fakeDto.Description, result.Result.Description);
        }

        #endregion

        #region Testing AccompanyingSymptomsControllerUtilsTests > SaveToDatabase

        [Test]
        public void SaveToDatabase_ParameterAccompanyingSymptomIsNull_ReturnsMinus1ForFailed()
        {
            const int failed = -1;

            var result = _accompanyingSymptomsControllerUtils
                .SaveModelToDatabaseAsync(null);

            Assert.AreEqual(failed, result.Result);
        }

        [Test]
        public void SaveToDatabase_NoEntriesWrittenToDatabase_ReturnsZeroAsNumberOfEntriesWrittenToDb()
        {
            const int noEntriesWrittenToDb = 0;

            var fakeAccompanyingSymptomObject = TestHelper.CreateFakeAccompanyingSymptomObject();

            _fakeUnitOfWork
                .Setup(fuow => fuow.AccompanyingSymptomRepository
                    .Add(fakeAccompanyingSymptomObject));

            _fakeUnitOfWork.Setup(fuow => fuow
                .CompleteAsync())
                .Returns(Task.FromResult(noEntriesWrittenToDb));


            var result = _accompanyingSymptomsControllerUtils
                .SaveModelToDatabaseAsync(fakeAccompanyingSymptomObject);

            Assert.AreEqual(noEntriesWrittenToDb, result.Result);

        }

        [Test]
        public void SaveToDatabase_OneEntryWrittenToDatabase_ReturnsOneAsNumberOfEntriesWrittenToDb()
        {
            const int numberOfEntriesWrittenToDb = 1;

            var fakeAccompanyingSymptomObject = TestHelper.CreateFakeAccompanyingSymptomObject();

            _fakeUnitOfWork
                .Setup(fuow => fuow.AccompanyingSymptomRepository
                    .Add(fakeAccompanyingSymptomObject));

            _fakeUnitOfWork.Setup(fuow => fuow
                    .CompleteAsync())
                .Returns(Task.FromResult(numberOfEntriesWrittenToDb));


            var result = _accompanyingSymptomsControllerUtils
                .SaveModelToDatabaseAsync(fakeAccompanyingSymptomObject);

            Assert.AreEqual(numberOfEntriesWrittenToDb, result.Result);
        }

        #endregion

    }
}