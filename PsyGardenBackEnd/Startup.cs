﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PsyGardenBackEnd.Data;
using PsyGardenBackEnd.Data.Repositories;
using PsyGardenBackEnd.Models.Domain;

namespace PsyGardenBackEnd
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Add NSwag service
            services.AddOpenApiDocument();

            services.AddDbContext<PsyGardenDBContext>(options => {
                //options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionDesktop"]);
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionLaptop"]);
            });

            services.AddScoped<DBInitializer>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DBInitializer dbInitializer)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();


            //Use NSwag service
            app.UseSwaggerUi3();
            app.UseSwagger();

            dbInitializer.InitializeData();

        }
    }
}
