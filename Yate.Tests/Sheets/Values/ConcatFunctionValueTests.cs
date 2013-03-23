using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class ConcatFunctionValueTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new ConcatFunctionValue(null));
            Assert.DoesNotThrow(() => new ConcatFunctionValue(new List<IValue>()));
        }

        [Test]
        public void GetValueTest()
        {
            var value = new ConcatFunctionValue(new List<IValue> { new StringValue("Hello"), new StringValue("World!") });
            var theString = value.GetValue(new Mock<IYateDataContext>().Object);

            Assert.AreEqual("HelloWorld!", theString);
        }

        [Test]
        public void GetValueNoneTest()
        {
            var value = new ConcatFunctionValue(new List<IValue>());
            var theString = value.GetValue(new Mock<IYateDataContext>().Object);

            Assert.AreEqual("", theString);
        }
    }
}
