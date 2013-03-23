using System;
using CsQuery;
using Moq;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.AtRules;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.AtRules
{
    [TestFixture]
    public class IfAtRuleTests
    {
        [Test]
        public void IfRuleThrowsExceptionsWhenYouGiveItBadData()
        {
            Assert.Throws<ArgumentNullException>(() => new IfAtRule(null));
        }

        [Test]
        public void IfRuleDoesntDoAnythingIfItHasFalseCondition()
        {
            var rule = new IfAtRule(new FalseFunctionValue());
            var dataMock = new Mock<IYateDataContext>();

            var atRuleMockOne = new Mock<IAtRule>();
            var atRuleMockTwo = new Mock<IAtRule>();
            var ruleSetMockOne = new Mock<RuleSet>();
            var ruleSetMockTwo = new Mock<RuleSet>();

            rule.AtRules.Add(atRuleMockOne.Object);
            rule.AtRules.Add(atRuleMockTwo.Object);

            rule.RuleSets.Add(ruleSetMockOne.Object);
            rule.RuleSets.Add(ruleSetMockTwo.Object);


            rule.Render(CQ.Create(Helpers.EmptyHtmlString), dataMock.Object);

            atRuleMockOne.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Never());
            atRuleMockTwo.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Never());
            ruleSetMockOne.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Never());
            ruleSetMockTwo.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Never());
        }

        [Test]
        public void IfRuleCallsRenderOnItsSubRulesWhenItHasTrueCondition()
        {
            var rule = new IfAtRule(new TrueFunctionValue());
            var dataMock = new Mock<IYateDataContext>();

            var atRuleMockOne = new Mock<IAtRule>();
            var atRuleMockTwo = new Mock<IAtRule>();
            var ruleSetMockOne = new Mock<RuleSet>();
            var ruleSetMockTwo = new Mock<RuleSet>();

            rule.AtRules.Add(atRuleMockOne.Object);
            rule.AtRules.Add(atRuleMockTwo.Object);

            rule.RuleSets.Add(ruleSetMockOne.Object);
            rule.RuleSets.Add(ruleSetMockTwo.Object);


            rule.Render(CQ.Create(Helpers.EmptyHtmlString), dataMock.Object);

            atRuleMockOne.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Once());
            atRuleMockTwo.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Once());
            ruleSetMockOne.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Once());
            ruleSetMockTwo.Verify(r => r.Render(It.IsAny<CQ>(), It.IsAny<IYateDataContext>()), Times.Once());
        }
    }
}