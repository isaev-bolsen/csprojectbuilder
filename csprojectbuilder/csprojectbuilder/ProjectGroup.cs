using System;
using System.Xml.Linq;

namespace csprojectbuilder
{
    public class ProjectGroup
    {
        private XElement ProjectTag = new XElement(Utils.NameSpace + "Project");

        public XDocument Result { get; private set; }
        public PropertyGroup PropertyGroup { get; private set; }


        public ProjectGroup(string title, Guid projectGuid) : this(title, title, projectGuid) { }

        public ProjectGroup(string title, string RootNamespace, Guid projectGuid)
        {
            PropertyGroup = new PropertyGroup(title, RootNamespace, projectGuid);
            Result = new XDocument();
            ProjectTag.Add(new XAttribute("ToolsVersion", "4.0"));
            ProjectTag.Add(new XAttribute("DefaultTargets", "Build"));
            ProjectTag.Add(new XElement(
                Utils.NameSpace + "Import",
                new XAttribute("Project", @"$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props"),
                new XAttribute("Condition", @"Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')")
                ));

            Result.Add(ProjectTag);
            ProjectTag.Add(PropertyGroup.Element);
        }
    }
}
