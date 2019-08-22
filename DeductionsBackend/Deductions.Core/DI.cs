using Deductions.Core.Calculators;
using Deductions.Core.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace Deductions.Core
{
    public static class DI
    {
        public static IServiceCollection AddCoreLibrary(this IServiceCollection services)
        {
            services.AddSingleton<IDeductionCalculators, DeductionCalculators>();
            services.AddSingleton<IDiscountCalculators, DiscountCalculators>();
            services.AddSingleton<ISummaryRoundingLossCalculators, SummaryRoundingLossCalculators>();
            services.AddSingleton<ICompensationSummaryProxy, CompensationSummaryProxy>();
            return services;
        }
    }
}