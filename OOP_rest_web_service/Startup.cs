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
        static List<Color> allColors;
        public static List<DateTime> lastPosts;
        int sizeChange = 1;
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
            lastPosts.Add(new DateTime());
            lastPosts.Add(new DateTime());
            lastPosts.Add(new DateTime());
            lastPosts.Add(new DateTime());
            lastPosts.Add(new DateTime());
            lastPosts.Add(new DateTime());
            lastPosts.Add(new DateTime());
            lastPosts.Add(new DateTime());

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
                    if (DateTime.Now.Subtract(lastPosts[i]) >= TimeSpan.FromSeconds(5))
                    {
                        GameController.map.removePlayers(i);
                    }
                }
                await Task.Delay(interval);
            }
        }

        public async Task PeriodicCollisionCheck(TimeSpan interval)
        {
            while (true)
            {
                List<Unit> players = GameController.map.getPlayers();
                List<Unit> food = GameController.map.getFood();

                for (int i = 0; i < 8; i++)
                {
                    if (players[i] != null)
                    {
                        int x1 = players[i].position.X - players[i].playerSize.Width / 2;
                        int x2 = players[i].position.X + players[i].playerSize.Width / 2;
                        int y1 = players[i].position.Y - players[i].playerSize.Height / 2;
                        int y2 = players[i].position.Y - players[i].playerSize.Height / 2;

                        for(int j = 0; j < food.Count; j++)
                        {
                            if(food[j].position.X >= x1 && food[j].position.X <= x2 && food[j].position.Y >= y1 && food[j].position.Y >= y2)
                            {
                                GameController.map.removeFood(j);
                                players[i].playerSize = new Size(players[i].playerSize.Width + 1, players[i].playerSize.Height + 1);
                                GameController.map.setPlayer(i, players[i]);
                            }
                        }

                        for (int j = 0; j < 8; j++)
                        {
                            if(i != j)
                            {
                                if (players[j].position.X >= x1 && players[j].position.X <= x2 && players[j].position.Y >= y1 && players[j].position.Y >= y2)
                                {
                                    if(players[i].playerSize.Width > players[j].playerSize.Width)
                                    {
                                        GameController.map.removePlayers(j);
                                        players[i].playerSize = new Size(players[i].playerSize.Width + 1, players[i].playerSize.Height + 1);
                                        GameController.map.setPlayer(i, players[i]);
                                    }
                                    else if(players[i].playerSize.Width < players[j].playerSize.Width)
                                    {
                                        GameController.map.removePlayers(i);
                                        players[j].playerSize = new Size(players[j].playerSize.Width + 1, players[j].playerSize.Height + 1);
                                        GameController.map.setPlayer(j, players[j]);
                                    }
                                }
                            }
                        }
                    }
                }
                await Task.Delay(interval);
            }
        }
    }
}
