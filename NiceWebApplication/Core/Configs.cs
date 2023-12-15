
namespace NiceWebApplication.Core
{
    static class Configs
    {
        public static IConfiguration Configuration { get; }
        static Configs()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
    }
}
