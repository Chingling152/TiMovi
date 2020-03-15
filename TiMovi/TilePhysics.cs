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
        public static Coordinate ApplyForce(Coordinate coordinate, Coordinate maxCoordinates, bool vertical, int force = 1)
        {
            var returnCoordinate = coordinate;
            var limits = maxCoordinates;

            if (!vertical)
            {
                int x = (int)returnCoordinate.Local.x + force;
                int X = (int)returnCoordinate.Global.x;

                int mx = (int)limits.Local.x;
                int mX = (int)limits.Global.x;

                VerifyLimits(ref x, ref X, mx, mX);

                returnCoordinate.Local.Set(x,returnCoordinate.Local.y);
                returnCoordinate.Global.Set(X, returnCoordinate.Global.y);
            }
            else
            {
                int y = (int)returnCoordinate.Local.y + force;
                int Y = (int)returnCoordinate.Global.y;

                int my = (int)limits.Local.y;
                int mY = (int)limits.Global.y;

                VerifyLimits(ref y, ref Y, my, mY);

                returnCoordinate.Local.Set(returnCoordinate.Local.x,y);
                returnCoordinate.Global.Set(returnCoordinate.Global.x, Y);
            }
            return returnCoordinate;
        }

        /// <summary>
        /// Verify the limits of some direction and make changes if some limits are passed
        /// </summary>
        /// <param name="v">Could be local x or the local y of some coordinate</param>
        /// <param name="V">Could be global x or the global y of some coordinate</param>
        /// <param name="mv">Could be max local x or the max local y of some coordinate</param>
        /// <param name="mV">Could be max global x or the max global y of some coordinate</param>
        private static void VerifyLimits(ref int v, ref int V, int mv,int mV)
        {
            if (v > mv)
            {
                v = v - mv;
                V++;
                V = V > mV? mV : V;
            }

            if(v < 0)
            {
                v = mv - System.Math.Abs(v);
                V = V < 0 ? 0 : V;
            }

        }

    }
}
