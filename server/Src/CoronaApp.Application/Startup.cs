using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace CoronaApp.Api
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
       //     services.AddAuthentication(
       //CertificateAuthenticationDefaults.AuthenticationScheme)
       //.AddCertificate();

            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });



            services.AddScoped(typeof(IPatientRepository), typeof(PatientRepository));
            services.AddScoped(typeof(IPathRepository), typeof(PathRepository));
            services.AddScoped(typeof(IPathService), typeof(PathService));
            services.AddScoped(typeof(IPatientService), typeof(PatientService));

            services.AddDbContext<CoronaContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("CoronaDBConnectionString")));

            //services.AddDbContext<CoronaContext>(options => options.UseSqlServer
            //(Configuration.GetConnectionString("CoronaDBConnectionString")));

            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("Policy1",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8080");

                        builder.AllowAnyHeader();
                        builder.WithMethods("GET", "POST", "PUT")
                        .AllowCredentials();

                    });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseErrorHandlingMiddleware();
            app.UseStatusCodePages();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("Policy1");
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.None,
                HttpOnly = HttpOnlyPolicy.Always,
               // Secure = CookieSecurePolicy.Always
            });

            app.Use(async (context, next) =>
            {
                var token = context.Request.Cookies[".AspNetCore.Application.Id"];
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
                }
                //context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                //context.Response.Headers.Add("X-Xss-Protection", "1");
                //context.Response.Headers.Add("X-Frame-Options", "DENY");

                await next();
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
