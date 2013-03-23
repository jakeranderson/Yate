using System;
using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class ApplyPatternPropertyBuilderTests
    {
        [Test]
        public void BuilderThrowsErrorWhenYouGiveItNotEnoughData()
        {
            var builder = new ApplyPatternPropertyBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.Build(null));
            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue>()));
            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue> { new StringValue("") }));
        }

        [Test]
        public void BuilderBuildsCorrectProperty()
        {
            var builder = new ApplyPatternPropertyBuilder();

            var result = builder.Build(new List<IValue> { new StringValue(""), new StringValue("") });

            Assert.IsInstanceOf<ApplyPatternProperty>(result);
        }
    }
}