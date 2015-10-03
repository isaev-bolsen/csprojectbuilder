using csprojectbuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssemblyInfoTest
{
    [TestClass]
    public class AssemblyInfoTest
    {
        private static IEnumerable<string> ReadLines(StreamReader reader)
        {
            while (!reader.EndOfStream) yield return reader.ReadLine();
        }

        [TestMethod]
        public void VerifyAssemblyInfoLines()
        {
            AssemblyInfoCs AssInfo = new AssemblyInfoCs("MyAssembly", Guid.Empty);
            Assert.AreEqual("MyAssembly", AssInfo.Product);
            var currentLines = AssInfo.Lines.ToList();
            var etallonLines = ReadLines(new FileInfo("AssemblyInfo.txt").OpenText()).
                Where(L => !L.StartsWith("//") && !string.IsNullOrEmpty(L)).ToList();

            Assert.AreEqual(etallonLines.Count, currentLines.Count);
            for (int i = 0; i < etallonLines.Count; ++i)
            {
                Assert.AreEqual(etallonLines[i].Trim(), currentLines[i].Trim(), true);
            }
        }
    }
}
