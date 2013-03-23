using System;
using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.AtRules;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.AtRules
{
    [TestFixture]
    public class PatternAtRuleBuilderTests
    {
        [Test]
        public void BuilderThrowsErrorsWhenItDoesntHaveEnoughData()
        {
            var builder = new PatternAtRuleBuilder();

            Assert.Throws<ArgumentNullException>(() => builder.Build(null));
            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue>()));
            Assert.Throws<ArgumentException>(() => builder.Build(new List<IValue> { new StringValue("") }));
        }

        [Test]
        public void BuilderBuildsPattern()
        {
            var builder = new PatternAtRuleBuilder();

            var result = builder.Build(new List<IValue> { new StringValue(""), new StringValue("") });
            
            Assert.IsInstanceOf<PatternAtRule>(result);
        }
    }
}