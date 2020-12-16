using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.Interpretor
{
    public class SizeExpression : Expression
    {
        private string[] tokens;
        public SizeExpression(string[] tokens)
        {
            this.tokens = tokens;
        }

        public SizeExpression()
        {
            tokens = null;
        }

        public override string execute()
        {
            foreach (Player player in Map.players)
            {
                if (player.getColor().Name.ToLower() == tokens[1].ToLower())
                {
                    player.setSize(new Size(int.Parse(tokens[2]), int.Parse(tokens[2])));
                }
            }

            string result = string.Format("Changed {0} player to size {1}", tokens[1], tokens[2]);

            return result;
        }
    }
}
