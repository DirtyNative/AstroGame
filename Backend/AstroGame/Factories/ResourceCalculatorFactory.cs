using AstroGame.Generator.Generators.ResourceGenerators;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AstroGame.Api.Factories
{
    public class ResourceCalculatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ResourceCalculatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IResourceCalculator Create()
        {
#if DEBUG
            return _serviceProvider.GetService<DebugResourceCalculator>();
#else
            return _serviceProvider.GetService<ResourceCalculator>();
#endif
        }
    }
}