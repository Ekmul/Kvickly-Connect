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
using Kvickly_Connect.Interfaces;
using Kvickly_Connect.Repositories;
using Kvickly_Connect.Services;

namespace Kvickly_Connect
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
            
            services.AddRazorPages();
            services.AddTransient<ICustomerRepository, JsonCustomerRepository>();
            services.AddTransient<IItemRepository, JsonItemRepository>();
            services.AddTransient<IOrderRepository, JsonOrderRepository>();
            services.AddSingleton<ShoppingCartService>();
            services.AddSingleton<JsonCustomerRepository>();
            services.AddSingleton<JsonOrderRepository>();


            /*

            InvalidOperationException: Unable to resolve service for type 
            'Kvickly_Connect.Repositories.JsonCustomerRepository' while attempting to activate 'Kvickly_Connect.Repositories.CustomerService'.

                */
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
