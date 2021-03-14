using AstroGame.Core.Structs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace AstroGame.Api.Converters
{
    public class CoordinateStringConverter : ValueConverter<Coordinates, string>
    {
        public CoordinateStringConverter(
            ConverterMappingHints mappingHints = null) : base(ConvertToExpression,
            ConvertFromExpression, mappingHints)
        {
        }

        private static readonly Expression<Func<Coordinates, string>> ConvertToExpression =
            coordinate => coordinate.ToString();

        private static readonly Expression<Func<string, Coordinates>>
            ConvertFromExpression = val => Coordinates.Parse(val);
    }
}