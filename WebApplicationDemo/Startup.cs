using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
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
            
            //serviceCollection.AddScoped<IServiceA, ServiceA>();
            //ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA = serviceProvider.GetService<IServiceA>();
            //IServiceA serviceA1 = serviceProvider.GetService<IServiceA>();
            //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // true

            //ServiceProvider serviceProvider1 = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA2 = serviceProvider1.GetService<IServiceA>();
            //bool isEqual1 = object.ReferenceEquals(serviceA1, serviceA2); // false

            #endregion


            #region 解决修改视图，必须编译后生效的问题 Nuget: Microsoft.AspNetCore.Mvc.Razor.RuntimeComplication

            IMvcBuilder builder = services.AddRazorPages();
            builder.AddRazorRuntimeCompilation();
            #endregion

            services.AddControllersWithViews();

            #region Autofac 容器初识
            {
                //ContainerBuilder containerBuilder = new ContainerBuilder();

                //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
                //IContainer container = containerBuilder.Build();
                //IServiceA serviceA3 = container.Resolve<IServiceA>(); // 获取服务
                //serviceA3.Show();
            }
            #endregion

            #region 构造函数注入
            {
                //ContainerBuilder containerBuilder = new ContainerBuilder();
                //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
                //containerBuilder.RegisterType<ServiceB>().As<IServiceB>();
                //containerBuilder.RegisterType<ServiceC>().As<IServiceC>();
                //IContainer container = containerBuilder.Build();
                //IServiceB serviceB = container.Resolve<IServiceB>(); 
                //serviceB.Show();
            }
            #endregion

            #region 属性注入
            {
                //ContainerBuilder containerBuilder = new ContainerBuilder();
                //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
                //containerBuilder.RegisterType<ServiceB>().As<IServiceB>();
                //containerBuilder.RegisterType<ServiceC>().As<IServiceC>();
                //containerBuilder.RegisterType<ServiceD>().As<IServiceD>().PropertiesAutowired();
                //IContainer container = containerBuilder.Build();
                //IServiceD serviceD = container.Resolve<IServiceD>();
                //serviceD.Show();
            }
            #endregion

            #region 方法注入
            //{
            //    ContainerBuilder containerBuilder = new ContainerBuilder();
            //    containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
            //    containerBuilder.RegisterType<ServiceB>().OnActivated(e =>
            //    e.Instance.SetService(e.Context.Resolve<IServiceA>())).As<IServiceB>();
            //    containerBuilder.RegisterType<ServiceC>().As<IServiceC>();
            //    containerBuilder.RegisterType<ServiceD>().As<IServiceD>().PropertiesAutowired();
            //    IContainer container = containerBuilder.Build();
            //    IServiceB serviceB = container.Resolve<IServiceB>();
            //    serviceB.Show();
            //}
            #endregion

            #region Autofac的生命周期
            {
                //  生命周期范围
                //ContainerBuilder containerBuilder = new ContainerBuilder();
                //IContainer container = containerBuilder.Build();
                //using (var scope = container.BeginLifetimeScope())
                //{

                //}
            }
            {
                // 瞬时生命周期：每次获取对象都是全新的一个实例（默认的生命周期）  
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerDependency();
                    //IContainer container = containerBuilder.Build();

                    //IServiceA serviceA = container.Resolve<IServiceA>();
                    //IServiceA serviceA1 = container.Resolve<IServiceA>();
                    //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // false
                }
                // 单例生命周期: 在整个生命周期，对象是同一个实例
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().SingleInstance();
                    //IContainer container = containerBuilder.Build();
                    //IServiceA serviceA = container.Resolve<IServiceA>(); // 获取服务
                    //IServiceA serviceA1 = container.Resolve<IServiceA>();
                    //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // true
                }
                // 每个生命周期范围一个实例 (InstancePerLifetimeScope
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerLifetimeScope();
                    //IContainer container = containerBuilder.Build();

                    //IServiceA serviceA = null;
                    //IServiceA serviceA1 = null;
                    //using (var scope = container.BeginLifetimeScope())
                    //{
                    //    IServiceA serviceA2 = scope.Resolve<IServiceA>();
                    //    IServiceA serviceA3 = scope.Resolve<IServiceA>();
                    //    bool isEqual = object.ReferenceEquals(serviceA2, serviceA3); // true
                    //    serviceA = serviceA2;
                    //}

                    //using (var scope = container.BeginLifetimeScope())
                    //{
                    //    IServiceA serviceA2 = scope.Resolve<IServiceA>();
                    //    IServiceA serviceA3 = scope.Resolve<IServiceA>();
                    //    bool isEqual = ReferenceEquals(serviceA2, serviceA3); // true
                    //    serviceA1 = serviceA3;
                    //}
                }
                // 每个 匹配生命周期范围一个实例 （InstancePerMatchingLifetimeScope(名称))
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerMatchingLifetimeScope("wds");

                    //IContainer container = containerBuilder.Build();

                    //IServiceA serviceA = null;
                    //IServiceA serviceA1 = null;
                    //using (var scope = container.BeginLifetimeScope("wds"))
                    //{
                    //    IServiceA serviceA2 = scope.Resolve<IServiceA>();
                    //    using (var scope1 = container.BeginLifetimeScope())
                    //    {
                    //        IServiceA serviceA3 = scope.Resolve<IServiceA>();
                    //        bool isEqual1 = object.ReferenceEquals(serviceA2, serviceA3); // true
                    //    }
                    //    serviceA = serviceA2;
                    //}

                    //using (var scope = container.BeginLifetimeScope("wds"))
                    //{
                    //    IServiceA serviceA2 = scope.Resolve<IServiceA>();
                    //    using (var scope1 = container.BeginLifetimeScope())
                    //    {
                    //        IServiceA serviceA3 = scope.Resolve<IServiceA>();
                    //        bool isEqual2 = ReferenceEquals(serviceA2, serviceA3); // true
                    //    }
                    //    serviceA1 = serviceA2;
                    //}

                    //bool isEqual = serviceA == serviceA1;
                }
                // 每个请求一个实例
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerRequest();
                    //IContainer container = containerBuilder.Build();
                    //using (var scope = container.BeginLifetimeScope())
                    //{
                    //    IServiceA serviceA = container.Resolve<IServiceA>();
                    //    IServiceA serviceA1 = container.Resolve<IServiceA>();
                    //    bool isEqual = ReferenceEquals(serviceA, serviceA1);
                    //}
                }
            }

            #endregion

            #region Autofac 配置文件
            #endregion
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
