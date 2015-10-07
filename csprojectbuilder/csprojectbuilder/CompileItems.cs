using System.Collections.Generic;
using System.Xml.Linq;

namespace csprojectbuilder
{
    class CompileItems
    {
        private List<XElement> Elements = new List<XElement>();

        public XElement Element
        {
            get { return new XElement(Utils.NameSpace + "ItemGroup", Elements); }
        }

        public void AddFile(string path)
        {
            Elements.Add(new XElement(Utils.NameSpace + "Compile", new XAttribute("Include", path)));
        }
    }
}
