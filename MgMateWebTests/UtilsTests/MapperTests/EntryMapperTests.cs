using MgMateWeb.Utils.Mappers;
using NUnit.Framework;

namespace MgMateWebTests.UtilsTests.MapperTests
{
    [TestFixture]
    public class EntryMapperTests
    {
        #region Fields and constants

        EntryMapper _entryMapper;

        #endregion

        [SetUp]
        public void Init()
        {
            _entryMapper = new EntryMapper();

        }
    }
}