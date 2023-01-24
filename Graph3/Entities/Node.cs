using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Graph3.Entities
{
    internal class Node
    {
        private Dictionary<string, double> node;
        public Dictionary<string, double> GetNode { get { return node; } }
        public int Count { get { return node.Count; } }
        public Node()
        {
            node = new Dictionary<string, double>();
        }
        public Node(Dictionary<string, double> node)
        {
            this.node = new Dictionary<string, double>(node);
        }
        public Node(string s, double w)
        {
            node = new Dictionary<string, double>();
            if (!(node.ContainsKey(s)))
            {
                node.Add(s, w);
            }
        }
        public Node(Node n)
        {
            node = new Dictionary<string, double>();
            foreach (var x in n.node)
            {
                node.Add(x.Key, x.Value);
            }
        }
        public bool Add(string s, double w)
        {
            if (!node.ContainsKey(s))
            {
                node.Add((string)s, w);
                return true;
            }
            else
            {
                Console.WriteLine("node has already add");
                return false;
            }
        }
        public void Clean()
        {
            node = new Dictionary<string, double>();
        }
        public Dictionary<string, double> NodeN { get { return node; } }
        public bool Delete(string s)
        {
            return (node.Remove(s));
        }
        public override String ToString()
        {
            return node.ToString();
        }
        public void ShowLine(bool weigted)
        {
            if (weigted)
            {
                if (node.Count < 1) Console.Write("--");
                foreach (var l in node)
                {
                    Console.Write(" {0} - {1,4} ;  ", l.Key, l.Value);
                }
            }
            else
            {
                if (node.Count < 1) Console.Write("--"); ;
                foreach (var l in node)
                {
                    Console.Write(" {0}", l.Key);
                }
            }
        }
        public string WriteLine(string name, bool weigted)
        {
            StringBuilder s = new StringBuilder();
            if (weigted)
            {
                foreach (var l in node)
                {
                    s.Append(l.Key);
                    s.Append(": ");
                    s.Append(l.Value);
                }
            }
            else
            {
                foreach (var l in node)
                {
                    s.Append(l.Key);
                    s.Append(" ");
                }
            }
            return s.ToString();
        }
    }
}