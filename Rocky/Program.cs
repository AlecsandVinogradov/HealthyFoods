namespace HealthyFood
{
    public class Program
    {
        public static void Main(string[] arg)
        {
            CreateHostBuilder(arg).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBulder =>
            {
                webBulder.UseStartup<Startup>();
            });
    }
}
