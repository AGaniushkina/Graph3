using System;
using System.Collections.Generic;
using System.Text;
using Graph3.Entities;

namespace Graph3.DAL
{
    internal interface IGraphRepo
    {
        int Add(Graph graph);
        List<Graph> GetAll();
        bool Delete(int id);
        Graph Get(int id);
        bool AddEdge(int id, string v, string u, double w);
        bool AddNode(int id, string v);
        bool DeleteNode(int id, string s);
        bool DeleteEdge(int id, string u, string v, double w);
        bool DeleteEdge(int id, string u, string v);
        void Show(int id);
        void Write(int id, string name);
        void Task1(int id, string v);
        void Task2(int id, string v);
        int Task3(int id);
        void DFS(int id, string v);
        void BFS(int id, string v);
        void Task4(int id);
        void Task5(int id, List<string> v);
        void TaskD(int id, double dist);
        void Floyd(int id);
        void TaskF(int id, string u, double dist);
        void TaskF2(int id, string u);
        void TaskBF(int id, string u);
        void TaskBF2(int id, string u, double dist);
        void TaskMP(int id, string u, string v);
        void Prima(int id, string u);
    }
}
