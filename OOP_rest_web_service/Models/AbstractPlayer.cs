using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public abstract class AbstractPlayer : Unit
    {
        protected Color color;
        protected Size size;

        public AbstractPlayer(Point position, Color color, Size size)
        {
            this.position = position;
            this.color = color;
            this.size = size;
        }

        public virtual Color getColor()
        {
            return this.color;
        }
        public virtual Size getSize()
        {
            return this.size;
        }

        public virtual void setColor(Color color)
        {
            this.color = color;
        }
        public virtual void setSize(Size size)
        {
            this.size = size;
        }

        public override bool Equals(Unit other)
        {
            if (other is Player)
            {
                Player b = (Player)other;
                if (this.position == b.getPosition() && this.color == b.getColor() && this.size == b.getSize())
                {
                    return true;
                }
            }
            return false;
        }

        public virtual void setConfused(bool confused)
        {
            this.confused = confused;
        }

        public override void setName(string name)
        {
            base.setName(name);
        }

        public override string getName()
        {
            return base.getName();
        }
    }
}
