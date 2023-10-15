using GenerateCode.Repository;
using GenerateCode.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;


namespace GenerateCode
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)//, IConfiguration configuration
        {

            services.AddScoped<IURLInfoRepository, URLInfoRepository>();
            services.AddScoped<IURLInfoService, URLInfoService>();
          //  var siteSettings = GetSiteSettings(services);
          
            //services.AddDbContextPool<ApplicationDbContext>(options => {
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //});

            //services.AddDbContextPool<ApplicationDbContext>(option =>
            //{
            //    option.UseSqlServer(siteSettings.ConnectionStrings.DefaultConnection);
            //});

            return services;
        }
        public static SiteSettings GetSiteSettings(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            using (var scope = provider.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                var siteSettingsOptions = scopedProvider.GetRequiredService<IOptionsSnapshot<SiteSettings>>();
                var siteSettings = siteSettingsOptions.Value;
                if (siteSettings == null) throw new ArgumentNullException(nameof(siteSettings));
                return siteSettings;
            }
        
        }
    }


    public class SiteSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }


    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string Microsoft { get; set; }
    }
}
