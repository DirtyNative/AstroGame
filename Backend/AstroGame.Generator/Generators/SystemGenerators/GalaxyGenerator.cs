using AspNetCore.ServiceRegistration.Dynamic;
using AstroGame.Shared.Models.Stellar.BaseTypes;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace AstroGame.Generator.Generators.SystemGenerators
{
    [ScopedService]
    public class GalaxyGenerator : IGenerator
    {
        private const double MinY = -5;
        private const double MaxY = 5;

        private const float Spin = 3f;
        private const double ArmSpread = 0.1d;
        private const double StarsAtCenterRatio = 3;

        private readonly SolarSystemGenerator _solarSystemGenerator;
        private readonly Random _random = new Random();

        public GalaxyGenerator(SolarSystemGenerator solarSystemGenerator)
        {
            _solarSystemGenerator = solarSystemGenerator;
        }

        public Galaxy Generate(int countSystems, int countArms)
        {
            var starsPerArm = countSystems / countArms;
            var positions = new List<Vector3>();

            var galaxy = new Galaxy()
            {
                Id = Guid.NewGuid(),
                Systems = new List<StellarSystem>()
            };

            for (var i = 0; i < countArms; i++)
            {
                var arm = GenerateArm(starsPerArm, i / (float) countArms, Spin, ArmSpread, StarsAtCenterRatio);

                positions.AddRange(arm);
            }

            uint systemNumber = 1;

            foreach (var solarSystem in positions.Select(pos => GenerateSolarSystem(galaxy, pos, systemNumber)))
            {
                galaxy.Systems.Add(solarSystem);
                systemNumber++;
            }

            return galaxy;
        }

        private SolarSystem GenerateSolarSystem(StellarSystem parent, Vector3 position, uint systemNumber)
        {
            return _solarSystemGenerator.Generate(parent, position, systemNumber);
            //return _solarSystemGenerator.GenerateRecursive(parent, position, systemNumber);
        }

        private IEnumerable<Vector3> GenerateArm(int numOfStars, float rotation, float spin, double armSpread,
            double starsAtCenterRatio)
        {
            var result = new Vector3[numOfStars];


            for (var i = 0; i < numOfStars; i++)
            {
                var part = i / (double) numOfStars;
                part = Math.Pow(part, starsAtCenterRatio);

                var distanceFromCenter = (float) part;
                var position = (part * spin + rotation) * Math.PI * 2;

                var xFluctuation = (Pow3Constrained(_random.NextDouble()) - Pow3Constrained(_random.NextDouble())) *
                                   armSpread;
                var zFluctuation = (Pow3Constrained(_random.NextDouble()) - Pow3Constrained(_random.NextDouble())) *
                                   armSpread;

                var resultX = (float) Math.Cos(position) * distanceFromCenter / 2 + 0.5f + (float) xFluctuation;
                var resultZ = (float) Math.Sin(position) * distanceFromCenter / 2 + 0.5f + (float) zFluctuation;

                result[i] = new Vector3(resultX, 0, resultZ);
            }

            return result;
        }

        private static double Pow3Constrained(double x)
        {
            var value = Math.Pow(x - 0.5, 3) * 4 + 0.5d;
            return Math.Max(Math.Min(1, value), 0);
        }
    }
}