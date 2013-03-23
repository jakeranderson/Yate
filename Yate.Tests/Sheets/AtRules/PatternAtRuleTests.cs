using System;
using CsQuery;
using NUnit.Framework;
using Yate.Sheets.AtRules;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.AtRules
{
    [TestFixture]
    public class PatternAtRuleTests
    {
        [Test]
        public void ConstructorsThrowErrorsWhenYouPassItNull()
        {
            Assert.Throws<ArgumentNullException>(() => new PatternAtRule(null, null));
            Assert.Throws<ArgumentNullException>(() => new PatternAtRule(new StringValue("yeah"), null));
            Assert.Throws<ArgumentNullException>(() => new PatternAtRule(null, new StringValue("buddy")));
        }

        [Test]
        public void RenderTests()
        {
            var atRule = new PatternAtRule(new StringValue("name"), new StringValue("selector"));
            var dc = new YateDataContext(new { foo = "bar" });
            atRule.Render(CQ.Create(Helpers.EmptyHtmlString), dc);

            Assert.AreEqual(1, dc.PatternContainer.Count);
        }
    }
}