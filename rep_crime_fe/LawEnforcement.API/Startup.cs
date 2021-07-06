using Common.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawEnforcement.API.Data.Context;
using LawEnforcement.API.Data.Repositories;
using LawEnforcement.API.Profiles;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcement.API
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
            services.AddHttpClient("CrimeAPI", client =>
            {
                client.BaseAddress = new Uri(Configuration["CrimeAPIUrl"]);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LawEnforcement.API", Version = "v1" });
            });

            services.AddEntityFrameworkCosmos();
            services.AddDbContext<LawEnforcementContext>(options =>
                options.UseCosmos("AccountEndpoint=https://rep-crime-sql.documents.azure.com:443/;AccountKey=8Zlke8QBz13TTQG0mqkOy0ZnptVYITOzcxRgPcwjtVlOypA8rMRHFztnXNVqHKYluQwhNfbkDNKFAL6obvEFYw==;",
                    "LawOfficersDB"));


            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestResponseLoggingMiddleware>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ILawEnfrocementRepository, LawEnfrocementRepository>();
            services.AddScoped<ILawEnfrocementService, LawEnfrocementService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LawEnforcement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
