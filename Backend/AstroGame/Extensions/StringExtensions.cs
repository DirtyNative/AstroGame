using System.Globalization;
using UnityEngine;

namespace AstroGame.Api.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension to parse a Vector3 from a string.
        /// This is needed when storing inside a DB
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Vector3 ToVector3(this string val)
        {
            val = val.Replace("(", string.Empty);
            val = val.Replace(")", string.Empty);
            val = val.Replace(",", string.Empty);

            var split = val.Split(" ");

            var x = float.Parse(split[0], CultureInfo.InvariantCulture);
            var y = float.Parse(split[1], CultureInfo.InvariantCulture);
            var z = float.Parse(split[2], CultureInfo.InvariantCulture);

            return new Vector3(x, y, z);
        }
    }
}