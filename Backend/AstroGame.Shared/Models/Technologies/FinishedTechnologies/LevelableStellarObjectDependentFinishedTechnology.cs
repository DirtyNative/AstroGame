namespace AstroGame.Shared.Models.Technologies.FinishedTechnologies
{
    public class LevelableStellarObjectDependentFinishedTechnology : StellarObjectDependentFinishedTechnology,
        ILevelableFinishedTechnology
    {
        public uint Level { get; set; }
    }
}