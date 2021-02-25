namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    /// <summary>
    /// Defines an object which can be rendered within Unity
    /// </summary>
    public interface IRenderable
    {
        /// <summary>
        /// The name of Unity's Prefab which can be rendered
        /// </summary>
        string PrefabName { get; set; }

        public double Scale { get; set; }
    }
}