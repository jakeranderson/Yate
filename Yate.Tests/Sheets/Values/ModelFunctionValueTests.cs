using System;
using Moq;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class ModelFunctionValueTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new ModelFunctionValue(null));

            var value = new ModelFunctionValue(new StringValue("*"));

            Assert.IsNotNull(value);
        }

        [Test]
        public void GetValueCallsDataContext()
        {
            var dataContextMock = new Mock<IYateDataContext>();
            var valueMock = new Mock<IValue>();

            valueMock.Setup(dc => dc.GetValue(It.IsAny<IYateDataContext>())).Returns("*");

            var modelFunction = new ModelFunctionValue(valueMock.Object);

            modelFunction.GetValue(dataContextMock.Object);

            dataContextMock.Verify(dc => dc.GetValue(It.IsAny<string>()), Times.Once());
        }
    }
}