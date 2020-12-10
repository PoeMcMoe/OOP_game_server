using OOP_rest_web_service.Models.TemplateStuff;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class FlyweightFood
    {
        private static Dictionary<Point, Unit> foodDictionary = new Dictionary<Point, Unit>();

        public static Unit GetFood(Point point)
        {
            try
            {
                return foodDictionary[point];
            }
            catch (KeyNotFoundException e)
            {
                Random random = new Random();
                FoodTemplate food = null;
                switch (random.Next(1, 5))
                {
                    case 1:
                        food = new Food(point);
                        food.makeFood();
                        break;
                    case 2:
                        food = new ConfuseFood(point);
                        food.makeFood();
                        break;
                    case 3:
                        food = new ShieldFood(point);
                        food.makeFood();
                        break;
                    case 4:
                        food = new SizeUpFood(point);
                        food.makeFood();
                        break;
                    case 5:
                        food = new SizeDownFood(point);
                        food.makeFood();
                        break;
                    default:
                        break;
                }
                foodDictionary.Add(point, food);
                return food;
            }
        }
    }
}