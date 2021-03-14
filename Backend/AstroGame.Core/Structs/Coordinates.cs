namespace AstroGame.Core.Structs
{
    public class Coordinates
    {
        public int InterStellar { get; set; }
        public int Solar { get; set; }
        public int InterPlanetar { get; set; }
        public int InterLunar { get; set; }
        public int Lunar { get; set; }

        public Coordinates(int interStellar, int solar, int interPlanetar, int interLunar, int lunar)
        {
            InterStellar = interStellar;
            Solar = solar;
            InterPlanetar = interPlanetar;
            InterLunar = interLunar;
            Lunar = lunar;
        }

        public static Coordinates System(int systemCoordinate)
        {
            return new Coordinates(systemCoordinate, 0, 0, 0, 0);
        }

        public override string ToString()
        {
            return $"({InterStellar}, {Solar}, {InterPlanetar}, {InterLunar}, {Lunar})";
        }

        public static Coordinates Parse(string val)
        {
            val = val.Replace("(", string.Empty);
            val = val.Replace(")", string.Empty);
            val = val.Replace(",", string.Empty);

            var split = val.Split(" ");

            var interStellar = int.Parse(split[0]);
            var stellar = int.Parse(split[1]);
            var interPlanetar = int.Parse(split[2]);
            var interLunar = int.Parse(split[3]);
            var lunar = int.Parse(split[4]);

            return new Coordinates(interStellar, stellar, interPlanetar, interLunar, lunar);
        }
    }
}