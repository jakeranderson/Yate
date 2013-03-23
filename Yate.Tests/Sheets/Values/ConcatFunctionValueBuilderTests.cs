using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class ConcatFunctionValueBuilderTests
    {
        [Test]
        public void DoesItWork()
        {
            var builder = new ConcatFunctionValueBuilder();
            var value = builder.Build(new List<IValue>());

            Assert.IsInstanceOf<ConcatFunctionValue>(value);
            Assert.IsNotNull(value);
        }
    }
}