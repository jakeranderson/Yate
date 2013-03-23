using System;
using CsQuery;
using Moq;
using NUnit.Framework;
using Yate.Parsing;
using Yate.Sheets;

namespace Yate.Tests.Parsing
{
    [TestFixture]
    public class ParsedViewTests
    {
        private const string EmptyHtmlString = "<html><head></head><body></body></html>";

        [Test]
        public void ConstrutorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new ParsedView(null));

            var view = new ParsedView(CQ.Create());

            Assert.IsNotNull(view);
            Assert.IsNotNull(view.RuleSets);
            Assert.IsNotNull(view.Html);
        }

        [Test]
        public void EmptyRendorTests()
        {
            var view = new ParsedView(CQ.Create(EmptyHtmlString));

            Assert.AreEqual(EmptyHtmlString, view.Render(new Mock<IYateDataContext>().Object));
        }

        [Test]
        public void FirstRenderDoesntMessWithSecondRender()
        {
            var damangingRuleSetMock = new Mock<RuleSet>();
            damangingRuleSetMock.Setup(d => d.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()))
                .Callback((CQ html, IYateDataContext data) => html.Select("body").Text("hi"));



            var view = new ParsedView(CQ.Create(EmptyHtmlString));
            view.RuleSets.Add(damangingRuleSetMock.Object);

            Assert.AreEqual("<html><head></head><body>hi</body></html>", view.Render(new Mock<IYateDataContext>().Object));

            view.RuleSets.Clear();
            Assert.AreEqual(EmptyHtmlString, view.Render(new Mock<IYateDataContext>().Object));

        }
    }
}
