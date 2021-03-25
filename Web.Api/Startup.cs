using bARTSolution.Domain.Infrastructure.Extensions;
using bARTSolution.Web.Api.Extensions.Swagger;
using bARTSolutionWeb.Domain.Services.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bARTSolution.Web.Api
{
    public class Startup
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static string AppBaseUrl => "https://localhost:5001";//_httpContextAccessor.HttpContext.Request.Host.ToString();

        public Startup(IConfiguration configuration/*, IHttpContextAccessor httpContextAccessor*/)
        {
            Configuration = configuration;

           // _httpContextAccessor = httpContextAccessor;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwagger();

            services.AddApplicationDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
