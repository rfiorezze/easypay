using com.easypay.paymentapi.agents.Publishers;
using com.easypay.paymentapi.api.WorkerServices;
using com.easypay.paymentapi.application.Payments.Commands;
using com.easypay.paymentapi.domain.Payments.Interfaces;
using com.easypay.paymentapi.infrastructure.Payments;
using MediatR;
using Microsoft.OpenApi.Models;

namespace com.easypay.paymentapi.api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Payment", Version = "v1" });
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            //CQRS
            services
                .AddMediatR(typeof(ProcessPaymentCommandHandler).Assembly);

            //Repositories
            services.AddTransient<IPaymentRepository, PaymentRepository>();

            //Agents
            services.AddSingleton<IMessageService, MessageService>();

            //HostedServices
            services.AddHostedService<ProcessPaymentWorker>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment V1");
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
