using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Interpretor
{
    public class HelpExpression : Expression
    {
        private string value;

        public HelpExpression(string newValue)
        {
            value = newValue;
        }

        public override string execute()
        {
            return "Available commands: get [players|food]";
        }
    }
}
