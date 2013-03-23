using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using Yate.Parsing;

namespace Yate.Mvc4.Tests
{
    [TestFixture]
    public class YateViewTests
    {
        [Test]
        public void ConstructorTests()
        {
            Assert.Throws<ArgumentNullException>(() => new YateView(null));

            var parsedViewMock = new Mock<IParsedView>();

            var view = new YateView(parsedViewMock.Object);

            Assert.IsNotNull(view);
        }

        [Test]
        public void RenderExceptionTests()
        {
            var parsedViewMock = new Mock<IParsedView>();
            var view = new YateView(parsedViewMock.Object);

            Assert.Throws<ArgumentNullException>(() => view.Render(null, null));
            Assert.Throws<ArgumentNullException>(() => view.Render(new Mock<ViewContext>().Object, null));
            Assert.Throws<ArgumentNullException>(() => view.Render(null, new Mock<TextWriter>().Object));
        }

        [Test]
        public void RenderCallsParsedViewRenderTest()
        {
            var parsedViewMock = new Mock<IParsedView>();
            var view = new YateView(parsedViewMock.Object);
            var data = new Mock<IYateDataContext>();
            var context = new Mock<ViewContext>();

            context.Setup(c => c.ViewData)
                   .Returns(new ViewDataDictionary());

            view.Render(context.Object, new Mock<TextWriter>().Object);

            parsedViewMock.Verify(pv => pv.WriteToTextWriter(It.IsAny<TextWriter>(), It.IsAny<IYateDataContext>()), Times.Once());
        }
    }
}
