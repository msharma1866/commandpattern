
using System;
using System.Collections.Generic;

namespace Command
{

    public abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    // concrete command - binding between receiver object and action like Execute/UnExecute
    public class CalculatorCommand : Command
    {
        public char Operator { get; set; }
        public int Operand { get; set; }
        private Calculator _calculator;
        public CalculatorCommand(Calculator calc, char @operator, int operand)
        {
            _calculator = calc;
            Operator = @operator;
            Operand = operand;
        }
        public override void Execute()
        {
            _calculator.Operation(Operator, Operand);
        }

        public override void UnExecute()
        {
            _calculator.Operation(Undo(Operator), Operand);
        }

        private char Undo(char @op)
        {
            char @_undoOp = 'U';
            switch (@op)
            {
                case '+': _undoOp = '-'; break;
                case '-': _undoOp = '+'; break;
                case '*': _undoOp = '/'; break;
                case '/': _undoOp = '*'; break;
            }
            return @_undoOp;
        }
    }

    // receiver
    public class Calculator
    {
        int val = 0;
        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+': val += operand; break;
                case '-': val -= operand; break;
                case '*': val *= operand; break;
                case '/': val /= operand; break;
            }
            System.Console.WriteLine($"Calculated value is {val}");
        }
    }

    //Invoker - as command to carry out the operation
    public class Invoker
    {
        int _current = 0;
        List<Command> commands = new List<Command>();
        Calculator _calculator = new Calculator();

        public void Compute(char @operator, int operand)
        {
            Command command = new CalculatorCommand(_calculator, @operator, operand);
            command.Execute();

            _current++;
            commands.Add(command);

        }

        public void Undo()
        {
           foreach(Command cmd in commands)
           {
               if(_current >0)
               {
                   _current--;
                   cmd.UnExecute();
               }
           }
        }
    }

}