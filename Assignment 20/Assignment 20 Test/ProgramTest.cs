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

        [TestCase(-17, "Wrong Address format")]
        [TestCase(0, "Wrong Address format")]
        public void WhenAddress_LessOrEqualToZero_GetWrongAddress(int value, string expected)
        {
            _query.Address = value;
            Result result = _query.Execute();

            Assert.AreEqual(expected, result.Value);
        }

        [Test]
        public void WhenAddress_MoreThanZero_GetPositiveAnswer()
        {
            _query.Address = 12;
            Result result = _query.Execute();

            Assert.AreEqual("Data retreived successfully", result.Value);
        }
    }
}