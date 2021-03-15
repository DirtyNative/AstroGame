using AstroGame.Core.Structs;
using AstroGame.Shared.Models.Stellar.StellarObjects;
using System;

namespace AstroGame.Generator.Generators.NameGenerators
{
    public class StellarObjectNameGenerator
    {
        public static string Generate(string systemName, Coordinates coordinates, Type type)
        {
            var subName = GenerateSubName(coordinates, type);

            return $"{systemName} {subName}";
        }

        private static string GenerateSubName(Coordinates coordinates, Type type)
        {
            var subName = string.Empty;

            if (type == typeof(Star) && coordinates.Solar != 0)
            {
                subName += $"{(char) (coordinates.Solar + 64)}";
            }

            if (coordinates.InterPlanetar != 0)
            {
                subName += $"{coordinates.InterPlanetar}";
            }

            if (coordinates.InterLunar != 0)
            {
                subName += $"-{(char) (coordinates.InterLunar + 64)}";
            }

            if (coordinates.Lunar != 0)
            {
                subName += $"";
            }

            return subName;
        }
    }
}