using AstroGame.Api.Extensions;
using AstroGame.Core.Structs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;

namespace AstroGame.Api.Converters
{
    public class Vector3ToStringConverter : ValueConverter<Vector3, string>
    {
        public Vector3ToStringConverter(Expression<Func<Vector3, string>> convertToProviderExpression,
            Expression<Func<string, Vector3>> convertFromProviderExpression,
            ConverterMappingHints mappingHints = null) : base(convertToProviderExpression,
            convertFromProviderExpression, mappingHints)
        {
        }

        public override Expression<Func<string, Vector3>> ConvertFromProviderExpression { get; } = s => s.ToVector3();

        public override Expression<Func<Vector3, string>> ConvertToProviderExpression { get; } =
            vector => vector.ToString();
    }
}