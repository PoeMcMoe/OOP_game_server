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

            lastPosts = new List<DateTime>();
            for(int i = 0; i < 8; i++)
            {
                lastPosts.Add(DateTime.MaxValue);
            }

            PeriodicMapCheck(TimeSpan.FromSeconds(0.1));
            PeriodicCollisionCheck(TimeSpan.FromSeconds(0.1));

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
                List<Player> players = Map.getInstance().getPlayers().Cast<Player>().ToList();
                List<Food> food = Map.getInstance().getFood().Cast<Food>().ToList();

                for (int i = 0; i < 8; i++)
                {
                    if (players[i].getColor() != Color.White)
                    {
                        int x1 = players[i].getPosition().X - players[i].getSize().Width / 2;
                        int x2 = players[i].getPosition().X + players[i].getSize().Width / 2;
                        int y1 = players[i].getPosition().Y - players[i].getSize().Height / 2;
                        int y2 = players[i].getPosition().Y + players[i].getSize().Height / 2;


                        for(int j = 0; j < food.Count; j++)
                        {
                            int fx1 = food[j].getPosition().X - 10 / 2;
                            int fx2 = food[j].getPosition().X + 10 / 2;
                            int fy1 = food[j].getPosition().Y - 10 / 2;
                            int fy2 = food[j].getPosition().Y + 10 / 2;


                            if (doOverlap(new Point(x1, y2), new Point(x2, y1), new Point(fx1, fy2), new Point(fx2, fy1)))
                            {
                                Unit newFood;

                                if(Map.getInstance().getFood()[j].getType() == 2)
                                {
                                    newFood = UnitCreator.createUnit(2);
                                    players[i].setConfused(true);
                                }
                                else
                                {
                                    newFood = UnitCreator.createUnit(1);
                                }
                                Map.getInstance().removeFood(j);
                                newFood.setPosition(new Point(rnd.Next(0, 1900), rnd.Next(0, 1000)));
                                Map.getInstance().addFood(newFood);

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
