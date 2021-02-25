using System;
using System.Diagnostics;
using AstroGame.Shared.Models.Stellar.StellarSystems;
using Newtonsoft.Json;

namespace AstroGame.Shared.Converters
{
    public class MultiObjectSystemConverter : JsonConverter<MultiObjectSystem>
    {
        public override void WriteJson(JsonWriter writer, MultiObjectSystem value, JsonSerializer serializer)
        {
            string jsonData = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });

            writer.WriteValue(jsonData);
        }

        public override MultiObjectSystem ReadJson(JsonReader reader, Type objectType, MultiObjectSystem existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            return null;
        }
    }
}