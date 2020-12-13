using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models.TemplateStuff
{
    public class SizeUpFood: FoodTemplate
    {
        public SizeUpFood(Point position)
        {
            this.position = position;
        }

        public override bool Equals(Unit other)
        {
            if (other is TemplateFood)
            {
                TemplateFood b = (TemplateFood)other;
                if (this.position == b.getPosition())
                {
                    return true;
                }
            }
            return false;
        }

        public override bool isSizeUp()
        {
            return true;
        }
    }
}
