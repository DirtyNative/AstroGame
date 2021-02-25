using System;

namespace AstroGame.Shared.Models.Resources.Elements
{
    public class Element
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public ElementType Type { get; set; }

        public bool IsRadioactive { get; set; }
    }
}