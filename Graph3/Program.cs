using System;
using Graph3.BLL;
using Graph3.DAL;
using Graph3.PLL;

namespace Graph3
{
    internal class Program
    {
        static void Main()
        {
            IGraphRepo graphRepo = new GraphInMemoryRepo();
            IGraphLogic graphLogic = new GraphLogicImpl(graphRepo);
            ConsoleInterface consoleInterface = new ConsoleInterface(graphLogic);
            consoleInterface.Start();
        }
    }
}
