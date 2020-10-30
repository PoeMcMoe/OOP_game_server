using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace OOP_rest_web_service.Models
{
    public class Player : AbstractPlayer
    {
        private Color color;
        private Size size;

        public Player(Point position, Color color, Size size)
        {
            this.position = position;
            this.color = color;
            this.size = size;
        }

        public Color getColor()
        {
            return this.color;
        }
        public Size getSize()
        {
            return this.size;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }
        public void setSize(Size size)
        {
            this.size = size;
        }

        public override bool Equals(Unit other)
        {
            if(other is Player)
            {
                Player b = (Player)other;
                if(this.position == b.getPosition() && this.color == b.getColor() && this.size == b.getSize())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
