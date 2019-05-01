using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.SwaggerGeneration.Processors.Security;
using PsyGardenBackEnd.Data;
using PsyGardenBackEnd.Data.Repositories;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Security.Claims;
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
            #region MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion

            #region DBContext
            services.AddDbContext<PsyGardenDBContext>(options => {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionDesktop"]);
                //options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionLaptop"]);
            });
            #endregion

            #region Dependency Injections
            services.AddScoped<DBInitializer>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region NSwag
            services.AddOpenApiDocument(apidoc => {
                apidoc.DocumentName = "PsyGardenAPI";
                apidoc.Title = "PsyGarden API";
                apidoc.Version = "v1";
                apidoc.Description = "The PsyGarden API documentation";
                apidoc.DocumentProcessors.Add(new SecurityDefinitionAppender("JWT Token",
                    new SwaggerSecurityScheme {
                        Type = SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = SwaggerSecurityApiKeyLocation.Header,
                        Description = "Copy 'Bearer' + valid JWT token into field"
                    }));
                apidoc.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
            });
            #endregion

            #region Default Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<PsyGardenDBContext>();
            #endregion

            #region Authentication
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
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
            #endregion

            #region Authorization
            services.AddAuthorization(options => {
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
                options.AddPolicy("User", policy => policy.RequireClaim(ClaimTypes.Role, "user"));
            });
            #endregion

            #region Identity
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

            #endregion

            #region CORS
            services.AddCors(options => {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin());
            });
            #endregion

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
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwaggerUi3();
            app.UseSwagger();
            app.UseCors("AllowAllOrigins");

            dbInitializer.InitializeData().Wait();
        }
    }
}
