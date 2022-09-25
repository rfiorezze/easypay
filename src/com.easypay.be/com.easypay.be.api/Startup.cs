using com.easypay.api.WorkerService;
using com.easypay.be.agents.Publishers;
using com.easypay.be.application.Clients.Commands;
using com.easypay.be.application.Payments.Commands;
using com.easypay.be.domain.Interfaces.Clients;
using com.easypay.be.domain.Interfaces.Payments;
using com.easypay.be.infrastructure;
using com.easypay.be.infrastructure.Repositories.Clients;
using com.easypay.be.infrastructure.Repositories.Payments;
using MediatR;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

namespace com.easypay.be.api
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
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api BFF", Version = "v1" });
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            //CQRS
            services
                .AddMediatR(typeof(CreateClientCommandHandler).Assembly);
            services
                .AddMediatR(typeof(ProcessResponsePaymentNotificationHandler).Assembly);

            //Repositories
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            //Agents
            services.AddSingleton<IMessageService, MessageService>();

            //HostedServices
            services.AddHostedService<ProcessResponsePaymentWorker>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BFF V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

        }
    }
}
