using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Guid guid { get; private set; }

        public AssemblyInfoCs(string title,Guid AssemblyGuid)
        {
            Title = title;
        }

        private static string ItemToString(KeyValuePair<string, string> item)
        {
            return string.Format("[assembly: Assembly{0}(\"{1}\")]", item.Key, item.Value);
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
