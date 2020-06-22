using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using CarSomeWebAPI.Services;
using CarSomeWebAPI.Services.CarDetailService;
using CarSomeWebAPI.BLL;
using CarSomeWebAPI.BLL.CarDetailsBLL;
using CarSomeWebAPI.Infrastructure.Helper;
using CarSomeWebAPI.CL.InspectionCenterCL;
using CarSomeWebAPI.CL.CarDetailsCL;
using CarSomeWebAPI.CL.CustomerCL;
using CarSomeWebAPI.CL.AppointmentCL;


namespace CarSomeWebAPI
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

            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection);

            services.AddRazorPages();
            services.AddCors();
            services.AddJwtAuthentication(appSettings.Secret);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarSome API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                       }
                      },
                      new string[] { }
                    }
                  });
            });

            services.AddMvc();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IInspectionCenterService, InspectionCenterService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICarDetailService, CarDetailService>();

            services.AddSingleton<IAppointmentBLL, AppointmentBLL>();
            services.AddSingleton<IInspectionCenterBLL, InspectionCenterBLL>();
            services.AddSingleton<ICustomerBLL, CustomerBLL>();
            services.AddSingleton<ICarDetailsBLL, CarDetailsBLL>();

            services.AddSingleton<IInspectionCenterCL, InspectionCenterCL>();
            services.AddSingleton<ICarDetailsCL, CarDetailsCL>();
            services.AddSingleton<ICustomerCL, CustomerCL>();
            services.AddSingleton<IAppointmentCL, AppointmentCL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarSome API");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
