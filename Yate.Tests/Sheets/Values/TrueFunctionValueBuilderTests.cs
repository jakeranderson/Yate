using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class TrueFunctionValueBuilderTests
    {
        [Test]
        public void DoesItWork()
        {
            var builder = new TrueFunctionValueBuilder();
            var value = builder.Build(new List<IValue>());

            Assert.IsNotNull(value);
            Assert.IsInstanceOf<TrueFunctionValue>(value);
        }
    }
}