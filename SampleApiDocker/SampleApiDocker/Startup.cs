using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace SampleApiDocker.Api
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
            services.AddMvc().AddControllersAsServices();
            services.AddAutoMapper(typeof(Startup));

            var assemblyVersion = typeof(Startup).Assembly.GetName().Version.ToString();
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc($"v1", new OpenApiInfo
                {
                    Version = $"v1",
                    Title = $"API - {assemblyVersion}",
                    Description = $"API - Versão {assemblyVersion}",
                    Contact = new OpenApiContact { Name = "Rodrigo Schaefer", Email = "gdbbilly@gmail.com" },
                    License = new OpenApiLicense { Name = "MIT" }
                });

                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                s.IncludeXmlComments(caminhoXmlDoc);
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.RoutePrefix = "";
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1.0");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
