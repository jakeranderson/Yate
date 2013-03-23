using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class AttributePropertyTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new AttributeProperty(null, null));
            Assert.Throws<ArgumentNullException>(() => new AttributeProperty(new StringValue("foo"), null));
            Assert.Throws<ArgumentNullException>(() => new AttributeProperty(null, new StringValue("foo")));

            Assert.DoesNotThrow(() => new AttributeProperty(new StringValue("foo"), new StringValue("foo")));
        }

        [Test]
        public void BasicRenderingTest()
        {
            var rule = new AttributeProperty(new StringValue("passed"), new StringValue("true"));
            var html = CsQuery.CQ.Create(@"<html passed=""false""><head></head><body></body></html>");

            rule.Render(html, "html", new Mock<IYateDataContext>().Object);

            Assert.AreEqual(@"<html passed=""true""><head></head><body></body></html>", html.Render());
        }
    }
}