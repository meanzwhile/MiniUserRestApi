using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniUserRestApi.Models;
using MiniUserRestApi.Utilities;

namespace MiniUserRestApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=DESKTOP-2HGP57O\TESTINSTANCE;Database=MiniUser;Trusted_Connection=True;ConnectRetryCount=0";

            if (Utils.CheckDbConnection(connection))
            {
                services.AddDbContext<UserContext>(options => options.UseSqlServer(connection));

            }
            else
            {
                services.AddDbContext<UserContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            }



            services.AddMvc();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();

        }
    }
}
