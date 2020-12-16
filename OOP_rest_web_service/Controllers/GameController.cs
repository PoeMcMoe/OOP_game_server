using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using OOP_rest_web_service.Models;
using OOP_rest_web_service.Models.Interpretor;

namespace OOP_rest_web_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [Route("commandline")]
        [HttpPost]
        public string CommandLine([FromBody] string content)
        {
            string[] tokens = content.Split(" ");

            Expression expression = ExpressionFactory.getExpression(tokens);

            return expression.execute();
        }
        // GET: api/Game
        //Gets everything
        [HttpGet]
        public List<UnitData> Get()
        {
            //Debug.WriteLine("DEBUGINAM: ");

            /*List<UnitData> list = new List<UnitData>();
            foreach (Unit f in Map.getInstance().getFood())
            {
                list.Add(new UnitData { position = f.getPosition(), type = f.getType() });
            }
            
            for (int i = 0; i < Map.getInstance().getPlayers().Count; i++)
            {
                AbstractPlayer p = (AbstractPlayer)Map.getInstance().getPlayers()[i];
                list.Add(new UnitData { position = p.getPosition(), type = 0, playerColor = p.getColor(), playerSize = p.getSize(), confused = p.isConfused() });
            }
            */
            List<UnitData> list = new List<UnitData>();
            foreach(Unit u in Map.getInstance().getUnits())
            {
                if(u.getType() == 0)
                {
                    AbstractPlayer p = (AbstractPlayer)u;
                    list.Add(new UnitData { position = p.getPosition(), type = 0, playerColor = p.getColor(), playerSize = p.getSize(), confused = p.isConfused() });
                }
                else
                {
                    list.Add(new UnitData { position = u.getPosition(), type = u.getType() });
                }
            }
            return list;
        }

        [Route("players")]
        [HttpGet]
        public List<UnitData> GetPlayers()
        {
            List<UnitData> list = new List<UnitData>();
            for (int i = 0; i < Map.getInstance().getPlayers().Count; i++)
            {
                AbstractPlayer p = (AbstractPlayer)Map.getInstance().getPlayers()[i];
                list.Add(new UnitData { position = p.getPosition(), type = 0, playerColor = p.getColor(), playerSize = p.getSize(), confused = p.isConfused(), foodListChanged = p.getFoodListChanged() });
            }

            return list;
        }

        [Route("food")]
        [HttpGet]
        public List<UnitData> GetFood()
        {
            List<UnitData> list = new List<UnitData>();
            foreach (Unit f in Map.getInstance().getFood())
            {
                list.Add(new UnitData { position = f.getPosition(), type = f.getType() });
            }
            return list;
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Game/rewind
        [Route("rewind/{colorname}/{command}")]
        [HttpGet]
        public void Rewind(string command, string colorname)
        {
            Color playerColor = Color.FromName(colorname);
            int index = Startup.allColors.IndexOf(playerColor);
            Player player = (Player)Map.getInstance().getPlayers()[index];
            if(command == "set")
            {
                RewindCommand rew = new RewindCommand(player);
                Startup.commandInvoker.SetCommand(rew);
                Startup.commandInvoker.ExecuteCommand();
            }
            if (command == "trigger" && Startup.commandInvoker.CommandExists())
            { 
                Startup.commandInvoker.UndoCommand();
            }
        }

        // POST: api/Game
        [HttpPost]
        public void Post([FromBody]string unit)
        {
            UnitData un = JsonConvert.DeserializeObject<UnitData>(unit);
            if(un.position.X == -9999 && un.position.Y == -9999)
            {
                un.playerColor = ChooseColor();
            }

            if (un.playerColor == Color.White) { return; }

            int index = Startup.allColors.IndexOf(un.playerColor);

            AbstractPlayer mapUnit = (AbstractPlayer)UnitCreator.createUnit(0);
            mapUnit.setPosition(un.position);
            mapUnit.setColor(un.playerColor);
            mapUnit.setConfused(false);

            AbstractPlayer playerFromMap = (AbstractPlayer)Map.getInstance().getPlayers()[index];
            mapUnit.setSize(playerFromMap.getSize());

            Startup.lastPosts[GetIndex(mapUnit.getColor())] = DateTime.Now;

            if (Map.getInstance().GetPlayer(index).getColor() != Color.White)
            {
                AbstractPlayer player = (AbstractPlayer)Map.getInstance().getPlayers()[index];
                player.setPosition(mapUnit.getPosition());
                player.setConfused(false);
                player.setFoodListChangedFalse();

                Map.getInstance().setPlayer(index, player);
            }
            else
            {
                mapUnit.setSize(new Size(20, 20));
                Map.getInstance().register(mapUnit);
                Map.getInstance().setPlayer(GetIndex(mapUnit.getColor()), mapUnit);
            }
            CheckCollisions();

        }

        public void CheckCollisions()
        {
            List<AbstractPlayer> players = Map.getInstance().getPlayers().Cast<AbstractPlayer>().ToList();
            //Player somePlayer = (Player)players[1];
            //Debug.WriteLine("Some player color: " + somePlayer.getColor());
            //List<Food> food = Map.getInstance().getFood().Cast<Food>().ToList();

            List<FoodTemplate> food = new List<FoodTemplate>();
            foreach (Unit u in Map.getInstance().getFood())
            {
                FoodTemplate f = (FoodTemplate)u;
                food.Add(f);
            }

            for (int i = 0; i < 8; i++)
            {
                if (players[i].getColor() != Color.White && Startup.allHitboxes[i] == true)
                {
                    int x1 = players[i].getPosition().X;
                    int x2 = players[i].getPosition().X + players[i].getSize().Width;
                    int y1 = players[i].getPosition().Y;
                    int y2 = players[i].getPosition().Y + players[i].getSize().Height;
                    //Debug.WriteLine("Pradzia x1: " + x1 + " x2: " + x2 + " y1: " + y1 + " y2: " + y2);


                    for (int j = 0; j < food.Count; j++)
                    {
                        if (food[j] == null)
                        {
                            continue;
                        }
                        int fx1 = food[j].getPosition().X - 10 / 2;
                        int fx2 = food[j].getPosition().X + 10 / 2;
                        int fy1 = food[j].getPosition().Y - 10 / 2;
                        int fy2 = food[j].getPosition().Y + 10 / 2;

                        Debug.WriteLine("Food x1 {0}, y1 {1}  \nPlayer x1 {2}  y1 {3}", fx1, fy1, x1, y1);
                        if (doOverlap(new Point(x1, y2), new Point(x2, y1), new Point(fx1, fy2), new Point(fx2, fy1)))
                        {

                            Debug.WriteLine("OVERLAP DETECTED");

                            //Debug.WriteLine("Overlapped x1: " + x1 + " x2: " + x2 + " y1: " + y1 + " y2: " + y2);
                            Unit newFood = UnitCreator.createUnit(1);

                            if (Map.getInstance().getFood()[j].getType() == 2)
                            {
                                players[i].setConfused(true);
                                newFood = UnitCreator.createUnit(2);
                            }

                            else if (Map.getInstance().getFood()[j].getType() == 3)
                            {

                                AbstractPlayer shield = new Shield(players[i]);
                                players[i] = shield;
                            }
                            else if (Map.getInstance().getFood()[j].getType() == 4)
                            {
                                AbstractPlayer sizeUp = new SizeUp(players[i]);
                                players[i] = sizeUp;
                            }

                            else if (Map.getInstance().getFood()[j].getType() == 5)
                            {
                                AbstractPlayer sizeDown = new SizeDown(players[i]);
                                players[i] = sizeDown;
                            }

                            Random rnd = new Random();
                            newFood.setPosition(new Point(rnd.Next(0, 1900), rnd.Next(0, 1000)));
                            Map.getInstance().RemoveFood(j);
                            Map.getInstance().putFood(newFood, j);
                            //Map.getInstance().notifyObservers();

                            players[i].setSize(new Size(players[i].getSize().Width + 5, players[i].getSize().Height + 5));
                            Map.getInstance().setPlayer(i, players[i]);

                        }
                    }

                    for (int j = 0; j < 8; j++)
                    {
                        if (i != j && players[i].getColor() != Color.White && players[j].getColor() != Color.White)
                        {
                            if (players[j].getPosition().X >= x1 && players[j].getPosition().X <= x2 && players[j].getPosition().Y >= y1 && players[j].getPosition().Y >= y2)
                            {
                                if (players[i].getSize().Width > players[j].getSize().Width)
                                {
                                    Map.getInstance().setPlayer(j, UnitCreator.createUnit(0));
                                    players[i].setSize(new Size(players[i].getSize().Width + 15, players[i].getSize().Height + 15));
                                    Map.getInstance().setPlayer(i, players[i]);
                                }
                                else if (players[i].getSize().Width < players[j].getSize().Width)
                                {
                                    Map.getInstance().setPlayer(i, UnitCreator.createUnit(0));
                                    players[j].setSize(new Size(players[j].getSize().Width + 15, players[j].getSize().Height + 15));
                                    Map.getInstance().setPlayer(j, players[j]);
                                }
                            }
                        }
                    }
                }
            }
        }

        // Returns true if two rectangles (l1, r1) and (l2, r2) overlap 
        bool doOverlap(Point l1, Point r1, Point l2, Point r2)
        {
            // If one rectangle is on left side of other 
            if (l1.X >= r2.X || l2.X >= r1.X)
                return false;

            // If one rectangle is above other 
            if (l1.Y <= r2.Y || l2.Y <= r1.Y)
                return false;

            return true;
        }


        int GetIndex(Color color)
        {
            return Startup.allColors.IndexOf(color);
        }
        

        // PUT: api/Game/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        Color ChooseColor()
        {
            Color playerColor;

            Random rnd = new Random();

            while(playerColor == Color.Empty)
            {
                Color checkingColor = Startup.allColors[rnd.Next(0, Startup.allColors.Count - 1)];
                if(Map.getInstance().getPlayers().Cast<Player>().Any(x =>  x.getColor() != checkingColor))
                {
                    playerColor = checkingColor;
                }

            }

            return playerColor;
        }
    }
}
