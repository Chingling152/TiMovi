namespace TMovement.Interfaces
{
    public interface ITilePhysics
    {
        ICoordinate ApplyForce(ICoordinate coordinate, ICoordinate maxCoordinates, bool vertical, int force = 1);
    }
}
