using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProdapWeb.Utils;

namespace ProdapWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataBaseGenerator.CreateDataBase();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
