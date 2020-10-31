using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class Food : Unit
    {
        public Food(Point position, int type)
        {
            this.position = position;
            this.type = type;
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

        public override Point getPosition()
        {
            return base.getPosition();
        }

        public override void setPosition(Point position)
        {
            base.setPosition(position);
        }
    }
}
