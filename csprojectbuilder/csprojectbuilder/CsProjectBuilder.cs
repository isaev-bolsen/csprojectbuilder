using System;
using System.IO;

namespace csprojectbuilder
{
    public class CsProjectBuilder
    {
        public ProjectGroup CsProj { get; private set; }
        public AssemblyInfoCs AssemblyInfoCs { get; private set; }
        public DirectoryInfo WorkingFolder { get; private set; }
        public string Title { get; private set; }

        public CsProjectBuilder(string title, DirectoryInfo workingFolder, Guid projectGuid, Guid AssemblyGuid)
        {
            AssemblyInfoCs = new AssemblyInfoCs(title, AssemblyGuid);
            CsProj = new ProjectGroup(title, projectGuid);
            WorkingFolder = workingFolder;
            Title = title;
        }

        public void SaveFiles()
        {
            CsProj.Result.Save(Path.Combine(WorkingFolder.FullName, Title + ".csproj"));
            DirectoryInfo PropertiesFolder = new DirectoryInfo(Path.Combine(WorkingFolder.FullName, "Properties"));
            if(!PropertiesFolder.Exists) PropertiesFolder.Create();
            FileInfo AssemblyInfoFile=new FileInfo(Path.Combine(PropertiesFolder.FullName,"AssemblyInfo.cs"));
            AssemblyInfoCs.SaveToStream(AssemblyInfoFile.CreateText());
        }
    }
}
