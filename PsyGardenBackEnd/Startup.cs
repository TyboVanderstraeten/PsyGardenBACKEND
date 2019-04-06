using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NSwag.SwaggerGeneration.Processors.Security;
using PsyGardenBackEnd.Data;
using PsyGardenBackEnd.Data.Repositories;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Text;

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
            services.AddOpenApiDocument(apidoc => {
                apidoc.DocumentName = "PsyGardenAPI";
                apidoc.Title = "PsyGarden API";
                apidoc.Version = "v1";
                apidoc.Description = "The PsyGarden API documentation";
                apidoc.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token",
                    new NSwag.SwaggerSecurityScheme {
                        Type = NSwag.SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = NSwag.SwaggerSecurityApiKeyLocation.Header,
                        Description = "Copy 'Bearer' + valid JWT token into field"
                    }));
                apidoc.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
            });

            //Add Default Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<PsyGardenDBContext>();

            //Add Authentication
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true
                };
            });

            //Configure Identity
            services.Configure<IdentityOptions>(options => {
                //Password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                //Lockout
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //User
                options.User.AllowedUserNameCharacters =
                                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            //Add CORS service
            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin());
            });

            services.AddDbContext<PsyGardenDBContext>(options => {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionDesktop"]);
                //options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionLaptop"]);
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

            //Use Authentication
            app.UseAuthentication();

            //Use CORS policies
            app.UseCors("AllowAllOrigins");

            dbInitializer.InitializeData();

        }
    }
}
