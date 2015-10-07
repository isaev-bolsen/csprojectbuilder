using System.Collections.Generic;
using System.Xml.Linq;

namespace csprojectbuilder
{
    class References
    {
        private List<XElement> Elements = new List<XElement>();

        public XElement Element
        {
            get { return new XElement("ItemGroup", Elements); }
        }

        public void AddReference(string reference)
        {
            Elements.Add(new XElement("Reference", new XAttribute("Include", reference)));
        }

        public void AddReference(string reference, string HintPath)
        {
            Elements.Add(new XElement("Reference", new XAttribute("Include", reference), new XElement("HintPath", HintPath)));
        }
    }
}
