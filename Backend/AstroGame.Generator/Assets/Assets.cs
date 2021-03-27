using AstroGame.Shared.Enums;
using System.Collections.Generic;

namespace AstroGame.Generator.Assets
{
    public static class Assets
    {
        public static List<string> MoonAssets = new List<string>()
        {
            "Moon_1.png",
            "Moon_2.png",
        };

        public static List<string> VolcanoPlanetAssets = new List<string>()
        {
            "Planet_Volcano_1.png",
            "Planet_Volcano_2.png",
            "Planet_Volcano_3.png",
            "Planet_Volcano_4.png",
            "Planet_Volcano_5.png",
            "Planet_Volcano_6.png",
            "Planet_Volcano_7.png",
            "Planet_Volcano_8.png",
        };

        public static List<string> DesertPlanetAssets = new List<string>()
        {
            "Planet_Desert_1.png",
            "Planet_Desert_2.png",
            "Planet_Desert_3.png",
            "Planet_Desert_4.png",
            "Planet_Desert_5.png",
            "Planet_Desert_6.png",
            "Planet_Desert_7.png",
            "Planet_Desert_8.png",
            "Planet_Desert_9.png",
        };

        public static List<string> ContinentalPlanetAssets = new List<string>()
        {
            "Planet_Continental_1.png",
            "Planet_Continental_2.png",
            "Planet_Continental_3.png",
        };

        public static List<string> OceanPlanetAssets = new List<string>()
        {
            "Planet_Ocean_1.png",
            "Planet_Ocean_2.png",
            "Planet_Ocean_3.png",
            "Planet_Ocean_4.png",
            "Planet_Ocean_5.png",
            "Planet_Ocean_6.png",
        };

        public static List<string> RockPlanetAssets = new List<string>()
        {
            "Planet_Rock_1.png",
            "Planet_Rock_2.png",
            "Planet_Rock_3.png",
        };

        public static List<string> GasPlanetAssets = new List<string>()
        {
            "Planet_Gas_1.png",
            "Planet_Gas_2.png",
        };

        public static List<string> IcePlanetAssets = new List<string>()
        {
            "Planet_Ice_1.png",
            "Planet_Ice_2.png",
            "Planet_Ice_3.png",
        };

        public static List<string> GaiaPlanetAssets = new List<string>()
        {
            "Planet_Gaia_1.png",
            "Planet_Gaia_2.png",
            "Planet_Gaia_3.png",
        };

        public static Dictionary<PlanetType, List<string>> PlanetAssets = new Dictionary<PlanetType, List<string>>()
        {
            {PlanetType.Volcano, VolcanoPlanetAssets},
            {PlanetType.Desert, DesertPlanetAssets},
            {PlanetType.Continental, ContinentalPlanetAssets},
            {PlanetType.Ocean, OceanPlanetAssets},
            {PlanetType.Rock, RockPlanetAssets},
            {PlanetType.Gas, GasPlanetAssets},
            {PlanetType.Ice, IcePlanetAssets},
            {PlanetType.Gaia, GaiaPlanetAssets},
        };

        public static List<string> BrownDwarfStarAssets = new List<string>()
        {
            "Star_BrownDwarf_1.png",
            "Star_BrownDwarf_2.png",
            "Star_BrownDwarf_3.png",
        };

        public static List<string> YellowDwarfStarAssets = new List<string>()
        {
            "Star_YellowDwarf_1.png",
            "Star_YellowDwarf_2.png",
            "Star_YellowDwarf_3.png",
        };

        public static List<string> WhiteStarAssets = new List<string>()
        {
            "Star_WhiteStar_1.png",
            "Star_WhiteStar_2.png",
            "Star_WhiteStar_3.png",
        };

        public static List<string> RedGiantStarAssets = new List<string>()
        {
            "Star_RedGiant_1.png",
            "Star_RedGiant_2.png",
            "Star_RedGiant_3.png",
        };

        public static List<string> BlueGiantStarAssets = new List<string>()
        {
            "Star_BlueGiant_1.png",
            "Star_BlueGiant_2.png",
            "Star_BlueGiant_3.png",
        };

        public static Dictionary<StarType, List<string>> StarAssets = new Dictionary<StarType, List<string>>()
        {
            {StarType.BrownDwarf, BrownDwarfStarAssets},
            {StarType.YellowDwarf, YellowDwarfStarAssets},
            {StarType.WhiteStar, WhiteStarAssets},
            {StarType.RedGiant, RedGiantStarAssets},
            {StarType.BlueGiants, BlueGiantStarAssets},
        };

        public static List<string> BlackHoleAssets = new List<string>()
        {
            "BlackHole_1.png",
            "BlackHole_2.png",
        };
    }
}