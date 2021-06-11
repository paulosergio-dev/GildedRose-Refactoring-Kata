using GildedRose_Refactoring_Kata.Model.Context;
using GildedRose_Refactoring_Kata.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace GildedRose_Refactoring_Kata
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GildedRose_Refactoring_Kata",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Paulo S�rgio",
                        Email = "paulosergioo-@hotmail.com",
                        Url = new Uri("https://paulosergio.dev")
                    }
                });
            });

            services.AddDbContext<RegularItemContext>(opt => opt.UseInMemoryDatabase("ItemContext"));
            services.AddScoped<IItemUpdaterService, ItemUpdaterService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GildedRose_Refactoring_Kata v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
