using OOP_rest_web_service.Interfaces;
using OOP_rest_web_service.Models.TemplateStuff;
using OOP_rest_web_service.Visitors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class FlyweightFood
    {

    private static Dictionary<Point, Unit> foodDictionary = new Dictionary<Point, Unit>();

        public static Unit GetFood(Point point, int mode)
        { 
            Visitor visitor;
            switch (mode)
            {
                case 1:
                    visitor = new DefaultVisitor();
                    break;
                case 2:
                    visitor = new SimpleVisitor();
                    break;
                case 3:
                    visitor = new MysteryVisitor();
                    break;
                default:
                    throw new Exception("Invalid game mode");
            }

            try
            {
                return foodDictionary[point];
            }
            catch (KeyNotFoundException e)
            {
                Random random = new Random();
                FoodTemplate food = null;
                switch (random.Next(1, 6))
                {
                    case 1:
                        food = new Food(point);
                        food.makeFood();
                        visitor.Visit((Food)food);
                        break;
                    case 2:
                        food = new ConfuseFood(point);
                        food.makeFood();
                        visitor.Visit((ConfuseFood)food);
                        break;
                    case 3:
                        food = new ShieldFood(point);
                        food.makeFood();
                        visitor.Visit((ShieldFood)food);
                        break;
                    case 4:
                        food = new SizeUpFood(point);
                        food.makeFood();
                        visitor.Visit((SizeUpFood)food);
                        break;
                    case 5:
                        food = new SizeDownFood(point);
                        food.makeFood();
                        visitor.Visit((SizeDownFood)food);
                        Debug.WriteLine("YAY");
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