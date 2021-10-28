using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationDemo.Interface;
using WebApplicationDemo.Services;

namespace WebApplicationDemo
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
            #region IOC注册抽象和具体的依赖关系
            services.AddTransient<IServiceA, ServiceA>();
            services.AddTransient<IServiceB, ServiceB>();
            #endregion

            IServiceCollection serviceCollection = new ServiceCollection();
            #region IServiceCollection 生命周期解析
            // 瞬时生命周期，每一次getService获取的实例都是不同的实例
            //serviceCollection.AddTransient<IServiceA, ServiceA>();
            //ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA = serviceProvider.GetService<IServiceA>();
            //IServiceA serviceA1 = serviceProvider.GetService<IServiceA>();
            //bool isEqual = object.ReferenceEquals(serviceA, serviceA1);  // false

            // 单例生命周期, 整个进程中获取的都是同一个实例
            //serviceCollection.AddSingleton<IServiceA, ServiceA>();
            //ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA = serviceProvider.GetService<IServiceA>();
            //IServiceA serviceA1 = serviceProvider.GetService<IServiceA>();
            //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // true

            // 作用域生命周期 同一个作用域获取的是同一个对象的实例；不同的作用域，获取的是不同的对象的实例
            
            serviceCollection.AddScoped<IServiceA, ServiceA>();
            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            IServiceA serviceA = serviceProvider.GetService<IServiceA>();
            IServiceA serviceA1 = serviceProvider.GetService<IServiceA>();
            bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // true

            ServiceProvider serviceProvider1 = serviceCollection.BuildServiceProvider();
            IServiceA serviceA2 = serviceProvider1.GetService<IServiceA>();
            bool isEqual1 = object.ReferenceEquals(serviceA1, serviceA2); // false

            #endregion


            #region 解决修改视图，必须编译后生效的问题 Nuget: Microsoft.AspNetCore.Mvc.Razor.RuntimeComplication

            IMvcBuilder builder = services.AddRazorPages();
            builder.AddRazorRuntimeCompilation();
            #endregion

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // 读取配置文件
            //var s = Configuration["Name"];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //loggerFactory.AddLog4Net("Config/log4net.config");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
