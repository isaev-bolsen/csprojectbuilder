using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace csprojectbuilder
{
    public class ProjectGroup
    {
        private XElement ProjectTag = new XElement(Utils.NameSpace + "Project");
        private List<ConfigurationGroup> ConfigurationList = new List<ConfigurationGroup>()
        {
            new ConfigurationGroup("Debug","AnyCPU"),
            new ConfigurationGroup("Release","AnyCPU")
        };

        public XDocument Result { get; private set; }
        public PropertyGroup PropertyGroup { get; private set; }
        public IEnumerable<ConfigurationGroup> Configurations
        {
            get { return ConfigurationList.AsEnumerable(); }
        }

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
            ProjectTag.Add(ConfigurationList.Select(C => C.Element));
        }

        public void AddConfiguration(ConfigurationGroup configuration)
        {
            if (ConfigurationList.Any(C => C.ConfigurationName == configuration.ConfigurationName && C.Platform == configuration.Platform))
                throw new ArgumentException(string.Format("Configuration {0}|{1} already exists!", configuration.ConfigurationName, configuration.Platform));

            ConfigurationList.Add(configuration);
            PropertyGroup.Element.AddAfterSelf(configuration.Element);
        }

        public void RemoveConfiguration(ConfigurationGroup configuration)
        {
            ConfigurationList.Remove(configuration);
            configuration.Element.Remove();
        }
    }
}
