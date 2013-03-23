using System;
using Moq;
using NUnit.Framework;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class FormatTextPropertyTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new FormatTextProperty(null));

            Assert.DoesNotThrow(() => new FormatTextProperty(new StringValue("yup")));
            Assert.DoesNotThrow(() => new FormatTextProperty(new StringValue("yup"), new StringValue("buddy")));
        }

        [Test]
        public void NoFormatGivenTest()
        {
            var rule = new FormatTextProperty(new ModelFunctionValue(new StringValue("foo")));
            var html = CsQuery.CQ.Create(@"<html>${0:###.##}</html>");
            var contextMock = new Mock<IYateDataContext>();
            contextMock.Setup(c => c.GetValue(It.IsAny<string>()))
                .Returns(19.95);


            rule.Render(html, "html", contextMock.Object);

            Assert.AreEqual("<html>$19.95</html>", html.Render());
        }

        [Test]
        public void FormatGivenTest()
        {
            var rule = new FormatTextProperty(new ModelFunctionValue(new StringValue("foo")), new StringValue("${0:###.##}"));
            var html = CsQuery.CQ.Create(@"<html>$10000.00</html>");
            var contextMock = new Mock<IYateDataContext>();
            contextMock.Setup(c => c.GetValue(It.IsAny<string>()))
                .Returns(19.95);


            rule.Render(html, "html", contextMock.Object);

            Assert.AreEqual("<html>$19.95</html>", html.Render());
        }
    }
}