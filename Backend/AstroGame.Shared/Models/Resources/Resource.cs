using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AstroGame.Shared.Models.Resources
{
    public abstract class Resource
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public uint NaturalOccurrenceWeight { get; set; }

        [JsonIgnore] public virtual List<StellarObjectResource> StellarObjectResources { get; set; }
        [JsonIgnore] public virtual List<StoredResource> StoredResources { get; set; }
    }
}