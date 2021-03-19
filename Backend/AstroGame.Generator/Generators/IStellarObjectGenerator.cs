using AstroGame.Core.Structs;
using AstroGame.Shared.Models.Stellar.BaseTypes;

namespace AstroGame.Generator.Generators
{
    public interface IStellarObjectGenerator<T> where T : StellarObject
    {
        T Generate(StellarSystem parent, Coordinates coordinates, string systemName);
    }
}