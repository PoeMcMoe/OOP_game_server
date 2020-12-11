using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public abstract class FoodTemplate : Unit
    {
        //Template method
        public void makeFood()
        {
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
        virtual public bool isConfuse() { return false; }
        virtual public bool isShield() { return false; }
        virtual public bool isSizeUp() { return false; }
        virtual public bool isSizeDown() { return false; }

    }
}
