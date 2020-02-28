using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Championship.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Championship.Data.Repository;

namespace Championship
{
    public class Startup
    {
        private IConfigurationRoot _confstring;
        public Startup(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IPlayers, PlayersRepository>();
            services.AddTransient<IMatches, MatchesRepository>();
            services.AddTransient<IMatchParticipant, MatchParticipantRepository>();
            services.AddTransient <IMatchAdd, MatchAddRepository>();
            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();
            //services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseSession();   // добавляем механизм работы с сессиями
            //app.Run(async (context) =>
            //{
            //    if (context.Session.Keys.Contains("name"))
            //        await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
            //    else
            //    {
            //        context.Session.SetString("name", "Tom");
            //        await context.Response.WriteAsync("Hello World!");
            //    }
            //});
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
           app.UseMvcWithDefaultRoute();
            //app.UseRouting();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

        }
    }
}
