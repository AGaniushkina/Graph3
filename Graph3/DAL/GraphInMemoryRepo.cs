using System;
using System.Collections.Generic;
using System.Text;
using Graph3.Entities;

namespace Graph3.DAL
{
    internal class GraphInMemoryRepo : IGraphRepo
    {
        private readonly List<Graph> _graphs;
        private int _counter;
        public GraphInMemoryRepo()
        {
            _graphs = new List<Graph>(0);
            _counter = 0;
        }
        public int Add(Graph graph)
        {
            if (graph.Id.Equals(0))
            {
                graph.Id = ++_counter;
                _graphs.Add(graph);
                return graph.Id;
            }
            throw new Exception("Graph already exists");
        }
        public Graph Get(int id)
        {
            return _graphs[id];
        }
        public bool Delete(int id)
        {
            if (_graphs.Count > id)
            {
                _graphs.RemoveAt(id);
                return true;
            }
            return false;
        }
        public List<Graph> GetAll()
        {
            return _graphs;
        }
        public void PrintAll()
        {
            if (_counter == 0) throw new Exception("No Graphs Yet");
            foreach (Graph graph in _graphs)
            {
                Console.WriteLine(graph.Id);
                graph.Show();
            }
        }
        public bool AddEdge(int id, string u, string v, double w)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    if (!(_graphs[i].Weighted))
                    {
                        if (w != 0)
                        {
                            Console.WriteLine("Graph isn't weighted. ");
                        }
                        return _graphs[i].Add(u, v, 0);
                    }
                    return _graphs[i].Add(u, v, w);
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool AddNode(int id, string s)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].AddNode(s);
                    return true;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool DeleteEdge(int id, string u, string v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    return _graphs[i].DeleteNode(u, v);
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool DeleteEdge(int id, string u, string v, double w)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    return _graphs[i].DeleteNode(u, v);
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public bool DeleteNode(int id, string s)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    return _graphs[i].Delete(s);
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Show(int id)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Show();
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Write(int id, string name)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Write(name);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Task1(int id, string v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Task1(v);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Task2(int id, string v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Task2(v);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public int Task3(int id)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                   Graph graph = _graphs[i].Task3();
                    graph.Id = ++_counter;
                    _graphs.Add(graph);
                    return graph.Id;
                    
                }
            }
            throw new Exception("ERROR: Wrong ID");

        }
        public void DFS(int id, string v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].DFS(v);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void BFS(int id, string v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].BFSPrint(v);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Task4(int id)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Task4();
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");

        }
        public void Task5(int id, List<string> v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Task5(v);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void TaskD(int id, double dist)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].TaskD(dist);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Floyd(int id)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Floyd();
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void TaskF(int id, string u, double dist)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].TaskF(u, dist);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void TaskF2(int id, string u)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].TaskF2(u);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void TaskBF(int id, string u)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].TaskBF(u);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void TaskBF2(int id, string u, double dist)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].TaskBF2(u, dist);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void TaskMP(int id, string u, string v)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].TaskMP(u, v);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
        public void Prima(int id, string u)
        {
            for (int i = 0; i < _graphs.Count; i++)
            {
                if (_graphs[i].Id == id)
                {
                    _graphs[i].Prima(u);
                    return;
                }
            }
            throw new Exception("ERROR: Wrong ID");
        }
    }
}
