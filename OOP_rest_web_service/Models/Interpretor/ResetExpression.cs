using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Interpretor
{
    public class ResetExpression : Expression
    {
        Expression right;

        public ResetExpression(Expression right)
        {
            this.right = right;
        }

        public ResetExpression()
        {
            right = new NullExpression();
        }

        public override string execute()
        {
            string result = "Map reset";

            foreach (Unit food in Map.food)
            {
                Random rnd = new Random();
                food.setPosition(new Point(rnd.Next(1,1899), rnd.Next(1,999)));
                food.setType(rnd.Next(1,5));
            }

            return result;
        }
    }
}
