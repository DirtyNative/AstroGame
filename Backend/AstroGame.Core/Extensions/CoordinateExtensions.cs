using AstroGame.Core.Structs;
using System;
using AstroGame.Core.Enums;

namespace AstroGame.Core.Extensions
{
    public static class CoordinateExtensions
    {
        /*public static Coordinates Increment(this Coordinates coordinates, SystemSize size)
        {
            return size switch
            {
                SystemSize.Interstellar => Increment(coordinates, interstellar: 1),
                SystemSize.InterPlanetar => Increment(coordinates, solar: 1),
                SystemSize.InterLunar => Increment(coordinates, interPlanetar: 1),
                SystemSize.Lunar => Increment(coordinates, interLunar: 1),
                _ => throw new NotImplementedException($"System size {size} is not implemented yet"),
            };
        } */

        private static Coordinates Increment(this Coordinates coordinates, int interstellar = 0, int solar = 0,
            int interPlanetar = 0,
            int interLunar = 0, int lunar = 0)
        {
            return new Coordinates(coordinates.InterStellar + interstellar, coordinates.Solar + solar,
                coordinates.InterPlanetar + interPlanetar, coordinates.InterLunar + interLunar, coordinates.Lunar + lunar);
        }

        public static Coordinates Increment(this Coordinates coordinates, SystemSize size, int step)
        {
            return size switch
            {
                SystemSize.Interstellar => Increment(coordinates, interstellar: step),
                SystemSize.Solar => Increment(coordinates, solar: step),
                SystemSize.InterPlanetar => Increment(coordinates, interPlanetar: step),
                SystemSize.InterLunar => Increment(coordinates, interLunar: step),
                SystemSize.Lunar => Increment(coordinates, lunar: step),
                _ => throw new NotImplementedException($"System size {size} is not implemented yet"),
            };
        }
    }
}