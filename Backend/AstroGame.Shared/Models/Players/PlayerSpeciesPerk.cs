using System;

namespace AstroGame.Shared.Models.Players
{
    public class PlayerSpeciesPerk
    {
        public Guid Id { get; set; }
        public Guid PlayerSpeciesId { get; set; }
        public Guid PerkId { get; set; }

        public PlayerSpecies PlayerSpecies { get; set; }
        public Perk Perk { get; set; }
    }
}