using csprojectbuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssemblyInfoTest
{
    [TestClass]
    public class XMLCreatorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            XMLCreator XMLCR = new XMLCreator("MyAssembly", Guid.Empty);

            string result = XMLCR.Result.ToString();
        }
    }
}
