using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Interpretor
{
    public class GetTypeExpression : Expression
    {
        private string value;

        public GetTypeExpression(string newValue)
        {
            value = newValue;
        }

        public override string execute()
        {
            return value;
        }
	}
}
