using Newtonsoft.Json;
using OOP_rest_web_service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_rest_web_service.Models
{
    public class Map : ISubject
    {
        public int mode = -1;

        //singleton
        private static Map instance = new Map();

        static public List<Unit> players;

        static public Unit[] food;

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

            int foodCount = 50;
            food = new Unit[foodCount];

            players = new List<Unit>();
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));
            players.Add(UnitCreator.createUnit(0));

            //1900 x 1000

            //Spawn initial food
            //food with 2 makes player 'confused'

            //Food clonedFoodItem;
            //for (int i = 0; i < foodCount; i++)
            //{
            //    if (i % 10 == 0)
            //    {
            //        clonedFoodItem = (Food)cloneFactory.getClone(confuseFoodItem);
            //    }
            //    else
            //    {
            //        clonedFoodItem = (Food)cloneFactory.getClone(foodItem);
            //    }
            //    Debug.WriteLine("Food clone hash: " + clonedFoodItem.GetHashCode());
            //    clonedFoodItem.setPosition(new Point(rnd.Next(1, 1899), rnd.Next(1, 999)));
            //    food.Add(clonedFoodItem);
            //}


            //Unit shield;
            //shield = UnitCreator.createUnit(3);
            //shield.setPosition(new Point(50, 50));

            //food.Add(shield);

            // Unit sizeUp;
            // sizeUp = UnitCreator.createUnit(4);
            // sizeUp.setPosition(new Point(100, 100));

            // Unit sizeDown;
            // sizeDown = UnitCreator.createUnit(5);
            // sizeDown.setPosition(new Point(150, 150));

            // food.Add(sizeUp);
            // food.Add(sizeDown);




            //st.Start();
            //for (int i = 0; i < foodCount; i++)
            //{
            //    Unit addFood = UnitCreator.createUnit(1);
            //    addFood.setPosition(new Point(rnd.Next(1, 1899), rnd.Next(1, 999)));
            //    addFood.index = i;
            //    food[i] = addFood;
            //}
            //st.Stop();
            //Debug.WriteLine("Factory took time: " + st.ElapsedMilliseconds);
            //Debug.WriteLine("Factory used memory: " + (GC.GetTotalMemory(false) / 1024) + " kb");
        }

        public void addUnit(Unit unit)
        {
            if (unit is Player)
            {
                players.Add(unit);
            }
        }

        public void addUnit(Unit unit, int i)
        {
            food[i] = unit;
        }

        public IEnumerable<Unit> getUnits()
        {
            foreach(Unit p in players)
            {
                yield return p;
            }

            foreach(Unit f in food)
            {
                yield return f;
            }
        }


        public Unit[] getFood()
        {
            return food;
        }
        public List<Unit> getPlayers()
        {
            return players;
        }
        public AbstractPlayer GetPlayer(int i)
        {
            return (AbstractPlayer)players[i];
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

        public void putFood(Unit f, int i)
        {
            food[i] = f;
        }
        public void addPlayer(Unit player)
        {
            players.Add(player);
        }
        public void setPlayer(int i, Unit player)
        {
            players[i] = player;
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

        public void RemoveFood(int i)
        {
            food[i] = null;
        }

        public void setPlayerPostition(int index, Point location)
        {
            players[index].setPosition(location);
        }
    }
}
