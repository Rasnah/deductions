using Deductions.Core.Calculators;
using Deductions.Core.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace Deductions.Core
{
    public static class DI
    {
        public static IServiceCollection AddCoreLibrary(this IServiceCollection services)
        {
            services.AddScoped<IDeductionCalculators, DeductionCalculators>();
            services.AddScoped<IEmployeeDeductionProxy, EmployeeDeductionProxy>();
            return services;
        }
    }
}