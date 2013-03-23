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
    public class HtmlPropertyTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new HtmlProperty(null));

            Assert.DoesNotThrow(() => new HtmlProperty(new StringValue("hey buddy!")));
        }

        [Test]
        public void BasicRenderingTest()
        {
            var textRule = new HtmlProperty(new StringValue(@"<p>passed</p>"));
            var html = CsQuery.CQ.Create(@"<html></html>");

            textRule.Render(html, "html", new Mock<IYateDataContext>().Object);

            Assert.AreEqual(@"<html><p>passed</p></html>", html.Render());
        }
    }
}