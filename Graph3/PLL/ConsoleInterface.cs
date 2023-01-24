using System;
using System.Collections.Generic;
using System.Text;
using Graph3.BLL;
using Graph3.Entities;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Graph3.PLL
{
    internal class ConsoleInterface
    {
        private const string CreateGraph = "CREATE";
        private static readonly string[] CreateGraphArgs = { "DIRECTED", "WEIGHTED" };

        private const string CreateFromFileGraph = "CREATEFILE";
        private static readonly string[] CreateFromFileGraphArgs = { "NAME" };

        private const string DeleteGraph = "DELETE";
        private static readonly string[] DeleteGraphArgs = { "ID" };

        private const string GetGraph = "GET";
        private static readonly string[] GetGraphArgs = { "ID" };

        private const string WriteGraph = "WRITE";
        private static readonly string[] WriteGraphArgs = { "ID", "NAME" };

        private const string AddEdgeGraph = "ADDEDGE";
        private static readonly string[] AddEdgeGraphArgs = { "ID", "NODE1", "NODE2", "WEIGHT" };

        private const string AddNodeGraph = "ADDNODE";
        private static readonly string[] AddNodeGraphArgs = { "ID", "NODE" };

        private const string DeleteEdgeGraph = "DELETEEDGE";
        private static readonly string[] DeleteEdgeGraphArgs = { "ID", "NODE1", "NODE2", "WEIGHT" };

        private const string DeleteNodeGraph = "DELETENODE";
        private static readonly string[] DeleteNodeGraphArgs = { "ID", "NODE" };

        private const string DeleteNodeValueGraph = "DELETENODEVALUE";
        private static readonly string[] DeleteNodeValueGraphArgs = { "ID", "NODE1", "NODE2" };

        private const string GetGraphs = "GETALL";

        private const string Task1 = "TASK1";
        private static readonly string[] Task1Args = { "ID", "NODE" };

        private const string Task2 = "TASK2";
        private static readonly string[] Task2Args = { "ID", "NODE" };

        private const string Task3 = "TASK3";
        private static readonly string[] Task3Args = { "ID" };

        private const string Task4 = "TASK4";
        private static readonly string[] Task4Args = { "ID" };

        private const string DFS = "DFS";
        private static readonly string[] DFSArgs = { "ID", "NODE" };

        private const string BFS = "BFS";
        private static readonly string[] BFSArgs = { "ID", "NODE" };

        private const string Task5 = "TASK5";
        private static readonly string[] Task5Args = { "ID", "NODES" };

        private const string TaskD = "TASKD";
        private static readonly string[] TaskDArgs = { "ID", "DIST" };

        private const string TaskF = "TASKF";
        private static readonly string[] TaskFArgs = { "ID", "NODE", "DIST" };

        private const string TaskF2 = "TASKF2";
        private static readonly string[] TaskF2Args = { "ID", "NODE" };

        private const string Floyd = "FLOYD";
        private static readonly string[] FloydArgs = { "ID" };

        private const string TaskBF = "TASKBF";
        private static readonly string[] TaskBFArgs = { "ID", "NODE" };

        private const string TaskBF2 = "TASKBF2";
        private static readonly string[] TaskBF2Args = { "ID", "NODE", "DIST" };

        private const string TaskMP = "TASKMP";
        private static readonly string[] TaskMPArgs = { "ID", "SOUКСE", "STOCK" };

        private const string Prima = "PRIMA";
        private static readonly string[] PrimaArgs = { "ID", "NODE" };

        private const string Hint = "HINT";
        private const string Exit = "EXIT";

        private const string UnknownCommand = "UNKNOWN COMMAND";
        private const string WrongArgument = "Wrong argument(s)";

        private readonly IGraphLogic _graphLogic;
        public ConsoleInterface(IGraphLogic graphLogic)
        {
            _graphLogic = graphLogic;
        }

        public void Start()
        {
            var data = new Graph();
            var formatter = new BinaryFormatter();
            for (; ; )
            {
                try
                {
                    Console.Write(">>> ");
                    List<String> arguments = new List<String>(Console.ReadLine().Split(" "));
                    string command = arguments[0].ToUpper();
                    arguments.RemoveAt(0);
                    switch (command)
                    {
                        case AddEdgeGraph:
                            if (arguments.Count == AddEdgeGraphArgs.Length)
                            {
                                Console.WriteLine(_graphLogic.AddEdge(Convert.ToInt16(arguments[0]), arguments[1], arguments[2], Convert.ToDouble(arguments[3])));
                            }
                            else if (arguments.Count == AddEdgeGraphArgs.Length - 1)
                            {
                                Console.WriteLine(_graphLogic.AddEdge(Convert.ToInt16(arguments[0]), arguments[1], arguments[2]));
                            }
                            else
                            {
                                Console.WriteLine(WrongArgument);
                            }

                            break;
                        case AddNodeGraph:
                            if (arguments.Count != AddNodeGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_graphLogic.AddNode(Convert.ToInt16(arguments[0]), arguments[1]));
                            }
                            break;
                        case CreateGraph:
                            if (arguments.Count != CreateGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_graphLogic.Create(Convert.ToBoolean(arguments[0]), Convert.ToBoolean(arguments[1])));
                            }
                            break;
                        case CreateFromFileGraph:
                            if (arguments.Count != CreateFromFileGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_graphLogic.Create(arguments[0]));
                            }
                            break;
                        case DeleteGraph:
                            if (arguments.Count != DeleteGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Delete(Convert.ToInt16(arguments[0]));
                            }
                            break;
                        case DeleteNodeGraph:
                            if (arguments.Count != DeleteNodeGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_graphLogic.DeleteNode(Convert.ToInt16(arguments[0]), arguments[1]));
                            }
                            break;
                        case DeleteEdgeGraph:
                            if (arguments.Count == DeleteEdgeGraphArgs.Length)
                            {
                                Console.WriteLine(_graphLogic.DeleteEdge(Convert.ToInt16(arguments[0]), arguments[1], arguments[2], Convert.ToDouble(arguments[3])));
                            }
                            else if (arguments.Count == DeleteEdgeGraphArgs.Length - 1)
                            {
                                Console.WriteLine(_graphLogic.DeleteEdge(Convert.ToInt16(arguments[0]), arguments[1], arguments[2], 0));
                            }
                            else
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            break;
                        case DeleteNodeValueGraph:
                            if (arguments.Count != DeleteNodeValueGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_graphLogic.DeleteNodeValue(Convert.ToInt16(arguments[0]), arguments[1], arguments[2]));
                            }
                            break;
                        case GetGraph:
                            if (arguments.Count != GetGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Show(Convert.ToInt32(arguments[0]));
                            }
                            break;
                        case WriteGraph:
                            if (arguments.Count != WriteGraphArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Write(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case GetGraphs:
                            Console.WriteLine(String.Join("\n", _graphLogic.FindAll()));
                            break;
                        case Task1:
                            if (arguments.Count != Task1Args.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Task1(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case Task2:
                            if (arguments.Count != Task2Args.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Task2(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case Task3:
                            if (arguments.Count != Task3Args.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_graphLogic.Task3(Convert.ToInt16(arguments[0])));
                            }
                            break;
                        case Task4:
                            if (arguments.Count != Task4Args.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Task4(Convert.ToInt16(arguments[0]));
                            }
                            break;
                        case DFS:
                            if (arguments.Count != DFSArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.DFS(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case BFS:
                            if (arguments.Count != BFSArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.BFS(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case Task5:
                            if (arguments.Count < 2)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                List<string> args = new List<string>(arguments);
                                args.RemoveAt(0);
                                _graphLogic.Task5(Convert.ToInt16(arguments[0]), args);
                            }
                            break;
                        case TaskD:
                            if (arguments.Count != TaskDArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.TaskD(Convert.ToInt16(arguments[0]), Convert.ToDouble(arguments[1]));
                            }
                            break;
                        case Floyd:
                            if (arguments.Count != FloydArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Floyd(Convert.ToInt16(arguments[0]));
                            }
                            break;
                        case TaskF:
                            if (arguments.Count != TaskFArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.TaskF(Convert.ToInt16(arguments[0]), arguments[1], Convert.ToDouble(arguments[2]));
                            }
                            break;
                        case TaskF2:
                            if (arguments.Count != TaskF2Args.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.TaskF2(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case TaskBF:
                            if (arguments.Count != TaskBFArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.TaskBF(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case TaskBF2:
                            if (arguments.Count != TaskBF2Args.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.TaskBF2(Convert.ToInt16(arguments[0]), arguments[1], Convert.ToDouble(arguments[2]));
                            }
                            break;
                        case TaskMP:
                            if (arguments.Count != TaskMPArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.TaskMP(Convert.ToInt16(arguments[0]), arguments[1], arguments[2]);
                            }
                            break;
                        case Prima:
                            if (arguments.Count != PrimaArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                _graphLogic.Prima(Convert.ToInt16(arguments[0]), arguments[1]);
                            }
                            break;
                        case Hint:
                            Console.WriteLine(GetHint());
                            break;
                        case Exit:
                            return;
                        default:
                            Console.WriteLine(UnknownCommand);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        private static String GetHint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(CreateGraph).Append(": ").Append(String.Join(", ", CreateGraphArgs)).Append('\n');
            sb.Append(CreateFromFileGraph).Append(": ").Append(String.Join(", ", CreateFromFileGraphArgs)).Append('\n');
            sb.Append(AddEdgeGraph).Append(": ").Append(String.Join(", ", AddEdgeGraphArgs)).Append('\n');
            sb.Append(AddNodeGraph).Append(": ").Append(String.Join(", ", AddNodeGraphArgs)).Append('\n');
            sb.Append(DeleteEdgeGraph).Append(": ").Append(String.Join(", ", DeleteEdgeGraphArgs)).Append('\n');
            sb.Append(DeleteNodeGraph).Append(": ").Append(String.Join(", ", DeleteNodeGraphArgs)).Append('\n');
            sb.Append(DeleteGraph).Append(": ").Append(String.Join(", ", DeleteGraphArgs)).Append('\n');
            sb.Append(GetGraph).Append(": ").Append(String.Join(", ", GetGraphArgs)).Append('\n');
            sb.Append(WriteGraph).Append(": ").Append(String.Join(", ", WriteGraphArgs)).Append('\n');
            sb.Append(Task1).Append(": ").Append(String.Join(", ", Task1Args)).Append('\n');
            sb.Append(Task2).Append(": ").Append(String.Join(", ", Task2Args)).Append('\n');
            sb.Append(Task3).Append(": ").Append(String.Join(", ", Task3Args)).Append('\n');
            sb.Append(Task4).Append(": ").Append(String.Join(", ", Task4Args)).Append('\n');
            sb.Append(Task5).Append(": ").Append(String.Join(", ", Task5Args)).Append('\n');
            sb.Append(TaskD).Append(": ").Append(String.Join(", ", TaskDArgs)).Append('\n');
            sb.Append(TaskF).Append(": ").Append(String.Join(", ", TaskFArgs)).Append('\n');
            sb.Append(TaskF2).Append(": ").Append(String.Join(", ", TaskF2Args)).Append('\n');
            sb.Append(TaskBF).Append(": ").Append(String.Join(", ", TaskBFArgs)).Append('\n');
            sb.Append(TaskBF2).Append(": ").Append(String.Join(", ", TaskBF2Args)).Append('\n');
            sb.Append(TaskMP).Append(": ").Append(String.Join(", ", TaskMPArgs)).Append('\n');
            sb.Append(Prima).Append(": ").Append(String.Join(", ", PrimaArgs)).Append('\n');
            sb.Append(BFS).Append(": ").Append(String.Join(", ", BFSArgs)).Append('\n');                   
            sb.Append(DFS).Append(": ").Append(String.Join(", ", DFSArgs)).Append('\n');
            sb.Append(Floyd).Append(": ").Append(String.Join(", ", FloydArgs)).Append('\n');
            sb.Append(GetGraphs).Append('\n');
            sb.Append(Hint).Append('\n');
            sb.Append(Exit).Append('\n');

            return sb.ToString();
        }
    }
}
