using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlabberApp.Services;
using BlabberApp.DataStore;

namespace BlabberApp.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            UserFactory userFactory = new UserFactory();
            IUserPlugin userPlugin = userFactory.CreateUserPlugin("mysql");
            UserAdapter userAdapter = userFactory.CreateUserAdapter(userPlugin);
            UserService userService = userFactory.CreateUserService(userAdapter);

            BlabFactory blabFactory = new BlabFactory();
            IBlabPlugin blabPlugin = blabFactory.CreateBlabPlugin("mysql");
            BlabAdapter blabAdapter = blabFactory.CreateBlabAdapter(blabPlugin, userPlugin);
            IBlabService blabService = blabFactory.CreateBlabService(blabAdapter, userAdapter);

            services.AddSingleton<IUserService>(s => userService);
            services.AddSingleton<IBlabService>(s => blabService);
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
