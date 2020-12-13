using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class TemplateFood : FoodTemplate
    {
        public TemplateFood(Point position)
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
    }
}
