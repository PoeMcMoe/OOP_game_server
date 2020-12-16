using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Interpretor
{
    public class HighscoreExpression : Expression
    {
        Expression right;

        public HighscoreExpression(Expression right)
        {
            this.right = right;
        }

        public HighscoreExpression()
        {
            right = new NullExpression();
        }

        public override string execute()
        {
            string result = "The player with highest score is: ";

            Player highestScore = null;

            foreach (Player player in Map.players)
            {
                
                if (highestScore == null)
                {
                    highestScore = player;
                }
                else if (highestScore.getSize().Height < player.getSize().Height)
                {
                    highestScore = player;
                }
            }

            result = result + string.Format("Color: {0}, Position: ({1}:{2}), Size: {3}  ", highestScore.getColor().Name,
                highestScore.getPosition().X, highestScore.getPosition().Y, highestScore.getSize().Height) + Environment.NewLine;


            return result;
        }
    }
}
