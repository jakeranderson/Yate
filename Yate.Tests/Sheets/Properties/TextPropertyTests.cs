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
    public class TextPropertyTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new TextProperty(null));

            Assert.DoesNotThrow(() => new TextProperty(new List<IValue>()));
        }

        [Test]
        public void BasicRenderingTest()
        {
            var textRule = new TextProperty(new List<IValue> { new StringValue("passed") });
            var html = CsQuery.CQ.Create(@"<html></html>");

            textRule.Render(html, "html", new Mock<IYateDataContext>().Object);

            Assert.AreEqual("<html>passed</html>", html.Render());
        }
    }
}
