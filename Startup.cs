
using alex_krubicki_3Nov19.Interfaces;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using alex_krubicki_3Nov19.Repositories.Services;
using alex_krubicki_3Nov19.Services;
using alex_krubicki_3Nov19.Repositories.Entities;

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
       
            services.AddScoped<ITakeAway, TakeAwayService>();
            services.AddScoped<IRepositories, ADORepository>();
            services.AddSingleton(Configuration);
            services.AddDbContext<TakeAway2Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(TakeAway2Context).Assembly.FullName));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


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
