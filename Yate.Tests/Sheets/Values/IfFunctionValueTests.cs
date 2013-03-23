using System;
using Moq;
using NUnit.Framework;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class IfFunctionValueTests
    {
        [Test]
        public void NullCunstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new IfFunctionValue(new TrueFunctionValue(), null));
            Assert.Throws<ArgumentNullException>(() => new IfFunctionValue(new TrueFunctionValue(), null, null));

            Assert.Throws<ArgumentNullException>(() => new IfFunctionValue(null, new TrueFunctionValue()));
            Assert.Throws<ArgumentNullException>(() => new IfFunctionValue(null, new TrueFunctionValue(), null));


            Assert.DoesNotThrow(() => new IfFunctionValue(new TrueFunctionValue(), new TrueFunctionValue()));
            Assert.DoesNotThrow(() => new IfFunctionValue(new TrueFunctionValue(), new TrueFunctionValue(), null));
        }

        [Test]
        public void ConditionalParamIsNotBoolTest()
        {
            var value = new IfFunctionValue(new StringValue("What happens here buddy?"), new TrueFunctionValue(), new FalseFunctionValue());

            Assert.Throws<InvalidCastException>(() => value.GetValue(new Mock<IYateDataContext>().Object));
        }

        [Test]
        public void TrueStatementsTests()
        {
            var value = new IfFunctionValue(new TrueFunctionValue(), new StringValue("yup"), new StringValue("nope"));

            Assert.AreEqual("yup", value.GetValue(new Mock<IYateDataContext>().Object));
        }

        [Test]
        public void FalseStatementsTests()
        {
            var value = new IfFunctionValue(new FalseFunctionValue(), new StringValue("yup"), new StringValue("nope"));

            Assert.AreEqual("nope", value.GetValue(new Mock<IYateDataContext>().Object));
        }

        [Test]
        public void DefaultFalseStatementsTests()
        {
            var value = new IfFunctionValue(new FalseFunctionValue(), new StringValue("yup"));

            Assert.AreEqual("", value.GetValue(new Mock<IYateDataContext>().Object));
        }
    }
}