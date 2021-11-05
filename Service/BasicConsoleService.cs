using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BasicConsole.Configuration;
using BasicConsole.Model;

namespace BasicConsole.Service
{
    public class BasicConsoleService : IBasicConsoleService
    {
        private readonly BasicConsoleOptions _basicConsoleOptions;
        public List<BasicConsoleModel> Variables { get; private set; }

        public BasicConsoleService(IOptions<BasicConsoleOptions> basicConsoleOptions)
        {
            _basicConsoleOptions = basicConsoleOptions.Value;
            Variables = new List<BasicConsoleModel>();
        }

        public void Run()
        {
            foreach (var command in _basicConsoleOptions.Commands)
            {
                var instructions = command.Split(" ");
                var operation = instructions[0];
                var variableName = instructions[1];

                //With more time I would use reflection to reference specific methods/arguments but ran out of time
                switch (operation.ToLower())
                {
                    //Would also add much better error handling/logging/etc.
                    case "int":
                        AddNewVariable(variableName);
                        break;
                    case "set":
                        var variableValue = int.Parse(instructions[2]);
                        SetVariableValue(variableName, variableValue);
                        break;
                    case "add":
                        if (int.TryParse(instructions[2], out var addValue))
                        {
                            Add(variableName, addValue);
                        }
                        else
                        {
                            var secondVariableName = instructions[2];
                            Add(variableName, secondVariableName);
                        }
                        break;
                    case "sub":
                        if (int.TryParse(instructions[2], out var subtractValue))
                        {
                            Subtract(variableName, subtractValue);
                        }
                        else
                        {
                            var secondVariableName = instructions[2];
                            Subtract(variableName, secondVariableName);
                        }
                        break;
                    case "print":
                        PrintVariable(variableName);
                        break;
                    default:
                        Console.WriteLine($"{operation} is not a valid command.");
                        break;
                }



            }
        }

        public void AddNewVariable(string name)
        {
            if (Variables.Where(v => v.Name == name).Any())
            {
                Console.WriteLine($"The variable {name} already exists.");
            }
            else
            {
                Variables.Add(new BasicConsoleModel { Name = name, Value = null});
            }            
        }

        public void SetVariableValue(string name, int value)
        {
            if (!Variables.Where(v => v.Name == name).Any())
            {
                Console.WriteLine($"The variable {name} does not exist.");
            }
            else
            {
                Variables.Find(v => v.Name == name).Value = value;
            }
        }
        public void Add(string varName1, string varName2)
        {
            var var1 = Variables.First(v => v.Name == varName1);
            var var2 = Variables.First(v => v.Name == varName2);

            if (var1 == null || var2 == null)
            {
                Console.WriteLine($"One or more of the variables provided does not exist: {varName1}, {varName2}");
            }
            else
            {
                Variables.Find(v => v.Name == varName1).Value += var2.Value;
            }
        }
        public void Add(string varName1, int value)
        {
            var var1 = Variables.First(v => v.Name == varName1);

            if (var1 == null)
            {
                Console.WriteLine($"The variable provided does not exist: {varName1}.");
            }
            else
            {
                Variables.Find(v => v.Name == varName1).Value += value;
            }
        }

        public void Subtract(string varName1, string varName2)
        {
            var var1 = Variables.First(v => v.Name == varName1);
            var var2 = Variables.First(v => v.Name == varName2);

            if (var1 == null || var2 == null)
            {
                Console.WriteLine($"One or more of the variables provided does not exist: {varName1}, {varName2}");
            }
            else
            {
                Variables.Find(v => v.Name == varName1).Value -= var2.Value;
            }
        }
        public void Subtract(string varName1, int value)
        {
            var var1 = Variables.First(v => v.Name == varName1);

            if (var1 == null)
            {
                Console.WriteLine($"The variable provided does not exist: {varName1}.");
            }
            else
            {
                Variables.Find(v => v.Name == varName1).Value -= value;
            }
        }

        public void PrintVariable(string varName)
        {
            var var1 = Variables.First(v => v.Name == varName);

            if (var1 == null)
            {
                Console.WriteLine($"The variable provided does not exist: {varName}.");
            }
            else
            {
                Console.WriteLine($"{var1.Name}: {var1.Value} ");
            }
        }

    }
}
