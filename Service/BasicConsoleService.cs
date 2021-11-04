using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BasicConsole.Configuration;

namespace BasicConsole.Service
{
    public class BasicConsoleService : IBasicConsoleService
    {
        private readonly BasicConsoleOptions _basicConsoleOptions;
        public List<Tuple<string, int?>> Variables { get; private set; }

        public BasicConsoleService(IOptions<BasicConsoleOptions> basicConsoleOptions)
        {
            _basicConsoleOptions = basicConsoleOptions.Value;
        }

        public void AddNewVariable(string name)
        {

        }

        public void SetVariableValue(string name, int value)
        {

        }
        public void Add(string varName1, string varName2)
        {

        }
        public void Add(string varName1, int value)
        {

        }
        public void Subtract(string varName1, string varName2)
        {

        }
        public void Subtract(string varName1, int value)
        {

        }
        public void PrintVariable(string varName)
        {

        }

    }
}
