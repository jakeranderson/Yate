using Moq;
using NUnit.Framework;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class TrueFunctionValueTests
    {
        [Test]
        public void DoesItWork()
        {
            var value = new TrueFunctionValue();

            Assert.AreEqual(true, value.GetValue(new Mock<IYateDataContext>().Object));
        }
    }
}