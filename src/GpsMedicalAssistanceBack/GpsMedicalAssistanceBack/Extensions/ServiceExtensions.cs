using Entities;
using Entities.Utils;
using Interfaces.Core;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Repository.Core;
using Repository.Services;

namespace GpsMedicalAssistanceBack.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    x =>
                    {
                        x.MigrationsAssembly("GpsMedicalAssistanceBack");
                    });
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureRepositoryServices(this IServiceCollection services)
        {
            services.AddHttpClient<IFaceRecognitionServiceRepository, FaceRecognitionServiceRepository>();
        }

        public static void ConfigureTwilioSettings(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<TwilioSMSSettings>(configuration.GetSection(TwilioSMSSettings.SectionName));
        }
    }
}
