using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Graph3.Entities
{
    internal class Graph
    {
        private int id;
        private Dictionary<string, Node> graph;
        private bool isWeighted;
        private bool isDirected;

        public bool Directed { get { return isDirected; } }
        public bool Weighted { get { return isWeighted; } }
        public int Id { get { return id; } set { id = value; } }
        public Dictionary<string, Node> Nodes { get { return graph; } }
        public Dictionary<string, Node> GraphG { get { return graph; } }

        public char[] splitChars = { ' ', '\n', '\t', '\r' };
        public Graph()
        {
            id = 0;
            graph = new Dictionary<string, Node>();
            isWeighted = false;
            isDirected = false;
        }
        public Graph(Graph g)
        {
            this.id = g.id;
            this.isWeighted = g.isWeighted;
            this.isDirected = g.isDirected;
            this.graph = new Dictionary<string, Node>();
            foreach (var x in g.graph)
            {
                graph.Add(x.Key, new Node(x.Value));
            }
        }
        public Graph(Dictionary<string, Node> dict, bool directed, bool weighted)
        {
            isDirected = directed;
            isWeighted = weighted;
            graph = new Dictionary<string, Node>(dict);
        }
        public Graph(bool directed, bool weighted)
        {
            id = 0;
            graph = new Dictionary<string, Node>();
            isDirected = directed;
            isWeighted = weighted;
        }
        public Graph(string name)
        {
            using (StreamReader fileIn = new StreamReader(name))
            {
                string prm = fileIn.ReadLine();
                string[] prms = prm.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                bool directed = bool.Parse(prms[0]);
                isDirected = directed;
                bool weighted = bool.Parse(prms[1]);
                isWeighted = weighted;
                var dict = new Dictionary<string, Node>();
                int n = int.Parse(fileIn.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string line = fileIn.ReadLine();
                    string[] data = line.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                    if (weighted)
                    {
                        if (data.Length == 1)
                        {
                            if (!dict.ContainsKey(data[0]))
                            {
                                dict.Add(data[0], new Node());

                            }
                        }
                        else if (data.Length == 3)
                        {
                            if (directed)
                            {
                                Node value = new Node();
                                double weight = double.Parse(data[2]);
                                value.Add(data[1], weight);
                                if (!dict.ContainsKey(data[0]))
                                {
                                    dict.Add(data[0], value);
                                    if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                    {
                                        dict.Add(data[1], new Node());
                                    }
                                }
                                else
                                {
                                    dict[data[0]].Add(data[1], weight);
                                    if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                    {
                                        dict.Add(data[1], new Node());
                                    }
                                }
                            }
                            else
                            {
                                Node value = new Node();
                                double weight = double.Parse(data[2]);
                                value.Add(data[1], weight);
                                if (!dict.ContainsKey(data[0]))
                                {
                                    dict.Add(data[0], value);

                                }
                                else
                                {
                                    dict[data[0]].Add(data[1], weight);
                                }

                                Node value2 = new Node();
                                value2.Add(data[0], weight);
                                if (!dict.ContainsKey(data[1]))
                                {
                                    dict.Add(data[1], value2);
                                }
                                else
                                {
                                    dict[data[1]].Add(data[0], weight);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверное количество аргументов");
                        }
                    }
                    else
                    {
                        if (data.Length == 1)
                        {
                            if (!dict.ContainsKey(data[0]))
                            {
                                dict.Add(data[0], new Node());
                            }
                        }
                        else if (data.Length == 2)
                        {
                            if (directed)
                            {
                                Node value = new Node();
                                double weight = 0;
                                value.Add(data[1], weight);
                                if (!dict.ContainsKey(data[0]))
                                {
                                    dict.Add(data[0], value);
                                    if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                    {
                                        dict.Add(data[1], new Node());
                                    }
                                }
                                else
                                {
                                    if (!dict.ContainsKey(data[1]))
                                    {
                                        dict.Add(data[1], new Node());
                                    }
                                    dict[data[0]].Add(data[1], weight);
                                }
                            }
                            else
                            {
                                Node value = new Node();
                                double weight = 0;
                                value.Add(data[1], weight);
                                if (!dict.ContainsKey(data[0]))
                                {
                                    dict.Add(data[0], value);
                                    if (!dict.ContainsKey(data[1]) && dict.ContainsKey(data[0]))
                                    {
                                        dict.Add(data[1], new Node());
                                    }
                                }
                                else
                                {
                                    if (!dict.ContainsKey(data[1]))
                                    {
                                        dict.Add(data[1], new Node());
                                    }
                                    dict[data[0]].Add(data[1], weight);
                                }

                                Node value2 = new Node();
                                value2.Add(data[0], weight);
                                if (!dict.ContainsKey(data[1]))
                                {
                                    dict.Add(data[1], value2);
                                }
                                else
                                {
                                    dict[data[1]].Add(data[0], weight);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверное количество аргументов");
                        }
                    }
                }
                graph = new Dictionary<string, Node>(dict);
                isWeighted = weighted;
                isDirected = directed;
            }
        }
        public Graph Create(bool isDirected, bool isWeighted)
        {
            return new Graph(isDirected, isWeighted);
        }
        public bool Add(string v1, string v2, double w)
        {
            if (isDirected)
            {
                Dictionary<string, double> value = new Dictionary<string, double>();
                value.Add(v2, w);
                Node node = new Node(value);
                if (!(graph.ContainsKey(v1)))
                {
                    graph.Add(v1, node);
                    if (!graph.ContainsKey(v2) && graph.ContainsKey(v1))
                    {
                        graph.Add(v2, new Node());
                    }
                    return graph.ContainsKey(v1);
                }
                else
                {
                    if (!graph.ContainsKey(v2))
                    {
                        graph.Add(v2, new Node());
                    }
                    return graph[v1].Add(v2, w);
                }
            }
            else
            {
                Dictionary<string, double> value = new Dictionary<string, double>();
                value.Add(v2, w);
                Node node = new Node(value);
                if (!(graph.ContainsKey(v1)))
                {
                    graph.Add(v1, node);
                }
                else
                {
                    graph[v1].Add(v2, w);
                }
                value.Clear();
                value.Add(v1, w);
                node = new Node(value);
                if (!(graph.ContainsKey(v2)))
                {
                    graph.Add(v2, node);
                }
                else
                {
                    graph[v2].Add(v1, w);
                }
                return graph.ContainsKey(v2) & graph.ContainsKey(v1);
            }
        }
        public bool AddNode(string v)
        {
            if (!graph.ContainsKey(v))
            {
                graph.Add(v, new Node());
                return true;
            }
            else throw new Exception("ERROR: The node already exists");
        }

        public void Clean()
        {
            graph = new Dictionary<string, Node>();
        }
        public bool Delete(string s)
        {
            if (graph.ContainsKey(s))
            {
                graph.Remove(s);
                foreach (var g in graph)
                {
                    graph[g.Key].Delete(s);
                }
                return true;
            }
            else return false;
        }
        public bool DeleteNode(string s, string x)
        {
            if (isDirected)
            {
                if (graph.ContainsKey(s))
                {
                    return graph[s].Delete(x);
                }
                else
                {
                    Console.WriteLine("Error not contains key");
                    return false;
                }
            }
            else
            {
                if (graph.ContainsKey(x) && graph.ContainsKey(s))
                {
                    graph[s].Delete(x);
                    return graph[x].Delete(s);
                }
                else
                {
                    Console.WriteLine("Error not contains key");
                    return false;
                }
            }
        }
        public override String ToString()
        {
            return "directed: " + isDirected + " weighted: " + isWeighted + graph.ToString();
        }
        public void Show()
        {
            foreach (var i in graph)
            {
                Console.Write("{0,4} :", i.Key);
                if (i.Value != null)
                {
                    i.Value.ShowLine(isWeighted);
                }
                Console.WriteLine();
            }
        }
        public void Write(string name)
        {
            using (StreamWriter sw = new StreamWriter(name))
            {
                sw.WriteLine("{0} {1}", isDirected, isWeighted);
                foreach (var i in graph)
                {
                    sw.Write("{0,4} ", i.Key);
                    if (i.Value != null)
                    {
                        sw.WriteLine(i.Value.WriteLine(name, isWeighted));
                    }
                }
            }
        }
        public void Show(string v)
        {
            graph[v].ShowLine(isWeighted);
        }
        public void Task1(string v)
        {
            graph[v].ShowLine(isWeighted);
            Console.WriteLine();
        }
        public void Task2(string v)
        {
            foreach (var i in graph)
            {
                if (i.Key != v)
                {
                    if (!i.Value.NodeN.ContainsKey(v) && !graph[v].NodeN.ContainsKey(i.Key))
                    {
                        Console.Write("{0}, ", i.Key);
                    }

                }
            }
            Console.WriteLine();
        }
        public int T3(string v)
        {
            List<string> list = new List<string>();
            foreach (var i in graph)
            {
                if (i.Key != v)
                {
                    if (!i.Value.NodeN.ContainsKey(v) && !graph[v].NodeN.ContainsKey(i.Key))
                    {
                        list.Add(i.Key);
                    }

                }
            }
            return list.Count;
        }
        public Graph Task3()
        {
            Graph new_graph = new Graph(graph, isDirected, isWeighted);
            foreach (var i in new_graph.Nodes)
            {
                if (T3(i.Key) == graph.Keys.Count - 1)
                {
                    new_graph.Delete(i.Key);
                }
            }
            return new_graph;
        }

        private SortedDictionary<string, bool> nov = new SortedDictionary<string, bool>();
        public void NovSet()
        {
            nov.Clear();
            foreach (var i in graph)
            {
                nov.Add(i.Key, false);
            }
        }
        private SortedDictionary<string, char> nov3 = new SortedDictionary<string, char>();
        public void NovSet3()
        {
            nov3.Clear();
            foreach (var i in graph)
            {
                nov3.Add(i.Key, 'w');
            }
        }
        public void DFS(string v)
        {
            Console.Write("DFS from {0}:  ", v);
            NovSet();
            dfs(v);
            Console.WriteLine();
        }
        public void dfs(string v)
        {
            if (!nov[v])
            {
                nov[v] = true;
                foreach (var i in graph[v].NodeN)
                {
                    if (!nov[i.Key])
                    {
                        dfs(i.Key);
                        Console.Write("{0} ", i.Key);
                    }
                }
            }
        }
        public SortedDictionary<string, int> d;
        public SortedDictionary<string, string> p;
        public void BFSPrint(string v)
        {
            NovSet();

            Queue<string> q = new Queue<string>();
            d = new SortedDictionary<string, int>();
            foreach (var i in graph)
            {
                d.Add(i.Key, 0);
            }
            p = new SortedDictionary<string, string>();
            foreach (var i in graph)
            {
                p.Add(i.Key, "");
            }
            Console.Write("{0} ", v);
            q.Enqueue(v);
            nov[v] = true;
            p[v] = "-1";
            while (q.Count != 0)
            {
                string u = q.Peek();
                q.Dequeue();
                foreach (var t in graph[u].NodeN)
                {
                    if (!nov[t.Key])
                    {
                        nov[t.Key] = true;
                        q.Enqueue(t.Key);
                        Console.Write("{0} ", t.Key);
                        d[t.Key] = d[u] + 1;
                        p[t.Key] = u;
                    }
                }
            }
            Console.WriteLine();
        }
        public bool BFSPrint(string from, string to)
        {
            if (!nov[to])
            {
                Console.WriteLine("No path!");
                return false;
            }
            else
            {
                List<string> path = new List<string>();
                for (string v = to; v != "-1"; v = p[v]) path.Add(v);
                path.Reverse();
                Console.Write("BFS from {0} to {1}:  ", from, to);
                for (int i = 0; i < path.Count; i++) Console.Write("{0} ", path[i]);
                return true;
            }
            Console.WriteLine();
        }
        public void BFS(string v)
        {
            NovSet();
            Queue<string> q = new Queue<string>();
            d = new SortedDictionary<string, int>();
            p = new SortedDictionary<string, string>();
            foreach (var i in graph) d.Add(i.Key, 0);
            foreach (var i in graph) p.Add(i.Key, "");

            q.Enqueue(v);
            nov[v] = true;
            p[v] = "-1";
            while (q.Count != 0)
            {
                string u = q.Peek();
                q.Dequeue();
                for (var i = 0; i < graph[u].NodeN.Count; i++)
                    foreach (var t in graph[u].NodeN)
                    {
                        if (!nov[t.Key])
                        {
                            nov[t.Key] = true;
                            q.Enqueue(t.Key);
                            d[t.Key] = d[u] + 1;
                            p[t.Key] = u;
                        }
                    }
            }
        }
        public void Task4()
        {
            DFS_color();
        }
        public void dfs_t4(string v)
        {
            if (nov3[v] == 'w')
            {
                nov3[v] = 'g';
                foreach (var i in graph[v].NodeN)
                {
                    if (nov3[i.Key] == 'w')
                    {
                        dfs_t4(i.Key);
                    }
                    else if (nov3[i.Key] == 'g')
                    {
                        Console.WriteLine("есть цикл");
                    }

                }
                nov3[v] = 'b';
            }

        }
        public Dictionary<string, char> color;
        public Dictionary<string, string> pi;
        public int count_edge;
        public void DFS_color()
        {
            color = new Dictionary<string, char>();
            pi = new Dictionary<string, string>();
            count_edge = 0;
            bool f = false;
            foreach (string u in graph.Keys)
            {
                color[u] = 'w';
                pi[u] = null;
                }
            foreach (string u in graph.Keys)
            {
                if (color[u] == 'w')
                {
                   DFS_visit_color(u, ref f);
                }
            }
            if (f)
            {
                Console.WriteLine("Ни то ни другое");
            }
            else
            {
                if (count_edge == graph.Keys.Count - 1)
                {
                    Console.WriteLine("Дерево");
                }
                else
                {
                    Console.WriteLine("Лес");
                }
                Console.WriteLine(count_edge);
            }
        }
        public void DFS_visit_color(string u, ref bool f)
        {
            color[u] = 'g';
            foreach (string v in graph[u].NodeN.Keys)
            {
                if (color[v] == 'w')
                {
                    count_edge++;
                    pi[v] = u;
                    DFS_visit_color(v, ref f);
                }
                else if (color[v] == 'g' && !(pi[u] == v))
                {
                    Console.WriteLine("Есть цикл");
                    f = true;
                }
            }
            color[u] = 'b';
        }
        public Dictionary<string, bool> used;
        public Dictionary<string, int> dist;
        public void Nov()
        {
            used = new Dictionary<string, bool>();
            dist = new Dictionary<string, int>();
            foreach (string u in graph.Keys)
            {
                used[u] = false;
                dist[u] = int.MaxValue;
            }
        }
        void bfs(string v, List<string> list, bool ud)
        {
            Queue<string> q = new Queue<string>();
            used[v] = true;
            q.Enqueue(v);
            dist[v] = 0;
            while (!(q.Count == 0))
            {
                string u = q.Dequeue();
                foreach (string w in graph[u].NodeN.Keys)
                {
                    if (!used[w])
                    {
                        used[w] = true;
                        q.Enqueue(w);
                        dist[w] = dist[u] + 1;
                        if (!ud)
                        {
                            if (list.Contains(w))
                            {
                                Console.WriteLine("{0} - {1}", w, dist[w]);
                                ud = true;
                                break;
                            }
                        }
                    }
                }
                if (ud)
                {
                    break;
                }
            }
            if (!ud)
            {
                Console.WriteLine("Не достижима ни одна из вершин");
            }
        }
        public void Task5(List<string> list)
        {
            foreach (string u in graph.Keys)
            {
                Nov();
                bool ud = false;
                Console.Write("{0}: ", u);
                bfs(u, list, ud);
            }
        }

        public Dictionary<string, double> dd;
        public void Initialise_Single_Sourse(string s)
        {
            dd = new Dictionary<string, double>();
            pi = new Dictionary<string, string>();
            foreach (string v in graph.Keys)
            {
                dd[v] = double.MaxValue;
            }
            dd[s] = 0;
        }

        //public void Relax(string u, string v, double w)
        //{
        //    if (dd[v] > d[u] + graph[u].NodeN[v])
        //    {
        //        dd[v] = d[u] + graph[u].NodeN[v];
        //        pi[v] = u;
        //    }
        //}

        //public bool Bellman_Ford(string s)
        //{
        //    Initialise_Single_Sourse(s);
        //    for (int i = 1; i < graph.Keys.Count; i++)
        //    {
        //        foreach (string u in graph.Keys)
        //        {
        //            foreach (string v in graph[u].NodeN.Keys)
        //            {
        //                pi[v] = null;
        //                Relax(u, v, graph[u].NodeN[v]);
        //            }
        //        }
        //    }
        //    foreach (string u in graph.Keys)
        //    {
        //        foreach (string v in graph[u].NodeN.Keys)
        //        {
        //            if (dd[v] > d[u] + graph[u].NodeN[v])
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        public bool TaskBF(string s)
        {
            Initialise_Single_Sourse(s);
            foreach (string u in graph.Keys)
            {
                foreach (string v in graph[u].NodeN.Keys)
                {
                    if (dd[u] != double.MaxValue && dd[u] + graph[u].NodeN[v] < dd[v])
                    {
                        dd[v] = dd[u] + graph[u].NodeN[v];
                    }
                }
            }
            foreach (string u in graph.Keys)
            {
                foreach (string v in graph[u].NodeN.Keys)
                {
                    if (dd[v] > dd[u] + graph[u].NodeN[v])
                    {
                        return false;
                    }
                }
            }
            Print(dd);
            return true;
        }
        public void Print(Dictionary<string, double> dd)
        {
            Console.WriteLine("Расстояние до вершины от источника");

            foreach (string u in graph.Keys)
            {
                if (dd[u] < double.MaxValue)
                {
                    Console.WriteLine("{0} {1}", u, dd[u]);
                }
                else
                {
                    Console.WriteLine("{0} inf", u);
                }
            }
        }

        public bool BF(string s)
        {
            Initialise_Single_Sourse(s);
            foreach (string u in graph.Keys)
            {
                foreach (string v in graph[u].NodeN.Keys)
                {
                    if (dd[u] != double.MaxValue && dd[u] + graph[u].NodeN[v] < dd[v])
                    {
                        dd[v] = dd[u] + graph[u].NodeN[v];
                    }
                }
            }

            foreach (string u in graph.Keys)
            {
                foreach (string v in graph[u].NodeN.Keys)
                {
                    if (dd[v] > dd[u] + graph[u].NodeN[v])
                    {
                        return false;
                    }
                }
            }
            //Print(dd);
            return true;
        }

        public bool TaskBF2(string s, double distance)
        {
            foreach(string u in graph.Keys)
            {
                BF(u);
                Print2(dd, u, s, distance);
            }
            return true;
        }
        public void Print2(Dictionary<string, double> dd, string u, string s, double distance)
        {
            Console.WriteLine("Расстояние до вершины от источника");

            if (dd[s] < distance)
            {
                Console.WriteLine("{0} {1} {2}", s, u, dd[s]);
            }
            else
            {
                Console.WriteLine("{0} inf", u);
            }
        }

        public void Novset()
        {
            nov.Clear();
            foreach (var i in graph)
            {
                nov.Add(i.Key, true);
            }
        }

        public void Dijkstra(string v)
        {
            //Initialise_Single_Sourse(s);
            Novset();
            Dictionary<string, string> p;
            Dictionary<string, double> dd = Dijkstr(v, out p); //запускаем алгоритм Дейкстры
                                                               //анализируем полученные данные и выводим их на экран
            Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v);
            foreach (string i in graph.Keys)
            {
                if (i != v)
                {
                    Console.Write("{0} равна {1}, ", i, dd[i]);
                    Console.Write("путь ");
                    if (dd[i] != double.MaxValue)
                    {
                        Stack<string> items = new Stack<string>();
                        WayDijkstr(v, i, p, ref items);
                        while (!(items.Count == 0))
                        {
                            Console.Write("{0} ", items.Pop());
                        }
                    }
                }

            }
        }
        public bool Dijkstra(string v, double dist)
        {
            //Initialise_Single_Sourse(s);
            Novset();
            Dictionary<string, string> p;
            Dictionary<string, double> dd = Dijkstr(v, out p); //запускаем алгоритм Дейкстры
                                                               //анализируем полученные данные и выводим их на экран
                                                               //Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v);
            double res = 0;
            foreach (string i in graph.Keys)
            {
                if (i != v)
                {
                    res += dd[i];
                }

            }
            if (res < dist)
            {
                Console.WriteLine(v);
                foreach (string i in graph.Keys)
                {
                    if (i != v)
                    {
                        Console.Write("{0} равна {1}, ", i, dd[i]);
                        Console.Write("путь ");
                        if (dd[i] != double.MaxValue)
                        {
                            Stack<string> items = new Stack<string>();
                            WayDijkstr(v, i, p, ref items);
                            while (!(items.Count == 0))
                            {
                                Console.Write("{0} ", items.Pop());
                            }
                        }
                        Console.WriteLine();
                    }
                }
                return true;
            }
            return false;
        }
        public Dictionary<string, double> Dijkstr(string v, out Dictionary<string, string> p)
        {
            int Size = graph.Keys.Count;
            nov[v] = false; // помечаем вершину v как просмотренную
                            //создаем матрицу с
            Dictionary<string, Node> c = new Dictionary<string, Node>();
            foreach (string i in graph.Keys)
            {
                c.Add(i, new Node());
                foreach (string u in graph.Keys)
                {
                    if (!graph[i].NodeN.ContainsKey(u) || i == u)
                    {
                        c[i].Add(u, double.MaxValue);
                    }
                    else
                    {
                        c[i].Add(u, graph[i].GetNode[u]);
                    }
                }
            }
            //создаем матрицы d и p
            Dictionary<string, double> dd = new Dictionary<string, double>();
            p = new Dictionary<string, string>();
            //foreach(string u in graph[v].NodeN.Keys)
            foreach (string u in graph.Keys)
            {
                if (u != v)
                {
                    dd[u] = c[v].NodeN[u];
                    p[u] = v;
                }
                dd[v] = double.MaxValue;
            }
            for (int i = 0; i < Size - 1; i++) // на каждом шаге цикла
            {
                // выбираем из множества V\S такую вершину w, что D[w] минимально
                double min = double.MaxValue;
                string w = v;
                foreach (string u in graph.Keys)
                {
                    if (nov[u] && min > dd[u])
                    {
                        min = dd[u];
                        w = u;
                    }
                }
                nov[w] = false; //помещаем w в множество S
                                //для каждой вершины из множества V\S определяем кратчайший путь от
                                // источника до этой вершины
                foreach (string u in graph.Keys)
                {
                    if (u != v)
                    {
                        double distance = dd[w] + c[w].NodeN[u];
                        if (nov[u] && dd[u] > distance)
                        {
                            dd[u] = distance;
                            p[u] = w;
                        }
                    }
                }
            }
            return dd; //в качестве результата возвращаем массив кратчайших путей для
        } //заданного источника
          //восстановление пути от вершины a до вершины b для алгоритма Дейкстры
        public void WayDijkstr(string a, string b, Dictionary<string, string> p, ref Stack<string> items)
        {
            items.Push(b); //помещаем вершину b в стек
            if (a == p[b]) //если предыдущей для вершины b является вершина а, то
            {
                items.Push(a); //помещаем а в стек и завершаем восстановление пути
            }
            else //иначе метод рекурсивно вызывает сам себя для поиска пути
            { //от вершины а до вершины, предшествующей вершине b
                WayDijkstr(a, p[b], p, ref items);
            }
        }

        public void TaskD(double dist)
        {
            bool f = false;
            bool tmp;
            foreach (string v in graph.Keys)
            {
                tmp = Dijkstra(v, dist);
                if (tmp)
                {
                    f = true;
                }
            }
            if (!f)
            {
                Console.WriteLine("Нет таких вершин");
            }
        }

        public void Floyd()
        {
            Dictionary<string, Dictionary<string, string>> pp;
            Dictionary<string, Node> a = Floyd(out pp); //запускаем алгоритм Флойда
            //анализируем полученные данные и выводим их на экран
            foreach (string i in graph.Keys)
            {
                foreach (string j in graph.Keys)
                {
                    if (i != j)
                    {
                        if (a[i].NodeN[j] == double.MaxValue)
                        {
                            Console.WriteLine("Пути из вершины {0} в вершину {1} не существует", i, j);
                        }
                        else
                        {
                            Console.Write("Кратчайший путь от вершины {0} до вершины {1} равен {2}, ", i, j, a[i].NodeN[j]);
                            Console.Write(" путь ");
                            Queue<string> items = new Queue<string>();
                            items.Enqueue(i);
                            WayFloyd(i, j, pp, ref items);
                            items.Enqueue(j);
                            while (!(items.Count == 0))
                            {
                                Console.Write("{0} ", items.Dequeue());
                            }
                            Console.WriteLine();
                        }
                    }

                }

            }
        }

        public Dictionary<string, Node> Floyd(out Dictionary<string, Dictionary<string, string>> pp)
        {
            //создаем массивы рp и а
            Dictionary<string, Node> a = new Dictionary<string, Node>();
            pp = new Dictionary<string, Dictionary<string, string>>();
            foreach (string i in graph.Keys)
            {
                a.Add(i, new Node());
                pp.Add(i, new Dictionary<string, string>());
                foreach (string j in graph.Keys)
                {
                    if (i == j)
                    {
                        if (graph[i].GetNode.ContainsKey(j))
                        {
                            a[i].Add(j, graph[i].GetNode[j]);
                        }
                        a[i].Add(j, 0);
                    }
                    else if (graph[i].NodeN.ContainsKey(j))
                    {
                        a[i].Add(j, graph[i].GetNode[j]);
                    }
                    else
                    {
                        a[i].Add(j, double.MaxValue);
                    }
                    pp[i].Add(j, "-1");
                }
            }
            //осуществляем поиск кратчайших путей
            foreach (string k in graph.Keys)
            {
                foreach (string i in graph.Keys)
                {
                    foreach (string j in graph.Keys)
                    {
                        double distance;

                        distance = a[i].NodeN[k] + a[k].NodeN[j];
                        if (a[i].NodeN[k] == double.MaxValue || a[k].NodeN[j] == double.MaxValue)
                        {
                            distance = double.MaxValue;
                        }
                        //if (distance < 0)
                        //{
                        //    a[i].NodeN[j] = distance;
                        //    pp[i].Remove(j);
                        //    pp[i].Add(j, "-1");
                        //}
                        //else
                        if (a[i].NodeN[j] > distance)
                        {
                            if (distance < 0)
                            {
                                a[i].NodeN[j] = double.MinValue;
                            }
                            else
                            {
                                a[i].NodeN[j] = distance;
                            }
                            pp[i].Remove(j);
                            pp[i].Add(j, k);
                        }
                    }
                }
            }
            return a;//в качестве результата возвращаем массив кратчайших путей между
        } //всеми парами вершин
          //восстановление пути от вершины a до вершины в для алгоритма Флойда
        public void WayFloyd(string a, string b, Dictionary<string, Dictionary<string, string>> pp, ref Queue<string> items)
        {
            string k = pp[a][b];
            //если k<> -1, то путь состоит более чем из двух вершин а и b, и проходит через
            //вершину k, поэтому
            if (k != "-1")
            {
                //if (k == a || k == b)
                //{
                //    Console.WriteLine("INF");
                //    return;
                //}
                if (a == k & graph[a].NodeN.ContainsKey(k) || b == k & graph[k].NodeN.ContainsKey(b))
                {
                    Console.WriteLine("INF");
                    return;
                }
                if (!graph[a].NodeN.ContainsKey(k) || !graph[k].NodeN.ContainsKey(b))
                {
                    return;
                }
                else
                {
                    // рекурсивно восстанавливаем путь между вершинами а и k
                    WayFloyd(a, k, pp, ref items);
                    items.Enqueue(k); //помещаем вершину к в очередь
                                      // рекурсивно восстанавливаем путь между вершинами k и b
                    WayFloyd(k, b, pp, ref items);
                }
            }
        }

        public void TaskF(string u, double dist)
        {
            Dictionary<string, Dictionary<string, string>> pp;
            Dictionary<string, Node> a = Floyd(out pp); //запускаем алгоритм Флойда
            //анализируем полученные данные и выводим их на экран
            foreach (string i in graph.Keys)
            {
                if (i != u)
                {
                    if (a[i].NodeN[u] <= dist)
                    {
                        Console.Write("Кратчайший путь от вершины {0} до вершины {1} равен {2}, ", i, u, a[i].NodeN[u]);
                        Console.Write(" путь ");
                        Queue<string> items = new Queue<string>();
                        items.Enqueue(i);
                        WayFloyd(i, u, pp, ref items);
                        items.Enqueue(u);
                        while (!(items.Count == 0))
                        {
                            Console.Write("{0} ", items.Dequeue());
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        public void TaskF2(string u)
        {
            Dictionary<string, Dictionary<string, string>> pp;
            Dictionary<string, Node> a = Floyd(out pp); //запускаем алгоритм Флойда
            //анализируем полученные данные и выводим их на экран
            foreach (string i in graph.Keys)
            {
                if (i != u)
                {
                    Console.Write("Кратчайший путь от вершины {0} до вершины {1} равен {2}, ", u, i, a[u].NodeN[i]);
                    Console.Write(" путь ");
                    Queue<string> items = new Queue<string>();
                    items.Enqueue(u);
                    WayFloyd(u, i, pp, ref items);
                    items.Enqueue(i);
                    while (!(items.Count == 0))
                    {
                        Console.Write("{0} ", items.Dequeue());
                    }
                    Console.WriteLine();
                }
            }
        }
        public void TaskMP(string start, string end)
        {
            Dictionary<string, Node> mx = new Dictionary<string, Node>();
            Dictionary<string, string> p = new Dictionary<string, string>();
            string u, v;
            double mMP = 0;

            foreach (string i in graph.Keys)
            {
                mx.Add(i, new Node());
                foreach (string j in graph.Keys)
                {
                    if (i == j)
                    {
                        mx[i].Add(j, 0);
                    }
                    else if (graph[i].NodeN.ContainsKey(j))
                    {
                        mx[i].Add(j, graph[i].GetNode[j]);
                    }
                    else
                    {
                        mx[i].Add(j, 0);
                    }
                }
            }
            bool lastIter = bfsMP(mx, start, end, p);
            while (lastIter)
            {
                double pMP = double.MaxValue;
                for (v = end; v != start;)
                {
                    u = p[v];
                    pMP = pMP < mx[u].NodeN[v] ? pMP : mx[u].NodeN[v];
                    v = p[v];
                }
                for (v = end; v != start;)
                {
                    u = p[v];
                    mx[u].GetNode[v] -= pMP;
                    mx[v].GetNode[u] += pMP;
                    v = p[v];
                }
                mMP += pMP;
                lastIter = bfsMP(mx, start, end, p);
            }
            Console.WriteLine(mMP);
        }
        public bool bfsMP(Dictionary<string, Node> mx, string s, string t, Dictionary<string, string> p)
        {Dictionary<string, bool> used = new Dictionary<string, bool>();
            foreach (string i in graph.Keys)
            {
                used[i] = false;
            }
            Queue<string> q = new Queue<string>();
            q.Enqueue(s);
            used[s] = true;
            p[s] = "-1";
            while(!(q.Count == 0))
            {
                string u = q.Dequeue();
                foreach (string v in graph.Keys)
                {
                    if(!used[v] && mx[u].NodeN[v] > 0)
                    {
                        q.Enqueue(v);
                        p[v] = u;
                        used[v] = true;
                    }
                }
            }
            return used[t];
        }
        public void Prima(string s)
        {
            Dictionary<string, Node> mx = new Dictionary<string, Node>();
            foreach (string i in graph.Keys)
            {
                mx.Add(i, new Node());
                foreach (string j in graph.Keys)
                {
                    if (i == j)
                    {
                        mx[i].Add(j, 0);
                    }
                    else if (graph[i].NodeN.ContainsKey(j))
                    {
                        mx[i].Add(j, graph[i].GetNode[j]);
                    }
                    else
                    {
                        mx[i].Add(j, double.MaxValue);
                    }
                }
            }

            Dictionary<string, bool> used = new Dictionary<string, bool>();
            Dictionary<string, double> min_e = new Dictionary<string, double>();
            Dictionary<string, string> sel_e = new Dictionary<string, string>();

            string st = "";
            bool f = true;

            foreach (string i in graph.Keys)
            {
                if (f) { st = i; }
                used[i] = false;
                min_e[i] = double.MaxValue;
                sel_e[i] = "-1";
            }
            min_e[st] = 0;
            foreach (string i in graph.Keys)
            {
                string v = "-1";
                foreach (string j in graph.Keys)
                {
                    if(!used[j] && (v == "-1" || min_e[j] < min_e[v]))
                    {
                        v = j;
                    }
                }
                if(min_e[v] == double.MaxValue)
                {
                    Console.WriteLine("No MST");
                    return;
                }

                used[v] = true;
                if (sel_e[v] != "-1")
                {
                    Console.WriteLine("{0} {1}", v, sel_e[v]); ;
                }

                foreach(string to in graph.Keys)
                {
                    if (mx[v].NodeN[to] < min_e[to])
                    {
                        min_e[to] = mx[v].NodeN[to];
                        sel_e[to] = v;
                    }
                }
            }
        }
    }
}