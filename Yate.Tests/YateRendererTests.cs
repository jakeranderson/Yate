using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CsQuery;
using Moq;
using NUnit.Framework;
using Yate.Parsing;

namespace Yate.Tests
{
    [TestFixture]
    public class YateRendererTests
    {
        [Test]
        public void ConstructorTests()
        {

            var builder = new Mock<IViewBuilder>();

            var renderer = new YateRenderer(builder.Object);
            Assert.IsNotNull(renderer);

            Assert.Throws<ArgumentNullException>(() => new YateRenderer(null));

            renderer = new YateRenderer();
            Assert.IsNotNull(renderer);
        }

        [Test]
        public void RenderToString()
        {
            var parsedViewMock = new Mock<IParsedView>();
            var dataMock = new Mock<IYateDataContext>().Object;
            parsedViewMock.Setup(pv => pv.Render(dataMock))
                          .Returns(() => Helpers.EmptyHtmlString);

            parsedViewMock.Setup(pv => pv.WriteToTextWriter(It.IsAny<TextWriter>(), It.IsAny<IYateDataContext>()))
                          .Callback((TextWriter tw, IYateDataContext data) => tw.Write(Helpers.EmptyHtmlString));

            var builder = new Mock<IViewBuilder>();
            builder.Setup(b => b.Build(It.IsAny<string>())).Returns(parsedViewMock.Object);

            var renderer = new YateRenderer(builder.Object);

            var str = renderer.Render("", dataMock);

            Assert.AreEqual(Helpers.EmptyHtmlString, str);
        }

        [Test]
        public void RenderToTextWriter()
        {
            var builder = new Mock<IViewBuilder>();
            var parsedViewMock = new Mock<IParsedView>();
            parsedViewMock.Setup(pv => pv.WriteToTextWriter(It.IsAny<TextWriter>(), It.IsAny<IYateDataContext>()))
                        .Callback((TextWriter tw,IYateDataContext data) => tw.Write(Helpers.EmptyHtmlString));

            builder.Setup(b => b.Build(It.IsAny<string>())).Returns(parsedViewMock.Object);

            var renderer = new YateRenderer(builder.Object);

            using (var stringWriter = new StringWriter())
            {
                renderer.WriteToTextWriter("", stringWriter, new Mock<IYateDataContext>().Object);

                Assert.AreEqual(Helpers.EmptyHtmlString, stringWriter.ToString());
            }
        }
    }
}
