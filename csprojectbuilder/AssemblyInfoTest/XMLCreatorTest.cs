using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csprojectbuilder;
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
