using Newtonsoft.Json;
using OOP_rest_web_service.Interfaces;
using System;
using System.Collections;
using System.Drawing;

namespace OOP_rest_web_service.Models
{
    public abstract class Unit : IEquatable<Unit>, IUnit
    {
        protected string name = "default";

        protected Point position;

        protected int type;

        protected bool confused = false;

        public virtual Point getPosition()
        {
            return this.position;
        }

        public virtual void setPosition(Point position)
        {
            this.position = position;
        }

        public virtual void setName(string name)
        {
            this.name = name;
        }

        public virtual string getName()
        {
            return name;
        }

        public abstract bool Equals(Unit other);

        public int getType() { return type; }
        public bool isConfused() { return confused; }

        public object Clone()
        {
            return (Unit)MemberwiseClone();
        }

        public object CloneDeep()
        {
            Unit unit = (Unit)MemberwiseClone();

            //Add deep cloning logic here if needed

            return unit;
        }
    }
}
