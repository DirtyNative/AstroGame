namespace AstroGame.Shared.Models.Resources
{
    public class Element : Resource
    {
        public string Symbol { get; set; }

        public ElementType Type { get; set; }

        // Indicates if this resource does spawn on every planet of a new planet
        public bool IsBaseResource { get; set; }
    }
}