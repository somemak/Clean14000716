using Clean14000716.Domain.Entities.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Clean14000716.WebCommon.Identity
{
    public static class CustomIdentity
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User,Role>(options =>
            {
                options.Password.RequireDigit = true;
            });
        }
    }
}