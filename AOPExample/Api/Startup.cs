using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.AutofacModules;
using Api.Interceptor;
using Api.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
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
            services.AddControllers();
            var builder = new ContainerBuilder();
            builder.Populate(services);
            var container = builder.Build();
            //return new AutofacServiceProvider(container);
        }

        public void ConfigureContainer(ContainerBuilder builder) 
        {
            builder.RegisterModule(new DIModal());
            builder.RegisterType<UserService>()
                .AsImplementedInterfaces().InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();
            //在控制器中使用依赖注入
            builder.RegisterType<MyInterceptor>();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && t != typeof(ControllerBase))
                .PropertiesAutowired();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
