using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Interpretor
{
    public class NullExpression : Expression
    {
        Expression left, right;

        public NullExpression()
        {

        }

        public override string execute()
        {
            return "Empty string";
        }
    }
}
