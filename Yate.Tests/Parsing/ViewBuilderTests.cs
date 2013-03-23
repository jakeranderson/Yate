using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsQuery;
using Moq;
using NUnit.Framework;
using Yate.Parsing;
using Yate.Sheets;
using Yate.Sheets.Properties;

namespace Yate.Tests.Parsing
{
    [TestFixture]
    public class ViewBuilderTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new ViewBuilder(null));

            var fetcherMock = new Mock<IFileFetcher>();

            var viewBuilder = new ViewBuilder(fetcherMock.Object);

            Assert.IsNotNull(viewBuilder);
        }

        [Test]
        public void AddValueBuilderErrosTests()
        {
            //todo: test this actually got added
            var fetcherMock = new Mock<IFileFetcher>();
            var functionValueBuilderMock = new Mock<IFunctionValueBuilder<IFunctionValue>>();

            var viewBuilder = new ViewBuilder(fetcherMock.Object);

            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddValueBuilder(null, null));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddValueBuilder("", null));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddValueBuilder("", functionValueBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddValueBuilder("hi", null));

            Assert.DoesNotThrow(() => viewBuilder.AddValueBuilder("yo", functionValueBuilderMock.Object));
        }

        [Test]
        public void AddPropertyBuilderErrosTests()
        {
            //todo: test this actually got added
            var fetcherMock = new Mock<IFileFetcher>();
            var propertyBuilderMock = new Mock<IPropertyBuilder<IProperty>>();

            var viewBuilder = new ViewBuilder(fetcherMock.Object);

            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddPropertyBuilder(null, null));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddPropertyBuilder("", null));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddPropertyBuilder("", propertyBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddPropertyBuilder("hi", null));

            Assert.DoesNotThrow(() => viewBuilder.AddPropertyBuilder("yo", propertyBuilderMock.Object));
        }

        [Test]
        public void AddAtRuleBuilderErrosTests()
        {
            //todo: test this actually got added
            var fetcherMock = new Mock<IFileFetcher>();
            var propertyBuilderMock = new Mock<IAtRuleBuilder<IAtRule>>();

            var viewBuilder = new ViewBuilder(fetcherMock.Object);

            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddAtRuleBuilder(null, null));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddAtRuleBuilder("", null));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddAtRuleBuilder("", propertyBuilderMock.Object));
            Assert.Throws<ArgumentNullException>(() => viewBuilder.AddAtRuleBuilder("hi", null));

            Assert.DoesNotThrow(() => viewBuilder.AddAtRuleBuilder("yo", propertyBuilderMock.Object));
        }

        [Test]
        public void BasicBuildTest()
        {
            var fileFetcherMock = new Mock<IFileFetcher>();

            fileFetcherMock.Setup(ff => ff.GetText(It.IsAny<string>())).Returns(Helpers.EmptyHtmlString);

            var builder = new ViewBuilder(fileFetcherMock.Object);

            var view = builder.Build("yeah buddy");

            Assert.IsNotNull(view);
        }

        [Test]
        public void BuildNoFilePathGiven()
        {
            var fileFetcherMock = new Mock<IFileFetcher>();
            var builder = new ViewBuilder(fileFetcherMock.Object);

            Assert.Throws<ArgumentNullException>(() => builder.Build(""));
            Assert.Throws<ArgumentNullException>(() => builder.Build(null));
        }

        [Test]
        public void GrabYateScriptFromTemplate()
        {
            var fileFetcherMock = new Mock<IFileFetcher>();

            fileFetcherMock.Setup(ff => ff.GetText(It.IsAny<string>()))
                .Returns(@"<html><head><script type=""text/yate"">body{text:hi;}</script></head><body></body></html>");

            var builder = new ViewBuilder(fileFetcherMock.Object);

            var htmls = builder.Build("asdf").Render(new Mock<IYateDataContext>().Object);

            fileFetcherMock.Verify(ff => ff.GetText(It.IsAny<string>()), Times.Once());

            Assert.AreEqual(@"<html><head></head><body>hi</body></html>", htmls);
        }

        [Test]
        public void GrabYateScriptFromOutsideSource()
        {
            var fileFetcherMock = new Mock<IFileFetcher>();

            fileFetcherMock.Setup(ff => ff.GetText(It.Is<string>(s => s == "template")))
                .Returns(@"<html><head><script type=""text/yate"" src=""script.yate""></script></head><body></body></html>");

            fileFetcherMock.Setup(ff => ff.GetText(It.Is<string>(s => s == "script.yate")))
               .Returns(@"body{text:hi;}");

            var builder = new ViewBuilder(fileFetcherMock.Object);

            var htmls = builder.Build("template").Render(new Mock<IYateDataContext>().Object);

            fileFetcherMock.Verify(ff => ff.GetText(It.Is<string>(s => s == "template")), Times.Once());
            fileFetcherMock.Verify(ff => ff.GetText(It.Is<string>(s => s == "script.yate")), Times.Once());

            Assert.AreEqual(@"<html><head></head><body>hi</body></html>", htmls);
        }

        [Test]
        public void DoesItUseFunctionValues()
        {
            var fileFetcherMock = new Mock<IFileFetcher>();

            fileFetcherMock.Setup(ff => ff.GetText(It.IsAny<string>()))
                .Returns(@"<html><head><script type=""text/yate"">body{text:if(false(),nope,yup);}</script></head><body></body></html>");

            var builder = new ViewBuilder(fileFetcherMock.Object);

            var htmls = builder.Build("asdf").Render(new Mock<IYateDataContext>().Object);

            Assert.AreEqual(@"<html><head></head><body>yup</body></html>", htmls);
        }

        [Test]
        public void AtRules()
        {
            var fileFetcherMock = new Mock<IFileFetcher>();

            fileFetcherMock.Setup(ff => ff.GetText(It.IsAny<string>()))
                .Returns(@"<html><head><script type=""text/yate"">@if true(){body{text:hi}}</script></head><body></body></html>");

            var builder = new ViewBuilder(fileFetcherMock.Object);

            var htmls = builder.Build("asdf").Render(new Mock<IYateDataContext>().Object);

        }
    }
}
