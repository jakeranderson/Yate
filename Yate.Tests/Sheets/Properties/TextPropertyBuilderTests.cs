using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Properties;

namespace Yate.Tests.Sheets.Properties
{
    [TestFixture]
    public class TextPropertyBuilderTests
    {
        [Test]
        public void BuildBasicTest()
        {
            var builder = new TextPropertyBuilder();

            var textProperty = builder.Build(new List<IValue>());

            Assert.IsNotNull(textProperty);
            Assert.IsInstanceOf<TextProperty>(textProperty);
        }
    }
}