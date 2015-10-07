using csprojectbuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AssemblyInfoTest
{
    [TestClass]
    public class ProjectGroupTest
    {
        [TestMethod]
        public void ProjectGroupTest1()
        {
            ProjectGroup XMLCR = new ProjectGroup("MyAssembly", Guid.Empty);
            XMLCR.AddReferences("System", "System.Core", "System.Xml.Linq", "System.Data.DataSetExtensions", "Microsoft.CSharp", "System.Data", "System.Xml");
            string result = XMLCR.Result.ToString();
        }
    }
}
