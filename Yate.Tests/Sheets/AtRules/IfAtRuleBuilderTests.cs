using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.AtRules;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.AtRules
{
    [TestFixture]
    public class IfAtRuleBuilderTests
    {
        [Test]
        public void IfBuilderThrowsExpectionsWhenBadDataIsPassedIn()
        {
            var ifBuilder = new IfAtRuleBuilder();

            Assert.Throws<ArgumentNullException>(() => ifBuilder.Build(null));

            Assert.Throws<ArgumentException>(() => ifBuilder.Build(new List<IValue>()));
        }

        [Test]
        public void IfBuilderActuallyBuildsSomething()
        {
            var ifBuilder = new IfAtRuleBuilder();

            var ifResult = ifBuilder.Build(new List<IValue> { new StringValue("on noes") });

            Assert.IsInstanceOf<IfAtRule>(ifResult);
        }
    }
}
