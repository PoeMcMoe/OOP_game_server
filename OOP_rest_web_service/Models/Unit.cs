using Newtonsoft.Json;
using System;
using System.Collections;
using System.Drawing;

namespace OOP_rest_web_service.Models
{
    public abstract class Unit : IEquatable<Unit>
    {
        protected Point position;

        public Point getPosition()
        {
            return this.position;
        }

        public void setPosition(Point position)
        {
            this.position = position;
        }

        public abstract bool Equals(Unit other);
    }
}
