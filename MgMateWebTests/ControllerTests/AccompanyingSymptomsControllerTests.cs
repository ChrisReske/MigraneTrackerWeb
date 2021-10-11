using System;
using MgMateWeb.Controllers;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Interfaces.UtilsInterfaces;
using Moq;
using NUnit.Framework;

namespace MgMateWebTests.ControllerTests
{
    [TestFixture]
    public class AccompanyingSymptomsControllerTests
    {
        #region Fields and constants

        private Mock<IUnitOfWork> _fakeUnitOfWork;
        private Mock<ICustomMapper> _fakeCustomMapper;

        AccompanyingSymptomsController _accompanyingSymptomsController;


        #endregion

        [SetUp]
        public void Init()
        {
            _fakeUnitOfWork = new Mock<IUnitOfWork>();
            _fakeCustomMapper = new Mock<ICustomMapper>();

            _accompanyingSymptomsController =
                new AccompanyingSymptomsController(
                    _fakeUnitOfWork.Object, 
                    _fakeCustomMapper.Object);

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
                        _fakeCustomMapper.Object);
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