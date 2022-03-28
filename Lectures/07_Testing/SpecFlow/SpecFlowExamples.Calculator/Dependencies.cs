using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

// For more details see https://github.com/solidtoken/SpecFlow.DependencyInjection

namespace SpecFlowExamples.Calculator
{
    public static class Dependencies
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<CalculatorService>();

            return services;
        }
    }
}
