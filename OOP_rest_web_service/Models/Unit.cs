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

        //Food/Player
        protected Point position;

        protected int type;

        protected bool confused = false;

        protected bool sizingUp = false;

        protected bool sizingDown = false;

        protected bool eatenNormal = false;

        public int index;

        public Color color;

        //Food/Player
        public virtual Point getPosition()
        {
            return this.position;
        }

        //Food/Player
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

        //Food/Player
        public int getType() { return type; }

        public void setType(int type) {this.type = type;}
        public bool isConfused() { return confused; }

        public bool isSizingUp() { return sizingUp; }

        public bool isSizingDown() { return sizingDown; }

        public bool isEatenNormal() { return eatenNormal; }

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
