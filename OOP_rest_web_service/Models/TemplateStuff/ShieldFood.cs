using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.TemplateStuff
{
   sealed public class ShieldFood : FoodTemplate
    {
        public ShieldFood(Point position)
        {
            this.position = position;
        }

        public override bool Equals(Unit other)
        {
            if (other is Food)
            {
                Food b = (Food)other;
                if (this.position == b.getPosition())
                {
                    return true;
                }
            }
            return false;
        }

        public override bool isShield()
        {
            return true;
        }
    }
}
