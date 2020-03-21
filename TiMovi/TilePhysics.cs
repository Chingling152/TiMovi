using Colver.Main;
using UnityEngine;

namespace TiMovi
{
    /// <summary>
    /// Defines a class to control TilePhysics 
    /// </summary>
    public static class TilePhysics
    {
        /// <summary>
        /// Changes a coordinate to a especific force in a certain direction
        /// </summary>
        /// <param name="coordinate">The actual coordinate of an Entity</param>
        /// <param name="maxCoordinates">The max coordinates of the map</param>
        /// <param name="vertical">Defines if the movement is vertical</param>
        /// <param name="force">Define the amount of the tiles the Eneity will move (use negative values to back)</param>
        /// <returns>Returns the new coordinate result of the movement</returns>
        [System.Obsolete("Use this method with the Vector2 params (direction)")]
        public static Coordinate ApplyForce(Coordinate coordinate, Coordinate maxCoordinates, bool vertical, int force = 1)
        {
            if (!vertical)
            {
                int x = (int)coordinate.Local.x + force;
                int X = (int)coordinate.Global.x;

                int mx = (int)maxCoordinates.Local.x;
                int mX = (int)maxCoordinates.Global.x;

                VerifyLimits(ref x, ref X, mx, mX);

                coordinate.Local.Set(x, coordinate.Local.y);
                coordinate.Global.Set(X, coordinate.Global.y);
            }
            else
            {
                int y = (int)coordinate.Local.y + force;
                int Y = (int)coordinate.Global.y;

                int my = (int)maxCoordinates.Local.y;
                int mY = (int)maxCoordinates.Global.y;

                VerifyLimits(ref y, ref Y, my, mY);

                coordinate.Local.Set(coordinate.Local.x, y);
                coordinate.Global.Set(coordinate.Global.x, Y);
            }
            return coordinate;
        }

        /// <summary>
        /// Verify the limits of some direction and make changes if some limits are passed
        /// </summary>
        /// <param name="v">Could be local x or the local y of some coordinate</param>
        /// <param name="V">Could be global x or the global y of some coordinate</param>
        /// <param name="mv">Could be max local x or the max local y of some coordinate</param>
        /// <param name="mV">Could be max global x or the max global y of some coordinate</param>
        private static void VerifyLimits(ref int v, ref int V, int mv, int mV)
        {
            if (v > mv)
            {
                v = v - mv;
                V++;
                V = V > mV ? mV : V;
            }

            if (v < 0)
            {
                v = mv - System.Math.Abs(v);
                V = V < 0 ? 0 : V;
            }

        }
        /// <summary>
        /// Changes a coordinate to a especific force in a certain direction
        /// </summary>
        /// <param name="coordinate">The actual coordinate of an Entity</param>
        /// <param name="maxCoordinates">The max coordinates of the map</param>
        /// <param name="direction">Defines the direction of the Entity will move</param>
        /// <returns>Returns the new coordinate result of the movement</returns>
        public static Coordinate ApplyForce(Coordinate coordinate, Coordinate maxCoordinates, Vector2 direction)
        {
            coordinate.Local += direction;

            while (coordinate.Local.GreaterThan(maxCoordinates.Local))
            {
                if (coordinate.Local.x > maxCoordinates.Local.x || coordinate.Local.x < 0)
                {
                    int x = (int)coordinate.Local.x;
                    int X = (int)coordinate.Global.x;

                    int mx = (int)maxCoordinates.Local.x;
                    int mX = (int)maxCoordinates.Global.x;

                    VerifyLimits(ref x, ref X, mx, mX);

                    coordinate.Local.Set(x, coordinate.Local.y);
                    coordinate.Global.Set(X, coordinate.Global.y);
                }
                if (coordinate.Local.y > maxCoordinates.Local.y || coordinate.Local.y < 0)
                {
                    int y = (int)coordinate.Local.y;
                    int Y = (int)coordinate.Global.y;

                    int my = (int)maxCoordinates.Local.y;
                    int mY = (int)maxCoordinates.Global.y;

                    VerifyLimits(ref y, ref Y, my, mY);

                    coordinate.Local.Set(coordinate.Local.x, y);
                    coordinate.Global.Set(coordinate.Global.x, Y);
                }
            }

            return coordinate;
        }
    }
}
