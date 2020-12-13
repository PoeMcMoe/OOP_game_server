using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Interpretor
{
    public class GetExpression : Expression
    {
        Expression right;

        public GetExpression(Expression right)
        {
            this.right = right;
        }

        public GetExpression()
        {
            right = new NullExpression();
        }

        public override string execute()
        {
            string result = "";
            if (right.execute() == "players")
            {
                foreach (Player player in Map.players)
                {
                    result = result + string.Format("Color: {0}, Position: ({1}:{2}), Size: {3}  ", player.getColor().Name,
                        player.getPosition().X, player.getPosition().Y, player.getSize().Height) + Environment.NewLine;
                }

            }
            else if (right.execute() == "food")
            {

                foreach (Unit food in Map.food)
                {
                    result = result + string.Format("Position: ({0}:{1})", food.getPosition().X, food.getPosition().Y) + Environment.NewLine;
                }
            }

            return result;
        }
	}
}
