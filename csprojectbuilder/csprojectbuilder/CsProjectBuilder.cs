using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace csprojectbuilder
{
    public class CsProjectBuilder
    {
        private XDocument csproj = new XDocument();

        public AssemblyInfoCs AssemblyInfoCs { get; private set; }

        public CsProjectBuilder(string title, DirectoryInfo workingFolder, Guid projectGuid, Guid AssemblyGuid)
        {
            AssemblyInfoCs = new AssemblyInfoCs(title, AssemblyGuid);
        }
    }
}
