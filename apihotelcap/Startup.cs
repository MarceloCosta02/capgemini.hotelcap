using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apihotelcap.Configuration;
using apihotelcap.Infra.ExternalServices;
using apihotelcap.Infra.Facade;
using apihotelcap.Interfaces.Infra.ExternalServices;
using apihotelcap.Interfaces.Infra.Facade;
using apihotelcap.Interfaces.Repository;
using apihotelcap.Interfaces.Services;
using apihotelcap.Repository;
using apihotelcap.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace apihotelcap
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
            services.AddControllers().AddNewtonsoftJson(); 
            services.ConfigurarSwagger();

            services.AddScoped<IBedroomService, BedroomService>();
            services.AddScoped<IBedroomRepository, BedroomRepository>();

            services.AddScoped<IBedroomTypeService, BedroomTypeService>();
            services.AddScoped<IBedroomTypeRepository, BedroomTypeRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();

            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IBankGateway, BankGateway>();
            services.AddScoped<ITransferFacade, TransferFacade>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.ConfigurarJWT();
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

            app.UtilizarConfiguracaoJWT();

            app.UtilizarConfiguracaoSwagger();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
