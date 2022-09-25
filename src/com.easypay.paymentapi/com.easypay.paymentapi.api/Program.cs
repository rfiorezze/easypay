namespace com.easypay.paymentapi.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: true)
                   .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                   .AddEnvironmentVariables()
                   .AddCommandLine(args)
                   .Build();

            return Host.CreateDefaultBuilder(args)
                       .ConfigureLogging(x =>
                       {
                           x.AddConsole();
                       })
                       .ConfigureWebHostDefaults(webBuilder =>
                       {
                           webBuilder.UseStartup<Startup>();
                       });
        }
    }
}