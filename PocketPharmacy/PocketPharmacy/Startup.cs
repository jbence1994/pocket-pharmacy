using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PocketPharmacy.Core.Repositories;
using PocketPharmacy.Persistence.Mocks;
using AutoMapper;
using PocketPharmacy.Persistence;

namespace PocketPharmacy
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
            services.AddCors(c => { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); });

            services.AddDbContext<PocketPharmacyDbContext>();

            services.AddAutoMapper();

            services.AddScoped<IMedicineRepository, FakeMedicineRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
