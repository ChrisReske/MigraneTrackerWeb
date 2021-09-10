using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MgMateWeb.Controllers;
using MgMateWeb.Interfaces.UtilsInterfaces.ControllerUtilsInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace MgMateWebTests.ControllerTests
{
    [TestFixture]
    public class AccompanyingSymptomsControllerTests
    {
        #region Fields and constants

        private Mock<IUnitOfWork> _fakeUnitOfWork;
        private Mock<IMapper> _fakeAutoMapper;
        private Mock<IAccompanyingSymptomsControllerUtils> _fakeControllerUtils;

        private AccompanyingSymptomsController _accompanyingSymptomsController;

        #endregion

        [SetUp]
        public void Init()
        {
            _fakeUnitOfWork = new Mock<IUnitOfWork>();
            _fakeAutoMapper = new Mock<IMapper>();
            _fakeControllerUtils = new Mock<IAccompanyingSymptomsControllerUtils>();

            _accompanyingSymptomsController = new AccompanyingSymptomsController(
                _fakeAutoMapper.Object,
                _fakeUnitOfWork.Object,
                _fakeControllerUtils.Object);
        }

        #region Testing AccompanyingSymptomsController > Constructor(s)

        [Test]
        public void AccompanyingSymptomsController_ConstructorParameterAutomapperIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unused = new AccompanyingSymptomsController(
                    null,
                    _fakeUnitOfWork.Object,
                    _fakeControllerUtils.Object);
            });
        }

        [Test]
        public void AccompanyingSymptomsController_ConstructorParameterUnitOfWorkIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unused = new AccompanyingSymptomsController(
                    _fakeAutoMapper.Object,
                    null,
                    _fakeControllerUtils.Object);
            });
        }

        [Test]
        public void
            AccompanyingSymptomsController_ConstructorParameterAccompanyingSymptomsControllerUtilsIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unused = new AccompanyingSymptomsController(
                    _fakeAutoMapper.Object,
                    _fakeUnitOfWork.Object,
                    null);
            });
        }

        #endregion

        #region Testing AccompanyingSymptomsController > Index()

        [Test]
        public void Index_NoDataToDisplayReturnedFromDatabase_ReturnsNoContentResult()
        {
            IEnumerable<AccompanyingSymptom> emptyList = new List<AccompanyingSymptom>();
            
            _fakeUnitOfWork.Setup(fuow => fuow
                .AccompanyingSymptomRepository
                .GetAllAsync()).Returns((Task.FromResult(emptyList)));

            var result = _accompanyingSymptomsController.Index();

            result.Result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public void Index_DataIsReturnedFromDatabase_ReturnsViewResult()
        {
            IEnumerable<AccompanyingSymptom> fakeSymptomsList = new List<AccompanyingSymptom>
            {
                new AccompanyingSymptom()
                {
                    Description = "Some description",
                    CreationDate = DateTime.Now,
                    Id = 1,
                }
            };

            _fakeUnitOfWork.Setup(fuow => fuow
                .AccompanyingSymptomRepository
                .GetAllAsync()).Returns((Task.FromResult(fakeSymptomsList)));

            var result = _accompanyingSymptomsController.Index();

            result.Result.Should().BeOfType<ViewResult>();

        }

        #endregion

        #region Testing AccompanyingSymptomsController > Details

        [Test]
        public void Details_ParameterIdIsNull_ReturnsNotFound()
        {
            var result = _accompanyingSymptomsController.Details(null);

            result.Result.Should().BeOfType<NotFoundResult>();

        }

        [Test]
        public void Details_QueryForIdReturnsNull_ReturnsNoContentResult()
        {
            const int testId = 1;

            _fakeUnitOfWork.Setup(fuow => fuow
                .AccompanyingSymptomRepository
                .GetAsync(testId))
                .Returns(Task.FromResult<AccompanyingSymptom>(null));

            var result = _accompanyingSymptomsController.Details(testId);

            result.Result.Should().BeOfType<NoContentResult>();

        }

        #endregion
    }
}