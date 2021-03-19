using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Core.Enums;
using AstroGame.Core.Extensions;
using AstroGame.Core.Helpers;
using AstroGame.Core.Structs;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    [ScopedService]
    public class GeneratorBase
    {
        private readonly IServiceProvider _services;


        public GeneratorBase(IServiceProvider services)
        {
            _services = services;
        }

        public StellarSystem GenerateSystem(StellarSystem parent, SystemSize size,
            List<KeyValuePair<Type, uint>> objectWeights,
            uint countObjects, Coordinates parentCoordinates, string systemName)
        {
            // If there is an invalid count provided, just return nothing
            if (countObjects < 1 || objectWeights.Count < 1)
            {
                return null;
            }

            var system = new MultiObjectSystem(parent);

            system.CenterObjects =
                GenerateCenterObjects(system, objectWeights, countObjects, size, parentCoordinates.Increment(size, 1), systemName);
            system.Satellites = GenerateSatelliteSystems(system, size + 1, parentCoordinates.Increment(size, 1), systemName);

            return system;
        }

        public T GenerateChildren<T>(T system, SystemSize size,
            List<KeyValuePair<Type, uint>> objectWeights,
            uint countObjects, Coordinates parentCoordinates, string systemName) where T : StellarSystem
        {
            // If there is an invalid count provided, just return nothing
            if (countObjects < 1)
            {
                return null;
            }

            system.CenterObjects =
                GenerateCenterObjects(system, objectWeights, countObjects, size, parentCoordinates, systemName);
            system.Satellites = GenerateSatelliteSystems(system, size + 1, parentCoordinates, systemName);

            return system;
        }

        /*private StellarObject GenerateObject(StellarSystem parentSystem,
            List<KeyValuePair<Type, uint>> objectWeights,
            uint order, Coordinates coordinates)
        {
            if (objectWeights.Count == 0)
            {
                Debug.WriteLine("");
            }

            var objectType = RandomCalculator.SelectByWeight(objectWeights);

            if (objectType == typeof(Star))
            {
                return _starGenerator.Generate(parentSystem, coordinates);
            }

            if (objectType == typeof(Planet))
            {
                return _planetGenerator.Generate(parentSystem, order);
            }

            if (objectType == typeof(Moon))
            {
                return _moonGenerator.Generate(parentSystem, order);
            }

            throw new NotImplementedException($"Type {objectType} is not implemented yet");
        } */

        private StellarObject GenerateObject(StellarSystem parentSystem,
            List<KeyValuePair<Type, uint>> objectWeights,
            Coordinates coordinates, string systemName)
        {
            if (objectWeights.Count == 0)
            {
                Debug.WriteLine("");
            }

            var objectType = RandomCalculator.SelectByWeight(objectWeights);

            //_services.GetService(typeof(IStellarObjectGenerator<objectType>));
            //var generator = _services.GetService<IStellarObjectGenerator<Star>>();

            //return generator.Generate(parentSystem, coordinates, systemName);
            
            if (objectType == typeof(Star))
            {
                return _services.GetService<IStellarObjectGenerator<Star>>().Generate(parentSystem, coordinates, systemName);
            }

            if (objectType == typeof(Planet))
            {
                return _services.GetService<IStellarObjectGenerator<Planet>>().Generate(parentSystem, coordinates, systemName);
            }

            if (objectType == typeof(Moon))
            {
                return _services.GetService<IStellarObjectGenerator<Moon>>().Generate(parentSystem, coordinates, systemName);
            }

            if (objectType == typeof(BlackHole))
            {
                return _services.GetService<IStellarObjectGenerator<BlackHole>>().Generate(parentSystem, coordinates, systemName);
            }

            throw new NotImplementedException($"Type {objectType} is not implemented yet");
        }

        private List<StellarObject> GenerateCenterObjects(StellarSystem parentSystem,
            List<KeyValuePair<Type, uint>> objectWeights, uint countObjects, SystemSize size,
            Coordinates parentCoordinates, string systemName)
        {
            var list = new List<StellarObject>();

            for (var i = 0; i < countObjects; i++)
            {
                var stellarObject =
                    GenerateObject(parentSystem, objectWeights, parentCoordinates.Increment(size, i), systemName);
                list.Add(stellarObject);
            }

            return list;
        }

        private List<StellarSystem> GenerateSatelliteSystems(StellarSystem parentSystem, SystemSize size,
            Coordinates parentCoordinates, string systemName)
        {
            var list = new List<StellarSystem>();

            // Determines how many satellite systems (not the objects) will be generated
            var countSatelliteWeights = GenerateSatelliteCountWeightBySize(size);
            var countSatellites = RandomCalculator.SelectByWeight(countSatelliteWeights);

            // The objects appearance possibilities
            var objectWeights = GenerateStellarObjectWeightsBySize(size);

            // Defines how many center objects will be generated
            var objectCountWeights = GenerateCenterObjectCountWeights(size);
            var countObjects = RandomCalculator.SelectByWeight(objectCountWeights);

            for (uint i = 0; i < countSatellites; i++)
            {
                var system = GenerateSystem(parentSystem, size, objectWeights, countObjects,
                    parentCoordinates, systemName);

                parentCoordinates = parentCoordinates.Increment(size, (int)countObjects);

                if (system == null)
                {
                    // There is nothing to add, continue
                    continue;
                }


                list.Add(system);
            }

            return list;
        }

        public List<KeyValuePair<Type, uint>> GenerateStellarObjectWeightsBySize(SystemSize size)
        {
            if (size == SystemSize.Solar)
            {
                return new List<KeyValuePair<Type, uint>>()
                {
                    new KeyValuePair<Type, uint>(typeof(Star), 10),
                    new KeyValuePair<Type, uint>(typeof(BlackHole), 10),
                };
            }

            if (size == SystemSize.InterPlanetar)
            {
                return new List<KeyValuePair<Type, uint>>()
                {
                    new KeyValuePair<Type, uint>(typeof(Planet), 100),
                };
            }

            if (size == SystemSize.InterLunar)
            {
                return new List<KeyValuePair<Type, uint>>()
                {
                    new KeyValuePair<Type, uint>(typeof(Moon), 100),
                };
            }

            if (size == SystemSize.Lunar)
            {
                // TODO: Define moons satellite types
                return new List<KeyValuePair<Type, uint>>()
                {
                };
            }

            throw new NotImplementedException($"System size {size} is not implemented yet");
        }

        /// <summary>
        /// Generates the count of satellites a StellarObject has
        /// </summary>
        /// <param name="parentSize"></param>
        /// <returns></returns>
        private List<KeyValuePair<uint, uint>> GenerateSatelliteCountWeightBySize(SystemSize parentSize)
        {
            // How many sub systems (stars, black holes, etc) a solar system has
            if (parentSize == SystemSize.Solar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 100),
                };
            }

            // How many sub systems (planets) a star has
            if (parentSize == SystemSize.InterPlanetar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 2),
                    new KeyValuePair<uint, uint>(2, 4),
                    new KeyValuePair<uint, uint>(3, 6),
                    new KeyValuePair<uint, uint>(4, 6),
                    new KeyValuePair<uint, uint>(5, 5),
                    new KeyValuePair<uint, uint>(6, 4),
                    new KeyValuePair<uint, uint>(7, 2),
                    new KeyValuePair<uint, uint>(8, 1),
                };
            }

            // How many sub systems (moons) a planet has
            if (parentSize == SystemSize.InterLunar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(0, 3),
                    new KeyValuePair<uint, uint>(1, 2),
                    new KeyValuePair<uint, uint>(2, 3),
                    new KeyValuePair<uint, uint>(3, 2),
                    new KeyValuePair<uint, uint>(4, 1),
                    //new KeyValuePair<uint, uint>(5, 5),
                    //new KeyValuePair<uint, uint>(6, 4),
                    //new KeyValuePair<uint, uint>(7, 2),
                    //new KeyValuePair<uint, uint>(8, 1),
                };
            }

            // How many sub systems (whatever) a moon has
            if (parentSize == SystemSize.Lunar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(0, 100)
                };
            }

            throw new NotImplementedException($"System size {parentSize} is not implemented yet");
        }

        public List<KeyValuePair<uint, uint>> GenerateCenterObjectCountWeights(SystemSize parentSize)
        {
            if (parentSize == SystemSize.Solar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 2),
                    new KeyValuePair<uint, uint>(2, 2),
                    new KeyValuePair<uint, uint>(3, 1),
                };
            }

            if (parentSize == SystemSize.InterPlanetar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 5),
                    new KeyValuePair<uint, uint>(2, 5),
                    new KeyValuePair<uint, uint>(3, 1),
                };
            }

            if (parentSize == SystemSize.InterLunar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 8),
                    new KeyValuePair<uint, uint>(2, 2),
                };
            }

            if (parentSize == SystemSize.Lunar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 100)
                };
            }

            throw new NotImplementedException($"System size {parentSize} is not implemented yet");
        }
    }
}