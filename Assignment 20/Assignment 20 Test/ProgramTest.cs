using Moq;
using NUnit.Framework;
using Assignment_20;

namespace Assignment_20_Test
{
    [TestFixture]
    public class QueryTest
    {
        Query _query;

        [SetUp]
        public void Setup()
        {
            var _contextMock = new Mock<Context>();
            _contextMock.Setup(m => m.GetResult(It.IsAny<int>())).Returns(new Result("Data retreived successfully"));

            _query = new Query(_contextMock.Object);
        }

        [TestCase(-17, AccessLevel.Outer, "Wrong Address format")]
        [TestCase(0, AccessLevel.Outer, "Wrong Address format")]
        public void WhenAddress_LessOrEqualToZero_GetWrongAddress(int value, AccessLevel al, string expected)
        {
            _query.Address = value;
            _query.AccessLevel = al;
            Result result = _query.Execute();

            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void WhenAccessLevel_LessThenZero_GetWrongAccessLevel()
        {
            _query.Address = 5;
            _query.AccessLevel = (AccessLevel) (-2);
            Result result = _query.Execute();

            Assert.AreEqual("Wrong Access Level format", result.Value);
        }

        [TestCase(600, AccessLevel.Outer, "Do not have required Access Level")]
        [TestCase(600, AccessLevel.Inner, "Data retreived successfully")]
        [TestCase(1300, AccessLevel.Inner, "Do not have required Access Level")]
        [TestCase(1300, AccessLevel.Admin, "Data retreived successfully")]
        public void WhenAccessLevel_TooLow_GetNotEnoughAccessLevel(int value, AccessLevel al, string expected)
        {
            _query.Address = value;
            _query.AccessLevel = al;
            Result result = _query.Execute();

            Assert.AreEqual(expected, result.Value);
        }
    }

    [TestFixture]
    public class ContextTest
    {
        Context _context;

        [SetUp]
        public void Setup()
        {
            _context = new Context();
        }

        [TestCase(-1, "No Result for this Address: -1")]
        [TestCase(3000, "No Result for this Address: 3000")]
        public void WhenAddress_NotPresentedInMemory_GetNoResult(int address, string expected)
        {
            Result res = _context.GetResult(address);

            Assert.AreEqual(expected, res.Value);
        }


        [TestCase(350, "Outer Access Data")]
        [TestCase(730, "Inner Access Data")]
        [TestCase(1500, "Only Admin Access Data")]
        public void WhenAddress_IsMatching_GetResult(int address, string expected)
        {
            Result res = _context.GetResult(address);

            Assert.AreEqual(expected, res.Value);
        }
    }
}