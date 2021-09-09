﻿using System;
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
            var fakeDto = CreateFakeAccompanyingSymptomDto();

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
            var fakeDto = CreateFakeAccompanyingSymptomDto();
            var fakeAccompanyingSymptomObject = CreateFakeAccompanyingSymptomObject();

            _fakeCustomMapper.Setup(fcm => fcm
                .MapAccompanyingSymptomFromDtoAsync(fakeDto))
                .Returns(Task.FromResult(fakeAccompanyingSymptomObject));

            var result = _accompanyingSymptomsControllerUtils
                .MapAccompanyingSymptomFromDtoAsync(fakeDto);

            Assert.AreEqual(fakeDto.Description, result.Result.Description);
        }

        #endregion

        #region Helper methods

        private static AccompanyingSymptom CreateFakeAccompanyingSymptomObject()
        {
            var fakeAccompanyingSymptomObject = new AccompanyingSymptom
            {
                CreationDate = new DateTime(2021, 8, 21),
                Description = "DummyDescription",
                Id = 1
            };
            return fakeAccompanyingSymptomObject;
        }

        private static AccompanyingSymptomDto CreateFakeAccompanyingSymptomDto()
        {
            var fakeDto = new AccompanyingSymptomDto
            {
                CreationDate = new DateTime(2021, 8, 21),
                Description = "DummyDescription",
                Id = 1
            };
            return fakeDto;
        }

        #endregion

    }
}