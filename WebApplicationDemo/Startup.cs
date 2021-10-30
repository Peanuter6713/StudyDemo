using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
            #region IOCע�����;����������ϵ
            services.AddTransient<IServiceA, ServiceA>();
            services.AddTransient<IServiceB, ServiceB>();
            #endregion

            IServiceCollection serviceCollection = new ServiceCollection();
            #region IServiceCollection �������ڽ���
            // ˲ʱ�������ڣ�ÿһ��getService��ȡ��ʵ�����ǲ�ͬ��ʵ��
            //serviceCollection.AddTransient<IServiceA, ServiceA>();
            //ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA = serviceProvider.GetService<IServiceA>();
            //IServiceA serviceA1 = serviceProvider.GetService<IServiceA>();
            //bool isEqual = object.ReferenceEquals(serviceA, serviceA1);  // false

            // ������������, ���������л�ȡ�Ķ���ͬһ��ʵ��
            //serviceCollection.AddSingleton<IServiceA, ServiceA>();
            //ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA = serviceProvider.GetService<IServiceA>();
            //IServiceA serviceA1 = serviceProvider.GetService<IServiceA>();
            //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // true

            // �������������� ͬһ���������ȡ����ͬһ�������ʵ������ͬ�������򣬻�ȡ���ǲ�ͬ�Ķ����ʵ��
            
            //serviceCollection.AddScoped<IServiceA, ServiceA>();
            //ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA = serviceProvider.GetService<IServiceA>();
            //IServiceA serviceA1 = serviceProvider.GetService<IServiceA>();
            //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // true

            //ServiceProvider serviceProvider1 = serviceCollection.BuildServiceProvider();
            //IServiceA serviceA2 = serviceProvider1.GetService<IServiceA>();
            //bool isEqual1 = object.ReferenceEquals(serviceA1, serviceA2); // false

            #endregion


            #region ����޸���ͼ������������Ч������ Nuget: Microsoft.AspNetCore.Mvc.Razor.RuntimeComplication

            IMvcBuilder builder = services.AddRazorPages();
            builder.AddRazorRuntimeCompilation();
            #endregion

            services.AddControllersWithViews();

            #region Autofac ������ʶ
            {
                //ContainerBuilder containerBuilder = new ContainerBuilder();

                //containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
                //IContainer container = containerBuilder.Build();
                //IServiceA serviceA3 = container.Resolve<IServiceA>(); // ��ȡ����
                //serviceA3.Show();
            }
            #endregion

            #region ���캯��ע��
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

            #region ����ע��
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

            #region ����ע��
            {
                ContainerBuilder containerBuilder = new ContainerBuilder();
                containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
                containerBuilder.RegisterType<ServiceB>().OnActivated(e =>
                e.Instance.SetService(e.Context.Resolve<IServiceA>())).As<IServiceB>();
                containerBuilder.RegisterType<ServiceC>().As<IServiceC>();
                containerBuilder.RegisterType<ServiceD>().As<IServiceD>().PropertiesAutowired();
                IContainer container = containerBuilder.Build();
                IServiceB serviceB = container.Resolve<IServiceB>();
                serviceB.Show();
            }
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // ��ȡ�����ļ�
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
