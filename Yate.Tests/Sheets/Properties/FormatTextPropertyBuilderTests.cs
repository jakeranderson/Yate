using System;
using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class FormatTextPropertyBuilderTests
    {
        [Test]
        public void NotEnoughOrWrongValuesTest()
        {

            var builder = new FormatTextPropertyBuilder();

            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue>()));
            Assert.Throws<ArgumentNullException>(() => builder.Build(null));
        }

        [Test]
        public void BuildBasicTest()
        {
            var builder = new FormatTextPropertyBuilder();

            var property = builder.Build(new List<IValue> { new StringValue("foo"), new StringValue("bar") });

            Assert.IsNotNull(property);
            Assert.IsInstanceOf<FormatTextProperty>(property);
        }

        [Test]
        public void BuildWithoutFormatValueTest()
        {
            var builder = new FormatTextPropertyBuilder();

            var property = builder.Build(new List<IValue> { new StringValue("foo") });

            Assert.IsNotNull(property);
            Assert.IsInstanceOf<FormatTextProperty>(property);
        }
    }
}