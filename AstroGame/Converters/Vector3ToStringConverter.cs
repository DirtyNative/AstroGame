using AstroGame.Api.Extensions;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using UnityEngine;

namespace AstroGame.Api.Converters
{
    public class Vector3ToStringConverter : ValueConverter<Vector3, string>
    {
        public Vector3ToStringConverter([NotNull] Expression<Func<Vector3, string>> convertToProviderExpression,
            [NotNull] Expression<Func<string, Vector3>> convertFromProviderExpression,
            [CanBeNull] ConverterMappingHints mappingHints = null) : base(convertToProviderExpression,
            convertFromProviderExpression, mappingHints)
        {
        }

        public override Expression<Func<string, Vector3>> ConvertFromProviderExpression { get; } = s => s.ToVector3();

        public override Expression<Func<Vector3, string>> ConvertToProviderExpression { get; } =
            vector => vector.ToString();
    }
}