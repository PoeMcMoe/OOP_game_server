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
            if(type == 0)
            {
                return new Player(new Point(), Color.White, new Size());
            }
            else if(type == 1)
            {
                return new Food(new Point(), 1);
            }
            else if(type == 2)
            {
                return new Food(new Point(), 2);
            }
            else
            {
                return null;
            }
        }
    }
}
