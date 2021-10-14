using System;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Utils;
using Moq;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests
{
    [TestFixture]
    public class EntriesControllerUtilsTests
    {
        #region Fields and Constants

        private Mock<IUnitOfWork> _fakeUnitOfWork;
        private EntriesControllerUtils _entriesControllerUtils;

        #endregion

        [SetUp]
        public void Init()
        {
            _fakeUnitOfWork = new Mock<IUnitOfWork>();
            _entriesControllerUtils = new EntriesControllerUtils(_fakeUnitOfWork.Object);

        }

        #region Testing EntriesControllerUtils > Constructor(s)

        [Test]
        public void EntriesControllerUtilsConstructor_ParameterUnitOfWorkIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var unused = new EntriesControllerUtils(null);
            });
        }

        #endregion

        #region Testing EntriesControllerUtils > EntryExistsAsync

        [Test]
        [TestCase(0, TestName = "Parameter 'id' is 0")]
        [TestCase(-1, TestName = "Parameter 'id' is -1")]
        public void EntryExists_ParameterIdIsNullOrOutOfRange_ReturnsFalse(int faultyId)
        {
            var result = _entriesControllerUtils.EntryExistsAsync(faultyId);

            Assert.IsFalse(result.Result);
        }

        [Test]
        public void EntryExistsAsync_ParameterIdIsValidId_ReturnsTrue()
        {
            const int testId = 42;


            _fakeUnitOfWork.Setup(fuow => fuow.Entries
                .CheckIfAnyAsync(entry => entry.Id == testId))
                .Returns(Task.FromResult(true));

            var result = _entriesControllerUtils.EntryExistsAsync(testId);

            Assert.IsTrue(result.Result);
        }

        #endregion
    }
}