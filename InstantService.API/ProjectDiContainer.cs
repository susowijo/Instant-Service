using DatnekNetSolution.Core;
using DatnekNetSolution.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using InstantService.API.BL;
using InstantService.API.DAL;
using InstantService.API.Mappings;
using InstantService.API.Services;
using Microsoft.AspNetCore.Http.Features;

namespace InstantService.API
{
    /// <summary>
    /// 
    /// </summary>
    public static class ProjectDiContainer
    {
           #region Extensions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddProjectScoped(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.AddInfraScoped(configuration);
            services.AddMappingScoped();
            services.AddServiceScoped();
            services.AddDatnekScoped(configuration);
            services.AddBlScoped();
            //services.AddQueuesScoped(configuration);

           

            var appSettings = configuration.GetSection("AppSettings");
           // var a = configuration["ConnectionStrings:DefaultConnection"];
            services.Configure<AppSettings>(appSettings);


            // swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "InstantService webservice api", Version = "v1"});

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            return services;
        }

        #endregion
    }
}