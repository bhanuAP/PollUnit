using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polling.Unit.Repository.Context;
using Polling.Unit.Repository.UserDataRepository.Concrete;
using Polling.Unit.Repository.UserDataRepository.Interface;
using Polling.Unit.Service.UserService.Concrete;
using Polling.Unit.Service.UserService.Interface;

namespace Polling.Unit.WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true).AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc();

            var connectionString = Configuration["dbConnectionString"];
            services.AddDbContext<PollingUnitContext>
                (options => options.UseSqlServer(connectionString));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserDataRepository, UserDataRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseMvc();
        }
    }
}
