using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csprojectbuilder
{
    public class XMLCreator
    {
        private Guid projectGuid;
        private string title;
        private static readonly XNamespace NameSpace = "http://schemas.microsoft.com/developer/msbuild/2003";

        public XDocument Result { get; private set; }
        private XElement ProjectTag = new XElement(NameSpace + "Project");

        public XMLCreator(string title, Guid projectGuid)
        {
            this.title = title;
            this.projectGuid = projectGuid;
            Result = new XDocument();
            ProjectTag.Add(new XAttribute("ToolsVersion", "4.0"));
            ProjectTag.Add(new XAttribute("DefaultTargets", "Build"));

            Result.Add(ProjectTag);
        }
    }
}
