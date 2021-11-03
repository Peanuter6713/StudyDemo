using Autofac;
using Autofac.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using WebApplicationDemo.Interface;
using WebApplicationDemo.Services;
using WebApplicationDemo.Utils.AutofacExtension;

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

            #region Autofac����������
            {
                //  �������ڷ�Χ
                //ContainerBuilder containerBuilder = new ContainerBuilder();
                //IContainer container = containerBuilder.Build();
                //using (var scope = container.BeginLifetimeScope())
                //{

                //}
            }
            {
                // ˲ʱ�������ڣ�ÿ�λ�ȡ������ȫ�µ�һ��ʵ����Ĭ�ϵ��������ڣ�  
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().InstancePerDependency();
                    //IContainer container = containerBuilder.Build();

                    //IServiceA serviceA = container.Resolve<IServiceA>();
                    //IServiceA serviceA1 = container.Resolve<IServiceA>();
                    //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // false
                }
                // ������������: �������������ڣ�������ͬһ��ʵ��
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<ServiceA>().As<IServiceA>().SingleInstance();
                    //IContainer container = containerBuilder.Build();
                    //IServiceA serviceA = container.Resolve<IServiceA>(); // ��ȡ����
                    //IServiceA serviceA1 = container.Resolve<IServiceA>();
                    //bool isEqual = object.ReferenceEquals(serviceA, serviceA1); // true
                }
                // ÿ���������ڷ�Χһ��ʵ�� (InstancePerLifetimeScope
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
                // ÿ�� ƥ���������ڷ�Χһ��ʵ�� ��InstancePerMatchingLifetimeScope(����))
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
                // ÿ������һ��ʵ��
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

            #region Autofac �����ļ�
            {
                ContainerBuilder containerBuilder = new ContainerBuilder();
                // ����������д��Autofacע��ĸ���
                {
                    // ��ȡ�����ļ��������ù�ϵװ�ص�ContainerBuilder
                    IConfigurationBuilder configuration = new ConfigurationBuilder();
                    IConfigurationSource autofacJsonConfigSource = new JsonConfigurationSource()
                    {
                        Path = "Config/autofac.json",
                        Optional = false, // Ĭ��ֵFALSE�� �ɲ�д
                        ReloadOnChange = true // ͬ��
                    };
                    configuration.Add(autofacJsonConfigSource);
                    ConfigurationModule module = new ConfigurationModule(configuration.Build());
                    containerBuilder.RegisterModule(module);
                }
                IContainer container = containerBuilder.Build();
                IServiceA serviceA = container.Resolve<IServiceA>();
                IServiceD serviceD = container.Resolve<IServiceD>();
                serviceD.Show();
            }
            #endregion

            #region ServiceCollectionע��ķ���Ҳ������Autofacʹ��,��ΪAutofac���Լ�ע�����֮ǰ�����Ȱ�ServiceCollection��ע��ķ���ȫ���ӹܹ���
            services.AddTransient<IServiceA, ServiceA>();
            services.AddTransient<IServiceB, ServiceB>();
            services.AddTransient<IServiceC, ServiceC>();
            #endregion

            #region ָ��������ʵ��������������
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
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

        /// <summary>
        /// ����������Autofac�Զ�����
        /// ����ע����ַ���
        /// 
        /// ����Autofac��ר�ŵĵط�ע�����
        /// 
        /// ֮ǰServiceCollectionע��ķ���Ҳ����Ч
        /// </summary>
        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ServiceA>().As<IServiceA>();
            containerBuilder.RegisterType<ServiceB>().As<IServiceB>();
            containerBuilder.RegisterType<ServiceC>().As<IServiceC>();
            containerBuilder.RegisterType<ServiceD>().As<IServiceD>();

            #region ע�����п������Ĺ�ϵ+������ʵ������Ҫ���������
            Type[] controllersTypeInAssembly = typeof(Startup).Assembly.GetExportedTypes().Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();

            containerBuilder.RegisterTypes(controllersTypeInAssembly).PropertiesAutowired(new CustomPropertySelector());
            #endregion
        }

    }
}
