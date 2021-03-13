using System;
using System.Globalization;

namespace AstroGame.Core.Structs
{
    public struct Vector3
    {
        /// <summary>
        ///   <para>X component of the vector.</para>
        /// </summary>
        public float X;

        /// <summary>
        ///   <para>Y component of the vector.</para>
        /// </summary>
        public float Y;

        /// <summary>
        ///   <para>Z component of the vector.</para>
        /// </summary>
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        ///   <para>Shorthand for writing Vector3(0, 0, 0).</para>
        /// </summary>
        public static Vector3 Zero { get; } = new Vector3(0.0f, 0.0f, 0.0f);

        /// <summary>
        /// <para>Returns a formatted string for this vector.</para>
        /// </summary>
        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        ///   <para>Returns a formatted string for this vector.</para>
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture.NumberFormat);
        }

        /// <summary>
        ///   <para>Returns a formatted string for this vector.</para>
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <param name="formatProvider">An object that specifies culture-specific formatting.</param>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "F8";
            return
                $"({X.ToString(format, formatProvider)}, {Y.ToString(format, formatProvider)}, {Z.ToString(format, formatProvider)})";
        }
    }
}