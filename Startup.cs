using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Learn_Shop.Data;
using Learn_Shop.Data.Interfaces;
using Learn_Shop.Data.mocks;
using Learn_Shop.Data.Models;
using Learn_Shop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Learn_Shop
{
    public class Startup
    {

        private IConfigurationRoot _confString;

        public Startup(IHostingEnvironment hostEnv) {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>(); // связывает интерфейс с шаблоном.
            services.AddTransient<ICarsCategory, CategoryRepository>(); // связывает интерфейс с шаблоном.
            services.AddTransient<IAllOrders, OrdersRepository>(); // связывает интерфейс с шаблоном.


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
        

            services.AddMvc(); // Добавляет поддержку технологию MVC
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage(); // Отображать ошибки
            app.UseStatusCodePages(); // Отображает коды страничек ошибки.
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute(); // Если страничка не найдена, то отображать страничку по умолчанию.
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{Id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{category?}",
                defaults: new { Controllers = "Car", action = "List" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content;
                content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
