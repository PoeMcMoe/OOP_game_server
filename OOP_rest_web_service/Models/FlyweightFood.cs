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
        private static Dictionary<Point, Food> foodDictionary = new Dictionary<Point, Food>();

        public static Food GetFood(Point point)
        {
            try
            {
                return foodDictionary[point];
            }
            catch (KeyNotFoundException e)
            {
                Random random = new Random();
                Food food = new Food(point, random.Next(1, 5));
                foodDictionary.Add(point, food);
                return food;
            }
        }
    }
}
