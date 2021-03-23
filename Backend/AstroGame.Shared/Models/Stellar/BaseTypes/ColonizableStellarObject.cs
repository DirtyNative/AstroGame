using AstroGame.Shared.Models.Stellar.Interfaces;
using System;
using AstroGame.Shared.Models.Players;

namespace AstroGame.Shared.Models.Stellar.BaseTypes
{
    public abstract class ColonizableStellarObject : StellarObject, IColonizable
    {
        protected ColonizableStellarObject()
        {
        }

        protected ColonizableStellarObject(StellarSystem parent) : base(parent)
        {
        }

        public Guid? ColonizedStellarObjectId { get; set; }
        public ColonizedStellarObject ColonizedStellarObject { get; set; }
    }
}