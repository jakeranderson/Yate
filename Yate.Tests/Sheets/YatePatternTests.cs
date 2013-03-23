using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsQuery;
using NUnit.Framework;
using Yate.Sheets;

namespace Yate.Tests.Sheets
{
    [TestFixture]
    public class YatePatternTests
    {
        [Test]
        public void ConstructorThrowsErrorWhenNullIsPassedIn()
        {
            Assert.Throws<ArgumentNullException>(() => new YatePattern(null));
            Assert.Throws<ArgumentNullException>(() => new YatePattern(null, null, null));
        }

        [Test]
        public void ConstructorCreatesRuleListsWhenNothingOrNullIsPassedIn()
        {
            var pattern = new YatePattern(CQ.Create(Helpers.EmptyHtmlString));

            Assert.IsNotNull(pattern.AtRules);
            Assert.IsNotNull(pattern.RuleSets);
            Assert.IsNotNull(pattern.HtmlFragment);

            pattern = new YatePattern(CQ.Create(Helpers.EmptyHtmlString), null, null);

            Assert.IsNotNull(pattern.AtRules);
            Assert.IsNotNull(pattern.RuleSets);
            Assert.IsNotNull(pattern.HtmlFragment);
        }

        [Test]
        public void ConstructorSetsPropertiesProperly()
        {
            var html = CQ.Create(Helpers.EmptyHtmlString);
            var atRules = new List<IAtRule>();
            var ruleSets = new List<RuleSet>();

            var pattern = new YatePattern(html, atRules, ruleSets);

            Assert.AreEqual(html, pattern.HtmlFragment);
            Assert.AreEqual(atRules, pattern.AtRules);
            Assert.AreEqual(ruleSets, pattern.RuleSets);
        }
    }
}
