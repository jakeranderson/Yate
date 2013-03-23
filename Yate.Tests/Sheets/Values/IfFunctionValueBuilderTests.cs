using System;
using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class IfFunctionValueBuilderTests
    {
        [Test]
        public void NullValueTest()
        {
            var builder = new IfFunctionValueBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.Build(null));
        }

        [Test]
        public void TooFewValuesTest()
        {
            var builder = new IfFunctionValueBuilder();

            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue>()));
            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue> { new StringValue("") }));
        }

        [Test]
        public void TwoValuesTest()
        {
            var builder = new IfFunctionValueBuilder();

            var value = builder.Build(new List<IValue> { new TrueFunctionValue(), new StringValue("yup") });

            Assert.IsNotNull(value);
            Assert.IsInstanceOf<IfFunctionValue>(value);
        }

        [Test]
        public void ThreePlusValuesTest()
        {
            var builder = new IfFunctionValueBuilder();

            var value = builder.Build(new List<IValue> { new TrueFunctionValue(), new StringValue("yup"), new StringValue("nope"), new StringValue("never used") });

            Assert.IsNotNull(value);
            Assert.IsInstanceOf<IfFunctionValue>(value);
        }
    }
}