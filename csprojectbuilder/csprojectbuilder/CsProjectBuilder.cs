using System;
using System.IO;

namespace csprojectbuilder
{
    public class CsProjectBuilder
    {
        public XMLCreator CsProj { get; private set; }

        public AssemblyInfoCs AssemblyInfoCs { get; private set; }

        public CsProjectBuilder(string title, DirectoryInfo workingFolder, Guid projectGuid, Guid AssemblyGuid)
        {
            AssemblyInfoCs = new AssemblyInfoCs(title, AssemblyGuid);
            CsProj = new XMLCreator(title, projectGuid);
        }
    }
}
