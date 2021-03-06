﻿using AstroGame.Shared.Enums;
using AstroGame.Shared.Models.StellarSystems;

namespace AstroGame.Shared.Models.StellarObjects
{
    public class Star : StellarObject
    {
        public Star()
        {
        }

        public Star(StellarSystem parent) : base(parent)
        {
        }

        public StarType StarType { get; set; }
        public int AverageTemperature { get; set; }
    }
}