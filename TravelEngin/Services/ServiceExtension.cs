using TravelEngin.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceExtension
    {

        public static void AddSmsService(this IServiceCollection services)
        {
           
            services.AddSingleton<SmsService>();

        }
    }
}