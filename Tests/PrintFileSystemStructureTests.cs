using System.Collections.Generic;
using Algorithms.Custom;
using FluentAssertions;
using Xunit;
using static Algorithms.Custom.PrintFileSystemStructure;

namespace Tests
{
    public static class PrintFileSystemStructureTests
    {
        [Fact]
        public static void Test()
        {
            var obj = new PrintFileSystemStructure();
            var files = new string[]
            {
              "app/root",
              "folder/index.js",
              "app/components/newFolder",
              "app/root/root1"
            };

            var results = new List<string>();
            var outputProvider = new Provider(results);
            obj.Print(files, outputProvider);

            var expectedResults = new List<string>()
            {
                " -- folder",
                "     -- index.js",
                " -- app",
                "     -- components",
                "         -- newFolder",
                "     -- root",
                "         -- root1"
            };

            results.Should().Contain(expectedResults);
        }

        private class Provider : IOutputProvider
        {
            private List<string> _lines;
            public Provider(List<string> lines) => _lines = lines;
            public void AddLine(string line) => _lines.Add(line);
        }
    }
}