using System;
using System.Collections.Generic;
using CsQuery;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.AtRules;
using Yate.Sheets.Properties;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class ApplyPatternPropertyTests
    {
        [Test]
        public void ConstructorThrowsErrorsWhenYouGiveItNullData()
        {
            Assert.Throws<ArgumentNullException>(() => new ApplyPatternProperty(null, null));
            Assert.Throws<ArgumentNullException>(() => new ApplyPatternProperty(new StringValue(""), null));
            Assert.Throws<ArgumentNullException>(() => new ApplyPatternProperty(null, new StringValue("")));
        }

        [Test]
        public void RendersWhenModelIsNotCollection()
        {
            var property = new ApplyPatternProperty(new StringValue("name"), new StringValue("model"));

            var html = CQ.Create(Helpers.EmptyHtmlString);
            var context = new YateDataContext(new { not = "used" });
            context.PatternContainer.Add("name", new YatePattern(CQ.CreateFragment(@"<p></p>"),
                                                                 new List<IAtRule> { new IfAtRule(new FalseFunctionValue()) },
                                                                 new List<RuleSet>{
                                                                     new RuleSet(new List<string>{"p"},
                                                                                 new List<IProperty>
                                                                                     {
                                                                                         new TextProperty(new List<IValue>{new ModelFunctionValue(new StringValue("."))})
                                                                                     })}));
            property.Render(html, "body", context);

            Assert.AreEqual(@"<html><head></head><body><p>model</p></body></html>", html.Render());
        }


        [Test]
        public void RendersWhenModelIsCollection()
        {
            var property = new ApplyPatternProperty(new StringValue("name"), new ModelFunctionValue(new StringValue("model")));

            var html = CQ.Create(Helpers.EmptyHtmlString);
            var context = new YateDataContext(new { model = new List<string> { "hello", "world" } });
            context.PatternContainer.Add("name", new YatePattern(CQ.CreateFragment(@"<p></p>"),
                                                                 new List<IAtRule> { new IfAtRule(new FalseFunctionValue()) },
                                                                 new List<RuleSet>{
                                                                     new RuleSet(new List<string>{"p"},
                                                                                 new List<IProperty>
                                                                                     {
                                                                                         new TextProperty(new List<IValue>{new ModelFunctionValue(new StringValue("."))})
                                                                                     })}));
            property.Render(html, "body", context);

            Assert.AreEqual(@"<html><head></head><body><p>hello</p><p>world</p></body></html>", html.Render());
        }
    }
}