using System;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using System.Linq;
using Yate.Parsing;

namespace Yate.Mvc4.Tests
{
    [TestFixture]
    public class YateViewEngineTests
    {
        [Test]
        public void EmptyConstructorDoesntBreakTests()
        {
            var engine = new YateViewEngine();

            Assert.IsNotNull(engine);
            Assert.IsNotNull(engine.MasterLocationFormats);
            Assert.IsNotNull(engine.ViewLocationFormats);
            Assert.IsNotNull(engine.PartialViewLocationFormats);
            Assert.IsNotNull(engine.AreaMasterLocationFormats);
            Assert.IsNotNull(engine.AreaViewLocationFormats);
            Assert.IsNotNull(engine.AreaPartialViewLocationFormats);

            Assert.IsTrue(engine.FileExtensions.Contains("html"));
            Assert.IsTrue(engine.FileExtensions.Contains("htm"));
        }

        [Test]
        public void NullCheckConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() => new YateViewEngine(null));
        }

        [Test]
        public void CreateViewTest()
        {
            //https://mvcpatch.svn.codeplex.com/svn/src/System.Web.Mvc/Mvc/VirtualPathProviderViewEngine.cs
            Assert.Fail("Getting to this code is going to require quite a bit more work... failing test until I get to it");
        }

        [Test]
        public void CreatePartialViewTest()
        {
            //https://mvcpatch.svn.codeplex.com/svn/src/System.Web.Mvc/Mvc/VirtualPathProviderViewEngine.cs
            Assert.Fail("Getting to this code is going to require quite a bit more work... failing test until I get to it");
        }
    }
}