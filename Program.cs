using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Testology_Dotnet.Persistence.Contexts;
using Testology_Dotnet.Domain.Security.Hashing;

namespace Testology_Dotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetService<AppDbContext>();
				var passwordHasher = services.GetService<IPasswordHasher>();
				DatabaseSeed.Seed(context, passwordHasher);
			}

			host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
