using Newtonsoft.Json;
using OOP_rest_web_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace OOP_rest_web_service.Models
{
    public class Map : ISubject
    {
        //singleton
        private static Map instance = new Map();

        static public List<Unit> players;

        static public List<Unit> food;

        static private List<IMyObserver> observersList;

        Unit foodItem = UnitCreator.createUnit(1);
        Unit confuseFoodItem = UnitCreator.createUnit(2);

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
            CloneFactory cloneFactory = new CloneFactory();
            observersList = new List<IMyObserver>();
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

            Food clonedFoodItem;
            for (int i = 0; i < foodCount; i++)
            {
                if (i % 10 == 0)
                {
                    clonedFoodItem = (Food)cloneFactory.getClone(confuseFoodItem);
                }
                else
                {
                    clonedFoodItem = (Food)cloneFactory.getClone(foodItem);
                }
                Debug.WriteLine("Food clone hash: " + clonedFoodItem.GetHashCode());
                clonedFoodItem.setPosition(new Point(rnd.Next(1, 1899), rnd.Next(1, 999)));
                food.Add(clonedFoodItem);
            }
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

        public void register(IMyObserver newObserver)
        {
            observersList.Add(newObserver);
        }

        public void unregister(IMyObserver observer)
        {
            observersList.Remove(observer);
        }

        public void notifyObservers()
        {
            for (int i = 0; i < observersList.Count; i++)
            {
                observersList[i].update();

            }
        }

        public void setPlayerPostition(int index, Point location)
        {
            players[index].setPosition(location);
        }
    }
}
