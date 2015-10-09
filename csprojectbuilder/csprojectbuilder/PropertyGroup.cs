using System;
using System.Xml.Linq;

namespace csprojectbuilder
{
    public class MainPropertyGroup
    {
        public XElement Element { get; private set; }

        private XElement _Configuration = new XElement(Utils.NameSpace + "Configuration", new XAttribute("Condition", " '$(Configuration)' == '' "))
        {
            Value = "Debug"
        };
        private XElement _Platform = new XElement(Utils.NameSpace + "Platform", new XAttribute("Condition", " '$(Platform)' == '' "))
        {
            Value = "AnyCPU"
        };

        private XElement _ProjectGuid = new XElement(Utils.NameSpace + "ProjectGuid");
        private XElement _OutputType = new XElement(Utils.NameSpace + "OutputType")
        {
            Value = "Library"
        };
        private XElement _RootNamespace = new XElement(Utils.NameSpace + "RootNamespace");
        private XElement _AssemblyName = new XElement(Utils.NameSpace + "AssemblyName");
        private XElement _TargetFrameworkVersion = new XElement(Utils.NameSpace + "TargetFrameworkVersion")
        {
            Value = "v4.5"
        };
        private XElement _FileAlignment = new XElement(Utils.NameSpace + "FileAlignment")
        {
            Value = "512"
        };

        public string Configuration
        {
            get { return _Configuration.Value; }
            set { _Configuration.Value = value; }
        }

        public string Platform
        {
            get { return _Platform.Value; }
            set { _Platform.Value = value; }
        }

        public Guid ProjectGuid
        {
            get { return Guid.Parse(_ProjectGuid.Value.Trim('{', '}')); }
            private set { _ProjectGuid.Value = "{" + value.ToString() + "}"; }
        }

        public string OutputType
        {
            get { return _OutputType.Value; }
            set { _OutputType.Value = value; }
        }

        public string RootNamespace
        {
            get { return _RootNamespace.Value; }
            private set { _RootNamespace.Value = value; }
        }

        public string AssemblyName
        {
            get { return _AssemblyName.Value; }
            private set { _AssemblyName.Value = value; }
        }

        public string TargetFrameworkVersion
        {
            get { return _TargetFrameworkVersion.Value; }
            private set { _TargetFrameworkVersion.Value = value; }
        }

        public MainPropertyGroup(string AssemblyName, string RootNamespace, Guid ProjectGuid)
        {
            Element = new XElement(Utils.NameSpace + "PropertyGroup");
            Element.Add(_Configuration);
            Element.Add(_Platform);
            Element.Add(_ProjectGuid);
            this.ProjectGuid = ProjectGuid;
            Element.Add(_OutputType);
            Element.Add(new XElement(Utils.NameSpace + "AppDesignerFolder") { Value = "Properties" });
            Element.Add(_RootNamespace);
            this.RootNamespace = RootNamespace;
            Element.Add(_AssemblyName);
            this.AssemblyName = AssemblyName;
            Element.Add(_TargetFrameworkVersion);
            Element.Add(_FileAlignment);
        }
    }
}
