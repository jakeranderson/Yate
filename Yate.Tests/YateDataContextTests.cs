using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Yate.Tests
{
    [TestFixture]
    public class YateDataContextTests
    {
        [Test]
        public void DoesItWork()
        {
            var dc = new YateDataContext(new { foo = "bar" });

            Assert.AreEqual("bar", dc.GetValue("foo"));
        }

        [Test]
        public void WholeObjectTest()
        {
            var model = new { foo = "bar" };
            var dc = new YateDataContext(model);

            Assert.AreSame(model, dc.GetValue("."));
            Assert.AreEqual(model, dc.GetValue("."));
        }

        [Test]
        public void DoesNotExistGivesNull()
        {
            var dc = new YateDataContext(new { foo = "bar" });

            Assert.AreEqual(null, dc.GetValue("yeahBUddy"));
        }

        [Test]
        public void CanPushValuesAndGetBothObjectsValues()
        {
            var dc = new YateDataContext(new { foo = "bar" });

            dc.PushValue(new { hello = "world" });

            Assert.AreEqual("bar", dc.GetValue("foo"));
            Assert.AreEqual("world", dc.GetValue("hello"));
        }

        [Test]
        public void PopingRemovesModels()
        {
            var dc = new YateDataContext(new { foo = "bar" });

            dc.PushValue(new { hello = "world" });

            Assert.AreEqual("bar", dc.GetValue("foo"));
            Assert.AreEqual("world", dc.GetValue("hello"));

            dc.PopValue();

            Assert.AreEqual("bar", dc.GetValue("foo"));
            Assert.AreEqual(null, dc.GetValue("hello"));
        }
    }
}
