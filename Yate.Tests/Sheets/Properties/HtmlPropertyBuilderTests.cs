using System;
using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class HtmlPropertyBuilderTests
    {
        [Test]
        public void BuilderFailures()
        {
            var builder = new HtmlPropertyBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.Build(null));
            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue>()));
        }

        [Test]
        public void BuildBasicTest()
        {
            var builder = new HtmlPropertyBuilder();

            var property = builder.Build(new List<IValue>{new StringValue("something")});

            Assert.IsNotNull(property);
            Assert.IsInstanceOf<HtmlProperty>(property);
        }
    }
}