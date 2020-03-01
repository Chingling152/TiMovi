using TMovement.Interfaces;
using UnityEngine;

namespace TMovement
{
    public class TilePhysics : ITilePhysics
    {
        [System.Obsolete("Not Applied")]
        public ICoordinate ApplyForce(ICoordinate coordinate, bool vertical, int force = 1)
        {
            throw new System.NotImplementedException();
        }

        [System.Obsolete("Not Applied")]
        public ICoordinate ApplyForce(ICoordinate coordinate, bool vertical, Vector2 maxCoordinate, int force = 1)
        {
            var returnCoordinate = (Coordinate)coordinate;

            if (!vertical)
            {
                int x = (int)returnCoordinate.Local.x + force;
                int X = (int)returnCoordinate.Global.x;

                if (x > maxCoordinate.x)
                {

                }

                if(x < 0)
                {
                    x = (int)maxCoordinate.x;
                }
            }
            else
            {

            }
            return null;
        }
    }
}
