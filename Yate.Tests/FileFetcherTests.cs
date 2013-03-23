using System;
using System.IO;
using NUnit.Framework;

namespace Yate.Tests
{
    [TestFixture]
    public class FileFetcherTests
    {
        [Test]
        public void CanReadTextFiles()
        {
            var fileFetcher = new FileFetcher();

            var str = fileFetcher.GetText(@"\data\small.txt");

            Assert.AreEqual("hi buddy", str);
        }

        [Test]
        public void FileNotFound()
        {
            var fileFetcher = new FileFetcher();

            Assert.Throws<FileNotFoundException>(() => fileFetcher.GetText(@"\does-not-exist.txt"));
        }

        [Test]
        public void CanReadTextFilesInSearchableDirectory()
        {
            var fileFetcher = new FileFetcher(new[] { AppDomain.CurrentDomain.BaseDirectory });

            var str = fileFetcher.GetText(@"\data\small.txt");

            Assert.AreEqual("hi buddy", str);
        }

        [Test]
        public void CanReadTextFilesDirectly()
        {
            var fileFetcher = new FileFetcher();

            var str = fileFetcher.GetText(AppDomain.CurrentDomain.BaseDirectory + @"\data\small.txt");

            Assert.AreEqual("hi buddy", str);
        }


        [Test]
        public void CanReadTextFilesRelitiveToBaseDirector()
        {
            var fileFetcher = new FileFetcher();

            var str = fileFetcher.GetText(@"~\data\small.txt");

            Assert.AreEqual("hi buddy", str);
        }
    }
}