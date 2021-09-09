using System;
using AutoMapper;
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

        private Mock<IMapper> _fakeAutoMapper;
        private Mock<IUnitOfWork> _fakeUnitOfWork;

        private AccompanyingSymptomsControllerUtils _accompanyingSymptomsControllerUtils;

        #endregion

        [SetUp]
        public void Init()
        {
            _fakeAutoMapper = new Mock<IMapper>();
            _fakeUnitOfWork = new Mock<IUnitOfWork>();

            _accompanyingSymptomsControllerUtils =
                new AccompanyingSymptomsControllerUtils(
                    _fakeAutoMapper.Object,
                    _fakeUnitOfWork.Object);

        }

        #region Testing AccompanyingSymptomsControllerUtilsTests > Constructor(s)

        [Test]
        public void Constructor_ParameterMapperIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var accompanyingSymptomsControllerUtils = 
                    new AccompanyingSymptomsControllerUtils(
                        null, 
                        _fakeUnitOfWork.Object);
            });

        }

        [Test]
        public void Constructor_ParameterUnitOfWorkIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var accompanyingSymptomsControllerUtils =
                    new AccompanyingSymptomsControllerUtils(
                        _fakeAutoMapper.Object,
                        null);
            });

        }

        #endregion

    }
}