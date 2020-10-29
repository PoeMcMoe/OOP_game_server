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
            else
            {
                return new Food(new Point());
            }
        }
    }
}
