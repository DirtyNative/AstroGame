using AstroGame.Core.Helpers;
using AstroGame.Shared.Models.Resources;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AstroGame.Generator.Generators.ResourceGenerators
{
    public class ResourceGenerator : IGenerator
    {
        private const double MinValue = 0.20;
        private const double MaxValue = 2;

        private readonly List<Resource> _resources;

        public ResourceGenerator(List<Resource> resources)
        {
            _resources = resources;
        }

        public List<StellarObjectResource> Generate(StellarObject parent, int minResources, int maxResources)
        {
            var list = new List<StellarObjectResource>();

            var countResources = RandomCalculator.Random.Next(minResources, maxResources);

            // Generate the pool of resources
            var weights = _resources.Select(resource =>
                new KeyValuePair<Resource, uint>(resource, resource.NaturalOccurrenceWeight)).ToList();

            for (var i = 0; i < countResources; i++)
            {
                var resource = RandomCalculator.SelectByWeight(weights);
                var multiplier = GenerateMultiplier();

                var stellarObjectResource = new StellarObjectResource()
                {
                    StellarObject = parent,
                    Resource = resource,
                    Multiplier = multiplier,
                };

                // Remove the resource from the pool, so it does not occur twice
                weights.Remove(weights.First(e => e.Key == resource));

                list.Add(stellarObjectResource);
            }

            return list;
        }

        private static double GenerateMultiplier()
        {
            var multiplier = RandomCalculator.Random.NextDouble() + MinValue;

            if (multiplier > MaxValue)
            {
                multiplier = MaxValue;
            }

            return multiplier;
        }
    }
}