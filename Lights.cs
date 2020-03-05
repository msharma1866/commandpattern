using System;
using System.Collections.Generic;

namespace LightsCommand
{
    public abstract class LightsCommand
    {
        public abstract void Execute();
    }

    public class Lights
    {
        public void TurnOnLights()
        {
            System.Console.WriteLine("Lights ON");
        }

        public void TurnOffLights()
        {
            System.Console.WriteLine("Lights Off");
        }
    }

    public class FlipUpCommand : LightsCommand
    {
        Lights _lights;
        public FlipUpCommand(Lights lights)
        {
            this._lights = lights;
        }
        public override void Execute()
        {
            _lights.TurnOnLights();
        }
    }

    public class FlipDownCommand : LightsCommand
    {
        Lights _lights;
        public FlipDownCommand(Lights lights)
        {
            this._lights = lights;
        }
        public override void Execute()
        {
            _lights.TurnOffLights();
        }
    }

    public class Invoker
    {
        List<LightsCommand> commands = new List<LightsCommand>();
        public void StoreAndExecute(LightsCommand command)
        {
            commands.Add(command);
            command.Execute();            
        }
    }
}