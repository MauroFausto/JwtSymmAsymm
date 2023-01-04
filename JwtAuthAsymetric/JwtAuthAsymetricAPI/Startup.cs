using System.Text;

namespace JwtAuthAsymetricAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            IConfigurationSection settingSection = Configuration.GetSection("AppSettings");
            AppSettings settings = settingSection.Get<AppSettings>();

            byte[] signingKey = { 0 };

            settings.EncryptionKey.Length > 0
                ? signingKey = Encoding.UTF8.GetBytes(settings.EncryptionKey)
                : signingKey = { 0 };

            services.AddAuthentication(signingKey.ToString());



        }
    }
}
