using System;
using System.Xml.Linq;
using System.Linq;

namespace csprojectbuilder
{
    public class Configuration
    {
        public XElement Element { get; private set; }

        private XElement _DebugSymbols = new XElement("DebugSymbols") { Value = "true" };
        private XElement _DebugType = new XElement("DebugType");
        private XElement _Optimize = new XElement("Optimize");
        private XElement _OutputPath = new XElement("OutputPath");
        private XElement _DefineConstants = new XElement("DefineConstants");
        private XElement _ErrorReport = new XElement("ErrorReport") { Value = "prompt" };
        private XElement _WarningLevel = new XElement("WarningLevel");

        public bool DebugSymbols
        {
            get { return Element.Elements().Contains(_DebugSymbols); }
            set
            {
                if (value == DebugSymbols) return;
                if (value) Element.AddFirst(_DebugSymbols);
                else _DebugSymbols.Remove();
            }
        }

        public string DebugType
        {
            get { return _DebugType.Value; }
            set { _DebugType.Value = value; }
        }

        public bool Optimize
        {
            get { return Boolean.Parse(_Optimize.Value); }
            set { _Optimize.Value = value.ToString(); }
        }

        public string OutputPath
        {
            get { return _OutputPath.Value; }
            set { _OutputPath.Value = value; }
        }

        public string DefineConstants
        {
            get { return _DefineConstants.Value; }
            set { _DefineConstants.Value = value; }
        }

        public string ErrorReport
        {
            get { return _ErrorReport.Value; }
            set { _ErrorReport.Value = value; }
        }

        public int WarningLevel
        {
            get { return int.Parse(_WarningLevel.Value); }
            set { _WarningLevel.Value = value.ToString(); }
        }

        public Configuration(string Configuration, string platform)
        {
            Element = new XElement(Utils.NameSpace + "PropertyGroup",
                new XAttribute("Condition", string.Format(" '$(Configuration)|$(Platform)' == '{0}|{1}' ", Configuration, platform)));

            bool isDebug = Configuration.Equals("Debug");
            DebugSymbols = isDebug;
            DebugType = isDebug ? "full" : "pdbonly";
            Element.Add(_DebugType);
            Optimize = !isDebug;
            Element.Add(_Optimize);
            OutputPath = string.Format(@"\bin\{0}\", Configuration);
            Element.Add(_OutputPath);
            DefineConstants = isDebug ? "DEBUG;TRACE" : "TRACE";
            Element.Add(_DefineConstants);
            Element.Add(_ErrorReport);
            WarningLevel = 4;
            Element.Add(_WarningLevel);
        }
    }
}
