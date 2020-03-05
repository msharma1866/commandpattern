using System;
using LightsCommand;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            LightsCommand.LightsCommand command = new LightsCommand.FlipUpCommand(new Lights());
            new LightsCommand.Invoker().StoreAndExecute(command);
            //Console.WriteLine("Hello World!");

            // Invoker invoker = new Invoker();
            // invoker.Compute('+', 5);
            // invoker.Compute('+', 2);
            // invoker.Compute('+', 10);
            // invoker.Undo();
            // invoker.Undo();
            // invoker.Undo();
        }
    }
}
