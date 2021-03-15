using AstroGame.Shared.Enums;
using System.Collections.Generic;

namespace AstroGame.Generator.Assets
{
    public static class Assets
    {
        public static List<string> MoonAssets = new List<string>()
        {
            "Moon_1",
            "Moon_2",
        };

        public static List<string> VolcanoPlanetAssets = new List<string>()
        {
            "Planet_Volcano_1",
            "Planet_Volcano_2",
            "Planet_Volcano_3",
            "Planet_Volcano_4",
            "Planet_Volcano_5",
            "Planet_Volcano_6",
            "Planet_Volcano_7",
            "Planet_Volcano_8",
        };

        public static List<string> DesertPlanetAssets = new List<string>()
        {
            "Planet_Desert_1",
            "Planet_Desert_2",
            "Planet_Desert_3",
            "Planet_Desert_4",
            "Planet_Desert_5",
            "Planet_Desert_6",
            "Planet_Desert_7",
            "Planet_Desert_8",
            "Planet_Desert_9",
        };

        public static List<string> ContinentalPlanetAssets = new List<string>()
        {
            "Planet_Continental_1",
            "Planet_Continental_2",
            "Planet_Continental_3",
        };

        public static List<string> OceanPlanetAssets = new List<string>()
        {
            "Planet_Ocean_1",
            "Planet_Ocean_2",
            "Planet_Ocean_3",
            "Planet_Ocean_4",
            "Planet_Ocean_5",
            "Planet_Ocean_6",
        };

        public static List<string> RockPlanetAssets = new List<string>()
        {
            "Planet_Rock_1",
            "Planet_Rock_2",
            "Planet_Rock_3",
        };

        public static List<string> GasPlanetAssets = new List<string>()
        {
            "Planet_Gas_1",
            "Planet_Gas_2",
        };

        public static List<string> IcePlanetAssets = new List<string>()
        {
            "Planet_Ice_1",
            "Planet_Ice_2",
            "Planet_Ice_3",
        };

        public static List<string> GaiaPlanetAssets = new List<string>()
        {
            "Planet_Gaia_1",
            "Planet_Gaia_2",
            "Planet_Gaia_3",
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
            "Star_BrownDwarf_1",
            "Star_BrownDwarf_2",
            "Star_BrownDwarf_3",
        };

        public static List<string> YellowDwarfStarAssets = new List<string>()
        {
            "Star_YellowDwarf_1",
            "Star_YellowDwarf_2",
            "Star_YellowDwarf_3",
        };

        public static List<string> WhiteStarAssets = new List<string>()
        {
            "Star_WhiteStar_1",
            "Star_WhiteStar_2",
            "Star_WhiteStar_3",
        };

        public static List<string> RedGiantStarAssets = new List<string>()
        {
            "Star_RedGiant_1",
            "Star_RedGiant_2",
            "Star_RedGiant_3",
        };

        public static List<string> BlueGiantStarAssets = new List<string>()
        {
            "Star_BlueGiant_1",
            "Star_BlueGiant_2",
            "Star_BlueGiant_3",
        };

        public static Dictionary<StarType, List<string>> StarAssets = new Dictionary<StarType, List<string>>()
        {
            {StarType.BrownDwarf, BrownDwarfStarAssets},
            {StarType.YellowDwarf, YellowDwarfStarAssets},
            {StarType.WhiteStar, WhiteStarAssets},
            {StarType.RedGiant, RedGiantStarAssets},
            {StarType.BlueGiants, BlueGiantStarAssets},
        };
    }
}