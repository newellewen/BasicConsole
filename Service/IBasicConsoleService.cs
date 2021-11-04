using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicConsole.Service
{
    interface IBasicConsoleService
    {
        void AddNewVariable(string name);
        void SetVariableValue(string name, int value);
        void Add(string varName1, string varName2);
        void Add(string varName1, int value);
        void Subtract(string varName1, string varName2);
        void Subtract(string varName1, int value);
        void PrintVariable(string varName);
    }
}
