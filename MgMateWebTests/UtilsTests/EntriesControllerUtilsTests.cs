using System;
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

        Mock<IUnitOfWork> _fakeUnitOfWork;
        EntriesControllerUtils _entriesControllerUtils;

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

        #region MyRegion

        [Test]
        public void EntryExist_ParameterIdIsNull_ReturnsFalse()
        {
            var result = _entriesControllerUtils.EntryExists(0);

            Assert.IsFalse(result.Result);
        }


        #endregion

        //public async Task<bool> EntryExists(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return false;
        //    }

        //    return await _unitOfWork
        //        .Entries
        //        .CheckIfAnyAsync(e => e.Id == id)
        //        .ConfigureAwait(false);
        //}
    }
}