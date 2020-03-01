using UnityEngine;

namespace TMovement.Interfaces
{
    public interface ITilePhysics
    {
        ICoordinate ApplyForce(ICoordinate coordinate,bool vertical , Vector2 maxCoordinate,int force = 1);
    }
}
