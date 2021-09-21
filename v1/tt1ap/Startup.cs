using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbProvider;
using DbProvider.Models;
using DbProvider.serviceExtensions;
using DbProvider.VirtualDTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Myapp.DataADO;
using Myapp.DataADO.Models;
using Myapp.PersistenceDB.Context;
using tt1ap.CustomMiddleware;
using tt1ap.ExtensionMethods;
using tt1ap.Infrastructure.Mapping;

namespace tt1ap
{
    public class Startup
    {

        public IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddServices();
            services.AddTokenAuthentication(_configuration);
            services.RegisterMaps();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddSwaggerConfig();
            services.Configure<ConnectionStrings>(_configuration.GetSection(nameof(ConnectionStrings)));
            services.Configure<JWTConfiguration>(_configuration.GetSection(nameof(JWTConfiguration)));

            services.AddDbContext<EmployeeManagmentContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("tt1ap"));
            });

            services.AddScoped<DbContext, EmployeeManagmentContext>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider versionDescProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<CustomExHandlerMiddleware>();
            app.UseMiddleware<RequestResponseLoggerMiddleware>();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI( x=>
            {
                foreach (var item in versionDescProvider.ApiVersionDescriptions)
                {
                    x.SwaggerEndpoint($"/swagger/" +
                        $"LibraryOpenAPISpecification{item.GroupName}/swagger.json",
                        item.GroupName.ToUpperInvariant());
                }


            });


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
