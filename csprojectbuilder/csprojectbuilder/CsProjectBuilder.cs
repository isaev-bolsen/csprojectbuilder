using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public void AddFiles(IEnumerable<FileInfo> files)
        {
            CsProj.AddFiles(files.Select(f => CorrectFileName(f)).ToArray());
        }

        private string CorrectFileName(FileInfo f)
        {
            if (!f.FullName.StartsWith(WorkingFolder.FullName)) throw new ArgumentException("I expect files must be located in working folder!");
            return f.FullName.Substring(WorkingFolder.FullName.Length).Trim('\\');
        }

        public void AddReferences(params string[] namespaces)
        {
             CsProj.AddReferences(namespaces);
        }

        public void AddReference(string reference, FileInfo HintPath)
        {
            CsProj.AddReference(reference, CorrectFileName(HintPath));
        }

        public void SaveFiles()
        {
            CsProj.Result.Save(Path.Combine(WorkingFolder.FullName, Title + ".csproj"));
            DirectoryInfo PropertiesFolder = new DirectoryInfo(Path.Combine(WorkingFolder.FullName, "Properties"));
            if (!PropertiesFolder.Exists) PropertiesFolder.Create();
            FileInfo AssemblyInfoFile = new FileInfo(Path.Combine(PropertiesFolder.FullName, "AssemblyInfo.cs"));
            AssemblyInfoCs.SaveToStream(AssemblyInfoFile.CreateText());
        }
    }
}
