using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using UnityEngine;

namespace AstroGame.Api.Converters
{
    public class Vector3Converter : ValueConverter<Vector3, string>
    {
        public Vector3Converter([NotNull] Expression<Func<Vector3, string>> convertToProviderExpression,
            [NotNull] Expression<Func<string, Vector3>> convertFromProviderExpression,
            [CanBeNull] ConverterMappingHints mappingHints = null) : base(convertToProviderExpression,
            convertFromProviderExpression, mappingHints)
        {
        }
    }
}