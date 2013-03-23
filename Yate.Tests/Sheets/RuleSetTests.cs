using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsQuery;
using Moq;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Properties;

namespace Yate.Tests.Sheets
{
    [TestFixture]
    public class RuleSetTests
    {
        [Test]
        public void ConstructorTests()
        {
            var ruleSet = new RuleSet();

            Assert.IsNotNull(ruleSet);
            Assert.IsNotNull(ruleSet.Selectors);
            Assert.IsNotNull(ruleSet.Properties);

            ruleSet = new RuleSet(null);

            Assert.IsNotNull(ruleSet);
            Assert.IsNotNull(ruleSet.Selectors);
            Assert.IsNotNull(ruleSet.Properties);

            ruleSet = new RuleSet(null, null);

            Assert.IsNotNull(ruleSet);
            Assert.IsNotNull(ruleSet.Selectors);
            Assert.IsNotNull(ruleSet.Properties);

            var selectors = new List<string> { "test" };
            var props = new List<IProperty>();

            ruleSet = new RuleSet(selectors, props);

            Assert.IsNotNull(ruleSet);
            Assert.IsNotNull(ruleSet.Selectors);
            Assert.IsNotNull(ruleSet.Properties);

            Assert.AreSame(selectors, ruleSet.Selectors);
            Assert.AreSame(props, ruleSet.Properties);

            Assert.AreEqual(selectors[0], ruleSet.Selectors[0]);
        }

        [Test]
        public void BasicRenderTest()
        {
            var propMock = new Mock<IProperty>();
            var htmlMock = new Mock<CsQuery.CQ>();

            var ruleSet = new RuleSet(new List<string> { "hey buddy", "hello world" },
                                      new List<IProperty> { propMock.Object });

            ruleSet.Render(htmlMock.Object, new Mock<IYateDataContext>().Object);

            propMock.Verify(p => p.Render(It.IsAny<CQ>(), It.IsAny<string>(),It.IsAny<IYateDataContext>()), Times.Exactly(2));

        }

        [Test]
        public void BasicRenderTestTwo()
        {
            var propMock = new Mock<IProperty>();
            var htmlMock = new Mock<CsQuery.CQ>();

            var ruleSet = new RuleSet(new List<string> { "hey buddy" },
                                      new List<IProperty> { propMock.Object });

            ruleSet.Render(htmlMock.Object, new Mock<IYateDataContext>().Object);

            propMock.Verify(p => p.Render(It.IsAny<CQ>(), It.Is<string>(s => s == "hey buddy"),It.IsAny<IYateDataContext>()), Times.Once());

        }
    }
}
