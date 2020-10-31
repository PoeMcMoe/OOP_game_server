using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class SizeUp : PlayerDecorator
    {
        public SizeUp(AbstractPlayer o) : base(o)
        {
        }

        public override Point getPosition()
        {
            return wrappee.getPosition();
        }

        public override void setPosition(Point position)
        {
            wrappee.setPosition(position);
        }

        public override void setName(string name)
        {
            wrappee.setName(name);
        }

        public override string getName()
        {
            return wrappee.getName() + ";SizeUp";
        }

        public override Color getColor()
        {
            return wrappee.getColor();
        }
        public override Size getSize()
        {
            return wrappee.getSize();
        }

        public override void setColor(Color color)
        {
            wrappee.setColor(color);
        }
        public override void setSize(Size size)
        {
            wrappee.setSize(size);
        }

        public override void setConfused(bool confused)
        {
            wrappee.setConfused(confused);
        }
    }
}
