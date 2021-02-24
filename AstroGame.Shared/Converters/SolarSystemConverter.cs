using AstroGame.Shared.Models.StellarSystems;
using Newtonsoft.Json;
using System;

namespace AstroGame.Shared.Converters
{
    public class SolarSystemConverter : JsonConverter<SolarSystem>
    {
        public override void WriteJson(JsonWriter writer, SolarSystem value, JsonSerializer serializer)
        {
            string jsonData = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });

            writer.WriteValue(jsonData);
        }

        public override SolarSystem ReadJson(JsonReader reader, Type objectType, SolarSystem existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            return null;
        }
    }
}