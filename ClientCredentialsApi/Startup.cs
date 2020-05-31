using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ClientCredentialsApi
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
            //services.AddAuthorization();
            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication(
            //        options =>
            //        {
            //            options.Authority = "http://localhost:5000"; //Ȩ����֤url
            //            options.RequireHttpsMetadata = false;//�Ƿ���https
            //            options.ApiName = "api";
            //        });
           
            services.AddControllers();
            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(
                    options =>
                    { 
                        //options.Authority = "http://localhost:5000"; //Ȩ����֤url
                        options.Authority = "http://localhost:5009"; //Ȩ����֤url
                        options.RequireHttpsMetadata = false;//�Ƿ���https
                        options.ApiName = "api";
                    });
            //services.AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = "http://localhost:5000";
            //        options.RequireHttpsMetadata = false;
            //        options.Audience = "api";
            //    });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();//��֤  ���������Ȩǰ�棬������Ч
            app.UseAuthorization();//��Ȩ
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
