using AstroGame.Shared.Models.Technologies;

namespace AstroGame.Shared.Models.Researches
{
    public class OneTimeResearchCost : TechnologyCost
    {
        public double Amount { get; set; }

        public virtual OneTimeResearch OneTimeResearch { get; set; }
    }
}