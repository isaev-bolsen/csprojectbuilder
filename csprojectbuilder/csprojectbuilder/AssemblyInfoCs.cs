using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace csprojectbuilder
{
    public class AssemblyInfoCs : IDictionary<string, string>
    {
        private static readonly List<string> namespaces = new List<string>()
        {
            "﻿using System.Reflection;",
            "using System.Runtime.CompilerServices;",
            "using System.Runtime.InteropServices;"
        };

        private Dictionary<string, string> attributes = new Dictionary<string, string>();

        public string Title
        {
            get { return attributes["Title"]; }
            set { attributes["Title"] = value; }
        }

        public string Description
        {
            get { return attributes["Description"]; }
            set { attributes["Description"] = value; }
        }

        public string Configuration
        {
            get { return attributes["Configuration"]; }
            set { attributes["Configuration"] = value; }
        }

        public string Company
        {
            get { return attributes["Company"]; }
            set { attributes["Company"] = value; }
        }

        public string Product
        {
            get { return attributes["Product"]; }
            set { attributes["Product"] = value; }
        }

        public string Copyright
        {
            get { return attributes["Copyright"]; }
            set { attributes["Copyright"] = value; }
        }

        public string Trademark
        {
            get { return attributes["Trademark"]; }
            set { attributes["Trademark"] = value; }
        }

        public string Culture
        {
            get { return attributes["Copyright"]; }
            set { attributes["Copyright"] = value; }
        }

        public string Version { get; set; }
        public string FileVersion { get; set; }

        public Guid Guid { get; private set; }

        public AssemblyInfoCs(string title, Guid AssemblyGuid)
        {
            Guid = AssemblyGuid;
            Title = title;
            Description = string.Empty;
            Configuration = string.Empty;
            Company = string.Empty;
            Product = title;
            Copyright = string.Format("Copyright ©  {0}", DateTime.Now.Year);
            Version = "1.0.0.0";
            FileVersion = "1.0.0.0";
        }

        private static string AttributeToString(KeyValuePair<string, string> item)
        {
            return AttributeToString(item.Key, item.Value);
        }

        private static string AttributeToString(string Key, string Value)
        {
            return string.Format("[assembly: Assembly{0}(\"{1}\")]", Key, Value);
        }

        private IEnumerable<string> SpecificLines
        {
            get
            {
                yield return "[assembly: ComVisible(false)]";
                yield return string.Format("[assembly: Guid(\"{0}\")]", Guid);
                yield return AttributeToString("Version", Version);
                yield return AttributeToString("FileVersion", FileVersion);
            }
        }

        public IEnumerable<string> Lines
        {
            get
            {
                return namespaces.Union(attributes.Select(p => AttributeToString(p))).Union(SpecificLines);
            }
        }

        public void SaveToStream(StreamWriter stream)
        {
            foreach (string line in Lines) stream.WriteLine(line);
        }

        public string this[string key]
        {
            get { return attributes[key]; }
            set { attributes[key] = value; }
        }

        public int Count
        {
            get { return attributes.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public ICollection<string> Keys
        {
            get { return attributes.Keys; }
        }

        public ICollection<string> Values
        {
            get { return attributes.Values; }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            attributes.Add(item.Key, item.Value);
        }

        public void Add(string key, string value)
        {
            attributes.Add(key, value);
        }

        public void Clear()
        {
            attributes.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return attributes.Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return attributes.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((IDictionary<string, string>)attributes).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return attributes.GetEnumerator();
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return attributes.Remove(item.Key);
        }

        public bool Remove(string key)
        {
            return attributes.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            return attributes.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return attributes.GetEnumerator();
        }
    }
}
