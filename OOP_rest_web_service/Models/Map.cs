using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OOP_rest_web_service.Models
{
    public class Map
    {
        static public List<Unit> players;

        static public List<Unit> food;

        public Map()
        {
            Random rnd = new Random();
            int foodCount = 1;

            players = new List<Unit>();
            players.Add(new Unit(new Point(), Color.White, new Size()));
            players.Add(new Unit(new Point(), Color.White, new Size()));
            players.Add(new Unit(new Point(), Color.White, new Size()));
            players.Add(new Unit(new Point(), Color.White, new Size()));
            players.Add(new Unit(new Point(), Color.White, new Size()));
            players.Add(new Unit(new Point(), Color.White, new Size()));
            players.Add(new Unit(new Point(), Color.White, new Size()));
            players.Add(new Unit(new Point(), Color.White, new Size()));
            food = new List<Unit>();

            //1900 x 1000

            //Spawn initial food
            for (int i = 0; i < foodCount; i++)
            {
                food.Add(new Unit(new Point(rnd.Next(0, 1900), rnd.Next(0, 1000))));
            }

            //food.Add(new Unit(new Point(1, 1)));
        }

        public void addUnit(Unit unit)
        {
            if (unit.getType() == 0)
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
