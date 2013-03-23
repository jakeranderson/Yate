using System;
using System.IO;

namespace Yate
{
    //is needed to get text files
    public class FileFetcher : IFileFetcher
    {
        private readonly string[] _searchableDirectories;

        public FileFetcher()
        {
            _searchableDirectories = new[] { AppDomain.CurrentDomain.BaseDirectory };
        }

        public FileFetcher(string[] searchableDirectories)
        {
            _searchableDirectories = searchableDirectories;
        }

        public string GetText(string filePath)
        {
            if (filePath.StartsWith("~"))
            {
                return GetText(AppDomain.CurrentDomain.BaseDirectory + filePath.TrimStart('~'));
            }

            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }

            foreach (var searchableDirectory in _searchableDirectories)
            {
                if (File.Exists(searchableDirectory + filePath))
                {
                    return File.ReadAllText(searchableDirectory + filePath);
                }
            }

            throw new FileNotFoundException("File was not found", filePath);
        }
    }
}
