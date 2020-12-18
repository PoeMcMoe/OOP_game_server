using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public abstract class FoodTemplate : Unit
    {
        //Template method
        public void makeFood()
        {
            color = Color.Black;
            type = 1;
            if (isConfuse())
            {
                this.type = 2;
            }
            if (isShield())
            {
                type = 3;
            }
            if (isSizeUp())
            {
                type = 4;
            }
            if (isSizeDown())
            {
                type = 5;
            }
        }

        public Color GetColor()
        {
            return color;
        }

        public void SetColor(Color col)
        {
            color = col;
        }
        virtual public bool isConfuse() { return false; }
        virtual public bool isShield() { return false; }
        virtual public bool isSizeUp() { return false; }
        virtual public bool isSizeDown() { return false; }

    }
}
