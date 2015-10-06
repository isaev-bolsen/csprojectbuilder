﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace csprojectbuilder
{
    public class ProjectGroup
    {
        private List<ConfigurationGroup> ConfigurationList = new List<ConfigurationGroup>()
        {
            new ConfigurationGroup("Debug","AnyCPU"),
            new ConfigurationGroup("Release","AnyCPU")
        };

        public XDocument Result
        {
            get
            {
                return new XDocument(new XElement(Utils.NameSpace + "Project", EnumerateProjectTagItems));
            }
        }

        public MainPropertyGroup MainPropertyGroup { get; private set; }
        public IEnumerable<ConfigurationGroup> Configurations
        {
            get { return ConfigurationList.AsEnumerable(); }
        }

        private IEnumerable<XObject> EnumerateProjectTagItems
        {
            get
            {
                yield return new XAttribute("ToolsVersion", "4.0");
                yield return new XAttribute("DefaultTargets", "Build");
                yield return new XElement(Utils.NameSpace + "Import",
                    new XAttribute("Project", @"$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props"),
                    new XAttribute("Condition", @"Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')")
                    );
                yield return MainPropertyGroup.Element;
                foreach (var C in ConfigurationList) yield return C.Element;
            }
        }

        public ProjectGroup(string title, Guid projectGuid) : this(title, title, projectGuid) { }

        public ProjectGroup(string title, string RootNamespace, Guid projectGuid)
        {
            MainPropertyGroup = new MainPropertyGroup(title, RootNamespace, projectGuid);
        }

        public void AddConfiguration(ConfigurationGroup configuration)
        {
            if (ConfigurationList.Any(C => C.ConfigurationName == configuration.ConfigurationName && C.Platform == configuration.Platform))
                throw new ArgumentException(string.Format("Configuration {0}|{1} already exists!", configuration.ConfigurationName, configuration.Platform));

            ConfigurationList.Add(configuration);
        }

        public void RemoveConfiguration(ConfigurationGroup configuration)
        {
            ConfigurationList.Remove(configuration);
        }
    }
}
