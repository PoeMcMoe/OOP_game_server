using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace OOP_rest_web_service.Models
{
    public class Map
    {
        //singleton
        private static Map instance = new Map();

        static public List<Unit> players;

        static public List<Unit> food;

        public Map()
        {
            initMap();
        }

        public static Map getInstance()
        {
            return instance;
        }

        public void initMap()
        {
            Random rnd = new Random();
            int foodCount = 20;

            players = new List<Unit>();
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            food = new List<Unit>();

            //1900 x 1000

            //Spawn initial food
            //food with 2 makes player 'confused'
            for (int i = 0; i < foodCount; i++)
            {
                Unit newFood;
                if(i % 10 == 0)
                {
                    newFood = UnitCreator.createUnit(2);
                }
                else
                {
                    newFood = UnitCreator.createUnit(1);
                }
                newFood.setPosition(new Point(rnd.Next(1, 1899), rnd.Next(1, 999)));
                food.Add(newFood);
            }
            Unit newFosod;
            newFosod = UnitCreator.createUnit(2);
            newFosod.setPosition(new Point(20, 20));
            food.Add(newFosod);
        }

        public void addUnit(Unit unit)
        {
            if (unit is Player)
            {
                players.Add(unit);
            }
            else
            {
                food.Add(unit);
            }
        }

        public List<Unit> getFood()
        {
            return food;
        }
        public List<Unit> getPlayers()
        {
            return players;
        }
        public Player GetPlayer(int i)
        {
            return (Player)players[i];
        }
        public Food GetFood(int i)
        {
            return (Food)food[i];
        }

        public Unit getFood(int i)
        {
            return food.ElementAt(i);
        }
        public Unit getPlayers(int i)
        {
            return players.ElementAt(i);
        }

        public void addFood(Unit f)
        {
            food.Add(f);
        }
        public void addPlayer(Unit player)
        {
            players.Add(player);
        }

        public void setFood(int i, Unit f)
        {
            food.Insert(i, f);
        }
        public void setPlayer(int i, Unit player)
        {
            players[i] = player;
        }

        public void removeFood(int i)
        {
            food.RemoveAt(i);
        }
        public void removePlayers(int i)
        {
            players.RemoveAt(i);
        }
    }
}
