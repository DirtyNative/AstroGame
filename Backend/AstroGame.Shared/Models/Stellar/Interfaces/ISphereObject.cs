namespace AstroGame.Shared.Models.Stellar.Interfaces
{
    /// <summary>
    /// Spheres act a little different than other objects
    /// </summary>
    public interface ISphereObject
    {
        /// <summary>
        /// The tilt of this object
        /// </summary>
        double AxialTilt { get; set; }
    }
}
