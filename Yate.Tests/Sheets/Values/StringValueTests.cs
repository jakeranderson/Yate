using Moq;
using NUnit.Framework;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class StringValueTests
    {
        [Test]
        public void DoesItWork()
        {
            var value = new StringValue("hi");
            Assert.AreEqual("hi", value.GetValue(new Mock<IYateDataContext>().Object));
            Assert.IsInstanceOf<string>(value.GetValue(new Mock<IYateDataContext>().Object));

            value = new StringValue(null);
            Assert.AreEqual(null, value.GetValue(new Mock<IYateDataContext>().Object));
        }
    }
}