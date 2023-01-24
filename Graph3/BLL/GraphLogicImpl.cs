using Graph3.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Graph3.BLL;
using Graph3.Entities;
using Graph3.DAL;

namespace Graph3.BLL
{
    internal class GraphLogicImpl : IGraphLogic
    {
        private readonly IGraphRepo _graphRepo;
        public GraphLogicImpl(IGraphRepo graphRepo)
        {
            this._graphRepo = graphRepo;
        }
        public int Create(bool directed, bool weighted)
        {
            Graph graph = new Graph(directed, weighted);
            return _graphRepo.Add(graph);
        }
        public int Create(string name)
        {
            Graph graph = new Graph(name);
            return _graphRepo.Add(graph);
        }
        public bool Delete(int id)
        {
            return _graphRepo.Delete(id);
        }
        public bool DeleteNode(int id, string v)
        {
            return _graphRepo.DeleteNode(id, v);
        }
        public bool AddNode(int id, string v)
        {
            return _graphRepo.AddNode(id, v);
        }
        public bool AddEdge(int id, string v1, string v2, double w)
        {
            return _graphRepo.AddEdge(id, v1, v2, w);
        }
        public bool AddEdge(int id, string v1, string v2)
        {
            return _graphRepo.AddEdge(id, v1, v2, 0);
        }
        public bool DeleteEdge(int id, string u, string v, double w)
        {
            return _graphRepo.DeleteEdge(id, u, v, w);
        }
        public bool DeleteNodeValue(int id, string v, string x)
        {
            Graph g = _graphRepo.Get(id);
            bool res = g.DeleteNode(v, x);
            return res;
        }
        public Graph Find(int id)
        {
            List<Graph> graphs = _graphRepo.GetAll();
            foreach (Graph c in graphs)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }
        public List<Graph> FindAll()
        {
            return _graphRepo.GetAll();
        }
        public void Show(int id)
        {
            _graphRepo.Show(id);
        }
        public void Task1(int id, string v)
        {
            _graphRepo.Task1(id, v);
        }
        public void Task2(int id, string v)
        {
            _graphRepo.Task2(id, v);
        }
        public void Write(int id, string name)
        {
            _graphRepo.Write(id, name);
        }
        public int Task3(int id)
        {
            return _graphRepo.Task3(id);
        }
        public void DFS(int id, string v)
        {
            _graphRepo.DFS(id, v);
        }
        public void BFS(int id, string v)
        {
            _graphRepo.BFS(id, v);
        }
        public void Task4(int id)
        {
            _graphRepo.Task4(id);
        }
        public void Task5(int id, List<string> v)
        {
            _graphRepo.Task5(id, v);
        }
        public void TaskD(int id, double dist)
        {
            _graphRepo.TaskD(id, dist);
        }
        public void Floyd(int id)
        {
            _graphRepo.Floyd(id);
        }
        public void TaskF(int id, string u, double dist)
        {
            _graphRepo.TaskF(id, u, dist);
        }
        public void TaskF2(int id, string u)
        {
            _graphRepo.TaskF2(id, u);
        }
        public void TaskBF(int id, string u)
        {
            _graphRepo.TaskBF(id, u);
        }
        public void TaskBF2(int id, string u, double dist)
        {
            _graphRepo.TaskBF2(id, u, dist);
        }
        public void TaskMP(int id, string u, string v)
        {
            _graphRepo.TaskMP(id, u, v);
        }
        public void Prima(int id, string u)
        {
            _graphRepo.Prima(id, u);
        }
    }
}

