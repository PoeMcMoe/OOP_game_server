using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OOP_rest_web_service.Controllers;
using OOP_rest_web_service.Models;

namespace OOP_rest_web_service
{
    public class Startup
    {
        public static List<bool> allHitboxes;
        public static List<Color> allColors;
        public static List<DateTime> lastPosts;

        int sizeChange = 1;

        Random rnd = new Random();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            allColors = new List<Color>();
            allColors.Add(Color.Red);
            allColors.Add(Color.Blue);
            allColors.Add(Color.Yellow);
            allColors.Add(Color.Green);
            allColors.Add(Color.Pink);
            allColors.Add(Color.Brown);
            allColors.Add(Color.Orange);
            allColors.Add(Color.Violet);

            allHitboxes = new List<bool>();
            for (int i = 0; i < 8; i++)
            {
                allHitboxes.Add(true);
            }

            lastPosts = new List<DateTime>();
            for(int i = 0; i < 8; i++)
            {
                lastPosts.Add(DateTime.MaxValue);
            }

            PeriodicMapCheck(TimeSpan.FromSeconds(0.1));
            PeriodicCollisionCheck(TimeSpan.FromSeconds(0.1));
            CheckForPowerUps(TimeSpan.FromSeconds(0.1));

        }

        public async Task CheckForPowerUps(TimeSpan timeSpan)
        {
            while (true)
            {
                for (int i = 0; i < 8; i++)
                {

                    string[] powerUps = Map.getInstance().GetPlayer(i).getName().Split(";");

                    if (powerUps.Length > 1)
                    {
                        //Debug.WriteLine("Toks string name: " + Map.getInstance().GetPlayer(i).getName());
                        //Debug.WriteLine("Gavau tokius: ");
                        foreach (string p in powerUps)
                        {
                            Debug.Write(p + " ");
                        }
                        Debug.WriteLine("");

                        for (int j = powerUps.Length - 1; j > 0; j--)
                        {
                            if (powerUps[j] == "Shield")
                            {
                                PlayerDecorator playerDecorator = (PlayerDecorator)Map.getInstance().GetPlayer(i);
                                Map.getInstance().setPlayer(i, playerDecorator.getWrappee());
                                //Debug.WriteLine("Toks string name: " + Map.getInstance().GetPlayer(i).getName());
                                PowerUpHitBoxes(i);
                                //Debug.WriteLine("Iejau i Shield: " + j);
                            }
                            else if (powerUps[j] == "SizeUp")
                            {
                                PlayerDecorator playerDecorator = (PlayerDecorator)Map.getInstance().GetPlayer(i);
                                Map.getInstance().setPlayer(i, playerDecorator.getWrappee());
                                //Debug.WriteLine("Toks string name: " + Map.getInstance().GetPlayer(i).getName());
                                PowerUpSize(i);
                                //Debug.WriteLine("Iejau i SizeUp: " + j);
                            }
                            else if (powerUps[j] == "SizeDown")
                            {
                                PlayerDecorator playerDecorator = (PlayerDecorator)Map.getInstance().GetPlayer(i);
                                Map.getInstance().setPlayer(i, playerDecorator.getWrappee());
                               // Debug.WriteLine("Toks string name: " + Map.getInstance().GetPlayer(i).getName());
                                PowerDownSize(i);
                                //Debug.WriteLine("Iejau i SizeDown: " + j);
                            }
                        }
                    }
                }
                await Task.Delay(timeSpan);
            }
        }

        public async Task PowerUpSize(int index)
        {
            Map.getInstance().GetPlayer(index).setSize(new Size(Map.getInstance().GetPlayer(index).getSize().Width + 50, Map.getInstance().GetPlayer(index).getSize().Height + 50));
            await Task.Delay(TimeSpan.FromSeconds(5));
            Map.getInstance().GetPlayer(index).setSize(new Size(Map.getInstance().GetPlayer(index).getSize().Width - 50, Map.getInstance().GetPlayer(index).getSize().Height - 50));
        }

        public async Task PowerDownSize(int index)
        {
            Map.getInstance().GetPlayer(index).setSize(new Size(Map.getInstance().GetPlayer(index).getSize().Width / 2, Map.getInstance().GetPlayer(index).getSize().Height / 2));
            await Task.Delay(TimeSpan.FromSeconds(5));
            Map.getInstance().GetPlayer(index).setSize(new Size(Map.getInstance().GetPlayer(index).getSize().Width * 2, Map.getInstance().GetPlayer(index).getSize().Height * 2));
        }

        public async Task PowerUpHitBoxes(int index)
        {
            allHitboxes[index] = false;
            await Task.Delay(TimeSpan.FromSeconds(5));
            allHitboxes[index] = true;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public async Task PeriodicMapCheck(TimeSpan interval)
        {
            while (true)
            {
                for(int i = 0; i < 8; i++)
                {
                    //Debug.WriteLine(i + ": " + lastPosts[i]);
                    if (DateTime.Now.Subtract(lastPosts[i]) >= TimeSpan.FromSeconds(5))
                    {
                        //Debug.WriteLine("Iejom i if: " + i);
                        Map.getInstance().setPlayer(i, UnitCreator.createUnit(0));
                    }
                }
                await Task.Delay(interval);
            }
        }

        public async Task PeriodicCollisionCheck(TimeSpan interval)
        {
            while (true)
            {
                List<AbstractPlayer> players = Map.getInstance().getPlayers().Cast<AbstractPlayer>().ToList();
                //Player somePlayer = (Player)players[1];
                //Debug.WriteLine("Some player color: " + somePlayer.getColor());
                List<Food> food = Map.getInstance().getFood().Cast<Food>().ToList();

                for (int i = 0; i < 8; i++)
                {
                    if (players[i].getColor() != Color.White && allHitboxes[i] == true)
                    {
                        int x1 = players[i].getPosition().X;
                        int x2 = players[i].getPosition().X + players[i].getSize().Width;
                        int y1 = players[i].getPosition().Y;
                        int y2 = players[i].getPosition().Y + players[i].getSize().Height;
                        //Debug.WriteLine("Pradzia x1: " + x1 + " x2: " + x2 + " y1: " + y1 + " y2: " + y2);


                        for (int j = 0; j < food.Count; j++)
                        {
                            int fx1 = food[j].getPosition().X - 10 / 2;
                            int fx2 = food[j].getPosition().X + 10 / 2;
                            int fy1 = food[j].getPosition().Y - 10 / 2;
                            int fy2 = food[j].getPosition().Y + 10 / 2;


                            if (doOverlap(new Point(x1, y2), new Point(x2, y1), new Point(fx1, fy2), new Point(fx2, fy1)))
                            {
                                //Debug.WriteLine("Overlapped x1: " + x1 + " x2: " + x2 + " y1: " + y1 + " y2: " + y2);
                                Unit newFood = UnitCreator.createUnit(1);

                                if (Map.getInstance().getFood()[j].getType() == 2)
                                {
                                    players[i].setConfused(true);
                                    newFood = UnitCreator.createUnit(2);
                                }

                                else if (Map.getInstance().getFood()[j].getType() == 3)
                                {

                                    //Debug.WriteLine("Neshieldinto playerio pozicija: " + players[i].getPosition());
                                    //Debug.WriteLine("Pries shielda Playeri color: " + players[i].getColor());
                                    //Debug.WriteLine("x1: " + x1 + " x2: " + x2 + " y1: " + y1 + " y2: " + y2);
                                    AbstractPlayer shield = new Shield(players[i]);
                                    players[i] = shield;
                                    //Debug.WriteLine("Player i: " + players[i].getName());
                                    //Debug.WriteLine("Po shieldo Playeri color: " + playeri.getColor());
                                    //Debug.WriteLine("x1: " + x1 + " x2: " + x2 + " y1: " + y1 + " y2: " + y2);
                                    //Debug.WriteLine("Shieldinto playerio pozicija: " + shield.getPosition());
                                    ////Debug.WriteLine("Shieldinto playerio spalva: " + shield.getPosition());
                                    ////players[i] = (Player)shield;
                                    ////newFood = UnitCreator.createUnit(3);
                                    //Debug.WriteLine("Mano tipas yra: " + shield.getName());
                                    //Unit gun = new Gun((AbstractPlayer)shield);
                                    //Debug.WriteLine("Mano tipas yra: " + gun.getName());
                                }
                                else if (Map.getInstance().getFood()[j].getType() == 4)
                                {
                                    //Debug.WriteLine("Pries gun Player i: " + players[i].getName());
                                    AbstractPlayer sizeUp = new SizeUp(players[i]);
                                    players[i] = sizeUp;
                                    //Debug.WriteLine("Player i: " + players[i].getName());
                                }

                                else if (Map.getInstance().getFood()[j].getType() == 5)
                                {
                                    //Debug.WriteLine("Pries gun Player i: " + players[i].getName());
                                    AbstractPlayer sizeDown = new SizeDown(players[i]);
                                    players[i] = sizeDown;
                                    //Debug.WriteLine("Player i: " + players[i].getName());
                                }

                                Map.getInstance().removeFood(j);
                                newFood.setPosition(new Point(rnd.Next(0, 1900), rnd.Next(0, 1000)));
                                Map.getInstance().addFood(newFood);
                                Map.getInstance().notifyObservers();

                                players[i].setSize(new Size(players[i].getSize().Width + 5, players[i].getSize().Height + 5));
                                Map.getInstance().setPlayer(i, players[i]);
                            }
                            //if (food[j].position.X >= x1 && food[j].position.X <= x2 && food[j].position.Y >= y1 && food[j].position.Y >= y2)
                            //{
                            //    GameController.map.removeFood(j);
                            //    players[i].playerSize = new Size(players[i].playerSize.Width + 1, players[i].playerSize.Height + 1);
                            //    GameController.map.setPlayer(i, players[i]);
                            //}
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
                await Task.Delay(interval);
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
    }
}
