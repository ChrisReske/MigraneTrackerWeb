using System;
using MgMateWeb.Controllers;
using MgMateWeb.Interfaces.MapperInterfaces;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using Moq;
using NUnit.Framework;

namespace MgMateWebTests.ControllerTests
{
    [TestFixture]
    public class AccompanyingSymptomsControllerTests
    {
        #region Fields and constants

        private Mock<IUnitOfWork> _fakeUnitOfWork;
        private Mock<IAccompanyingSymptomMapper> _fakeAccompanyingSymptomMapper;

        AccompanyingSymptomsController _accompanyingSymptomsController;


        #endregion

        [SetUp]
        public void Init()
        {
            _fakeUnitOfWork = new Mock<IUnitOfWork>();
            _fakeAccompanyingSymptomMapper = new Mock<IAccompanyingSymptomMapper>();

            _accompanyingSymptomsController =
                new AccompanyingSymptomsController(
                    _fakeUnitOfWork.Object, 
                    _fakeAccompanyingSymptomMapper.Object);

        }

        #region Testing AccompanyingSymptomsController > Constructor(s)

        [Test]
        public void AccompanyingSymptomsControllerConstructor_ParameterIUnitOfWorkIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var unused = new AccompanyingSymptomsController(
                        null, 
                        _fakeAccompanyingSymptomMapper.Object);
                });

        }

        [Test]
        public void AccompanyingSymptomsControllerConstructor_ParameterICustomMapperIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    var unused = new AccompanyingSymptomsController(
                        _fakeUnitOfWork.Object,
                        null);
                });

        }

        #endregion

    }
}