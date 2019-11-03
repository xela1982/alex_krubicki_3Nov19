using alex_krubicki_3Nov19.Data.ADO;

using alex_krubicki_3Nov19.Interfaces;
using alex_krubicki_3Nov19.Model;
using alex_krubicki_3Nov19.Repositories;
using alex_krubicki_3Nov19.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace alex_krubicki_3Nov19
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
            services.AddScoped<IRepository, RepositoryService>();
            services.AddScoped<ITakeAway, TakeAwayService>();
            services.Configure<ConnectionStringConfig>(this.Configuration.GetSection("ConnectionStrings"));
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
