namespace AstroGame.Shared.Models.Technologies.FinishedTechnologies
{
    public class LevelablePlayerDependentFinishedTechnology : PlayerDependentFinishedTechnology,
        ILevelableFinishedTechnology
    {
        public uint Level { get; set; }
    }
}