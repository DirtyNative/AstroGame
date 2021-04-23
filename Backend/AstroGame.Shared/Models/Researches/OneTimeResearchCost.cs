namespace AstroGame.Shared.Models.Researches
{
    public class OneTimeResearchCost : ResearchCost
    {
        public double Amount { get; set; }

        public virtual OneTimeResearch OneTimeResearch { get; set; }
    }
}