using System;
using System.Collections.Generic;
using System.Text;
using Graph3.Entities;

namespace Graph3.BLL
{
    internal interface IGraphLogic
    {
        int Create(bool directed, bool weighted);
        int Create(string name);
        Graph Find(int id);
        List<Graph> FindAll();
        bool AddEdge(int id, string v1, string v2, double w);
        bool AddEdge(int id, string v1, string v2);
        bool DeleteNode(int id, string v);
        bool DeleteNodeValue(int id, string v, string x);
        void Show(int id);
        void Write(int id, string name);
        bool AddNode(int id, string v);
        bool Delete(int id);
        bool DeleteEdge(int id, string u, string v, double w);
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
