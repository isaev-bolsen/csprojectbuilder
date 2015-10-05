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

            string result = XMLCR.Result.ToString();
        }
    }
}
