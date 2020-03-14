namespace TiMovi.Interfaces
{
    /// <summary>
    /// Interface to simulate TilePhysics
    /// </summary>
    [System.Obsolete("No interfaces")]
    public interface ITilePhysics
    {
        ICoordinate ApplyForce(ICoordinate coordinate, ICoordinate maxCoordinates, bool vertical, int force = 1);
    }
}
