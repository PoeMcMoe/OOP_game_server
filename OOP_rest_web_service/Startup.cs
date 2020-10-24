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

namespace OOP_rest_web_service
{
    public class Startup
    {
        static List<Color> allColors;
        public static List<DateTime> lastPosts;
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
    }
}
