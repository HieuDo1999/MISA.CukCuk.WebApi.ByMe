using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MISA.Core.Interfaces;
using MISA.Core.Services;
using MISA.Infrastructure.Repository;
using MISA_Cukcuk_WebAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Api.ByMe
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA.CukCuk.Web.Api.ByMe", Version = "v1" });
            });
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();

            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IProvinceService, ProvinceService>();

            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictService, DistrictService>();

               services.AddScoped<IWardRepository, WardRepository>();
            services.AddScoped<IWardService, WardService>();

            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreService, StoreService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA.CukCuk.Web.Api.ByMe v1"));
            }
            // Xử lý Exception
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;

                if (exception is ValidateExceptions)
                {
                    var responseBadRequest = new
                    {
                        devMsg = exception.Message,
                        userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp!",
                        errorCode = "misa-400",
                        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                        traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                    };
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(responseBadRequest);
                }

                var response = new
                {
                    devMsg = exception.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp!",
                    errorCode = "misa-005",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };

                await context.Response.WriteAsJsonAsync(response);
            }));
            app.UseCors(option => option.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
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
