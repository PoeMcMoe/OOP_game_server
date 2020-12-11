using OOP_rest_web_service.Models.TemplateStuff;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public static class UnitCreator
    {
        public static Unit createUnit(int type)
        {
            if (type == 0)
            {
                return new Player(new Point(), Color.White, new Size());
            }
            //normal food
            else if (type == 1)
            {
                TemplateFood food = new TemplateFood(new Point());
                food.makeFood();
                return food;
            }
            //confuse food
            else if (type == 2)
            {

                ConfuseFood food = new ConfuseFood(new Point());
                food.makeFood();
                return food;
            }
            //shield
            else if (type == 3)
            {

                ShieldFood food = new ShieldFood(new Point());
                food.makeFood();
                return food;
            }
            //size up
            else if (type == 4)
            {
                SizeUpFood food = new SizeUpFood(new Point());
                food.makeFood();
                return food;
            }
            //size down
            else if (type == 5)
            {
                SizeDownFood food = new SizeDownFood(new Point());
                food.makeFood();
                return food;
            }
            else
            {
                return null;
            }
        }
    }
}
