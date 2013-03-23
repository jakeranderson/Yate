using System.Collections.Generic;
using NUnit.Framework;
using Yate.Sheets;
using Yate.Sheets.Values;

namespace Yate.Tests.Sheets.Values
{
    [TestFixture]
    public class ModelFunctionValueBuilderTests
    {
        [Test]
        public void BuildWorks()
        {
            var builder = new ModelFunctionValueBuilder();

            var result = builder.Build(new List<IValue> { new StringValue("*") });

            Assert.IsNotNull(result);
        }
    }
}