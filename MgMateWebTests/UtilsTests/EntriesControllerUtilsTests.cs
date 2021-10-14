using System;
using System.Threading.Tasks;
using MgMateWeb.Interfaces.PersistenceInterfaces;
using MgMateWeb.Models.EntryModels;
using MgMateWeb.Utils;
using Microsoft.Data.SqlClient;
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


        #region EntriesControllerUtils > SaveEntryToDbAsync

        [Test]
        public void SaveEntryToDbAsync_ParameterEntryIsNull_ReturnsFalse()
        {
            var result = _entriesControllerUtils.SaveEntryToDbAsync(null);

            Assert.IsFalse(result.Result);
        }

        [Test]
        public void SaveEntryToDatabase_CannotSaveEntryToDatabase_ThrowsSqlException()
        {
            var testEntry = new Entry
            {
                CreationDate = DateTime.Now,
                HoursOfActivity = 4
            };

            _fakeUnitOfWork.Setup(fuow => fuow
                .Entries
                .AddAsync(testEntry))
                .Throws(MakeSqlException());

            var result = _entriesControllerUtils
                .SaveEntryToDbAsync(testEntry);

            Assert.IsFalse(result.Result);

        }

        [Test]
        public void SaveEntryToDatabase_SavingEntryToDatabaseSuccessful_ReturnsTrue()
        {
            var testEntry = new Entry
            {
                CreationDate = DateTime.Now,
                HoursOfActivity = 4
            };

            _fakeUnitOfWork.Setup(fuow => fuow.Entries
                .AddAsync(testEntry))
                .Returns(() => Task.CompletedTask);

            _fakeUnitOfWork.Setup(fuow => fuow
                .CompleteAsync())
                .Returns(Task.FromResult(1));

            var result = _entriesControllerUtils
                .SaveEntryToDbAsync(testEntry);

            Assert.IsTrue(result.Result);

        }

        #endregion

        #region EntriesControllerUtils > FindAccompanyingSymptomById

        [Test]
        [TestCase(0, TestName = "Selected id for symptom is 0.")]
        [TestCase(-1, TestName = "Selected id for symptom is out of range (-1).")]
        public void FindAccompanyingSymptomById_SelectedIdIsNullOrOutOfRange_ReturnsNewAccompanyingSymptom(int faultySymptomId)
        {
            var minDate = DateTime.MinValue;

            var result = _entriesControllerUtils
                .FindAccompanyingSymptomById(faultySymptomId);

            Assert.AreEqual(minDate, result.Result.CreationDate);
        }

        [Test]
        public void FindAccompanyingSymptomById_SelectedIdNotFoundInDatabase_ReturnsNull()
        {
            const int testId = 42;
            AccompanyingSymptom nullSymptom = null;
            var minDate = DateTime.MinValue;


            _fakeUnitOfWork.Setup(fuow => fuow.AccompanyingSymptoms
                .GetAsync(testId))
                .Returns(Task.FromResult(nullSymptom));

            var result = _entriesControllerUtils
                .FindAccompanyingSymptomById(testId);

            Assert.AreEqual(minDate, result.Result.CreationDate);

        }

        [Test]
        public void FindAccompanyingSymptomById_SelectedIdFoundInDatabase_ReturnsObjectIdentifiedByPassedId()
        {
            const int testId = 42;

            var testAccompanyingSymptom = new AccompanyingSymptom
            {
                Description = "This is test symptom 42",
                Id = testId,
            };

            _fakeUnitOfWork.Setup(fuow => fuow.AccompanyingSymptoms
                .GetAsync(testId))
                .Returns(Task.FromResult(testAccompanyingSymptom));

            var result = _entriesControllerUtils.FindAccompanyingSymptomById(testId);

            Assert.AreEqual(testAccompanyingSymptom.Description, result.Result.Description);

        }

        #endregion

        #region Helper methods
        /// <summary>
        /// The following code will create a new SqlException.
        /// For more details, go to https://bit.ly/3aArk2q
        /// </summary>
        /// <returns>New SQL Exception</returns>
        public SqlException MakeSqlException()
        {
            SqlException exception = null;
            var conn = new SqlConnection(@"Data Source=.;Database=GUARANTEED_TO_FAIL;Connection Timeout=1");
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                exception = ex;
            }
            return (exception);
        }

        #endregion
    }
}