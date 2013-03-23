using System;
using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class AttributePropertyBuilderTests
    {
        [Test]
        public void FailBuildingTest()
        {
            var builder = new AttributePropertyBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.Build(null));
            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue> { new StringValue("foo") }));
        }

        [Test]
        public void BuildBasicTest()
        {
            var builder = new AttributePropertyBuilder();

            var property = builder.Build(new List<IValue> { new StringValue("foo"), new StringValue("bar") });

            Assert.IsNotNull(property);
            Assert.IsInstanceOf<AttributeProperty>(property);
        }
    }
}