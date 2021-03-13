using AstroGame.Core.Helpers;
using AstroGame.Generator.Enums;
using AstroGame.Generator.Generators.ObjectGenerators;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    public abstract class GeneratorBase
    {
        private readonly StarGenerator _starGenerator;
        private readonly PlanetGenerator _planetGenerator;
        private readonly MoonGenerator _moonGenerator;

        protected GeneratorBase(StarGenerator starGenerator, PlanetGenerator planetGenerator, MoonGenerator moonGenerator)
        {
            _starGenerator = starGenerator;
            _planetGenerator = planetGenerator;
            _moonGenerator = moonGenerator;
        }

        public StellarSystem GenerateSystem(StellarSystem parent, SystemSize parentSize,
            List<KeyValuePair<Type, uint>> objectWeights,
            uint countObjects)
        {
            // If there is an invalid count provided, just return nothing
            if (countObjects < 1 || objectWeights.Count < 1)
            {
                return null;
            }

            var system = new MultiObjectSystem(parent);

            system.CenterObjects = GenerateCenterObjects(system, objectWeights, countObjects);
            system.Satellites = GenerateSatelliteSystems(system, parentSize);

            return system;
        }

        public T GenerateChildren<T>(T system, SystemSize size,
            List<KeyValuePair<Type, uint>> objectWeights,
            uint countObjects) where T : MultiObjectSystem
        {
            // If there is an invalid count provided, just return nothing
            if (countObjects < 1)
            {
                return null;
            }

            system.CenterObjects = GenerateCenterObjects(system, objectWeights, countObjects);
            system.Satellites = GenerateSatelliteSystems(system, size);

            return system;
        }

        private StellarObject GenerateObject(MultiObjectSystem parentSystem, List<KeyValuePair<Type, uint>> objectWeights,
            uint order)
        {
            if (objectWeights.Count == 0)
            {
                Debug.WriteLine("");
            }

            var objectType = RandomCalculator.SelectByWeight(objectWeights);

            if (objectType == typeof(Star))
            {
                return _starGenerator.Generate(parentSystem, order);
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
        }

        private List<StellarObject> GenerateCenterObjects(MultiObjectSystem parentSystem,
            List<KeyValuePair<Type, uint>> objectWeights, uint countObjects)
        {
            var list = new List<StellarObject>();

            for (uint i = 0; i < countObjects; i++)
            {
                var stellarObject = GenerateObject(parentSystem, objectWeights, i +1);
                list.Add(stellarObject);
            }

            return list;
        }

        private List<StellarSystem> GenerateSatelliteSystems(StellarSystem parentSystem, SystemSize parentSize)
        {
            var list = new List<StellarSystem>();

            // Determines how many satellite systems (not the objects) will be generated
            var countSatelliteWeights = GenerateSatelliteCountWeightBySize(parentSize);
            var countSatellites = RandomCalculator.SelectByWeight(countSatelliteWeights);

            // The objects appearance possibilities
            var objectWeights = GenerateStellarObjectWeightsBySize(parentSize);

            // Defines how many center objects will be generated
            var objectCountWeights = GenerateCenterObjectCountWeights(parentSize);
            var countObjects = RandomCalculator.SelectByWeight(objectCountWeights);

            for (uint i = 0; i < countSatellites; i++)
            {
                var system = GenerateSystem(parentSystem, parentSize + 1, objectWeights, countObjects);

                if (system == null)
                {
                    // There is nothing to add, continue
                    continue;
                }


                list.Add(system);
            }

            return list;
        }

        protected List<KeyValuePair<Type, uint>> GenerateStellarObjectWeightsBySize(SystemSize parentSize)
        {
            if (parentSize == SystemSize.Interstellar)
            {
                return new List<KeyValuePair<Type, uint>>()
                {
                    new KeyValuePair<Type, uint>(typeof(Star), 10),
                };
            }

            if (parentSize == SystemSize.Solar)
            {
                return new List<KeyValuePair<Type, uint>>()
                {
                    new KeyValuePair<Type, uint>(typeof(Planet), 100),
                };
            }

            if (parentSize == SystemSize.Planetary)
            {
                return new List<KeyValuePair<Type, uint>>()
                {
                    new KeyValuePair<Type, uint>(typeof(Moon), 100),
                };
            }

            if (parentSize == SystemSize.Lunar)
            {
                // TODO: Define moons satellite types
                return new List<KeyValuePair<Type, uint>>()
                {

                };
            }

            throw new NotImplementedException($"System size {parentSize} is not implemented yet");
        }

        /// <summary>
        /// Generates the count of satellites a StellarObject has
        /// </summary>
        /// <param name="parentSize"></param>
        /// <returns></returns>
        private List<KeyValuePair<uint, uint>> GenerateSatelliteCountWeightBySize(SystemSize parentSize)
        {
            // How many sub systems (stars, black holes, etc) a solar system has
            if (parentSize == SystemSize.Interstellar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 100),
                };
            }

            // How many sub systems (planets) a star has
            if (parentSize == SystemSize.Solar)
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
            if (parentSize == SystemSize.Planetary)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(0, 1),
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

        private List<KeyValuePair<uint, uint>> GenerateCenterObjectCountWeights(SystemSize parentSize)
        {
            if (parentSize == SystemSize.Interstellar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 2),
                    new KeyValuePair<uint, uint>(2, 2),
                    new KeyValuePair<uint, uint>(3, 1),
                };
            }

            if (parentSize == SystemSize.Solar)
            {
                return new List<KeyValuePair<uint, uint>>()
                {
                    new KeyValuePair<uint, uint>(1, 5),
                    new KeyValuePair<uint, uint>(2, 5),
                    new KeyValuePair<uint, uint>(3, 1),
                };
            }

            if (parentSize == SystemSize.Planetary)
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