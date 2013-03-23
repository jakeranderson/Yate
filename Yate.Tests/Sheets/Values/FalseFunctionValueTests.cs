using Moq;
using NUnit.Framework;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class FalseFunctionValueTests
    {
        [Test]
        public void DoesItWork()
        {
            var value = new FalseFunctionValue();

            Assert.AreEqual(false, value.GetValue(new Mock<IYateDataContext>().Object));
        }
    }
}