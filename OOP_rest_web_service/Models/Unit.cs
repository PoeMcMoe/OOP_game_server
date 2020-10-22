using Newtonsoft.Json;
using System;
using System.Collections;
using System.Drawing;

namespace OOP_rest_web_service.Models
{
    public class Unit : IEqualityComparer
    {
        public Point position { get; set; }
        // 0 - player, 1 - food
        public int type { get; set; }
        public Color playerColor { get; set; }
        public Size playerSize { get; set; }

        public Unit(Point position, Color color, Size size)
        {
            this.position = position;
            this.type = 0;
            this.playerColor = color;
            this.playerSize = size;
        }

        public Unit(Point position)
        {
            this.position = position;
            this.type = 1;

        }

        public Point getPosition()
        {
            return this.position;
        }
        public int getType()
        {
            return this.type;
        }
        public Color getColor()
        {
            return this.playerColor;
        }
        public Size getSize()
        {
            return this.playerSize;
        }

        public void setPosition(Point position)
        {
            this.position = position;
        }
        public void setColor(Color color)
        {
            this.playerColor = color;
        }
        public void setSize(Size size)
        {
            this.playerSize = size;
        }

        public new bool Equals(object x, object y)
        {
            Unit X = (Unit)x;
            Unit Y = (Unit)y;
            if (X.playerColor == Y.playerColor && X.type == Y.type)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
