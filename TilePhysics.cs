using TMovement.Interfaces;

namespace TMovement
{
    public class TilePhysics : ITilePhysics
    {
        [System.Obsolete("Not Applied")]
        public ICoordinate ApplyForce(ICoordinate coordinate, ICoordinate maxCoordinates, bool vertical, int force = 1)
        {
            var returnCoordinate = (Coordinate)coordinate;
            var limits = (Coordinate)maxCoordinates;

            if (!vertical)
            {
                int x = (int)returnCoordinate.Local.x + force;
                int X = (int)returnCoordinate.Global.x;

                int mx = (int)limits.Local.x;
                int mX = (int)limits.Global.x;

                Test(ref x, ref X, mx, mX);

                returnCoordinate.Local.Set(x,returnCoordinate.Local.y);
                returnCoordinate.Global.Set(X, returnCoordinate.Global.y);
            }
            else
            {
                int y = (int)returnCoordinate.Local.y + force;
                int Y = (int)returnCoordinate.Global.y;

                int my = (int)limits.Local.y;
                int mY = (int)limits.Global.y;

                Test(ref y, ref Y, my, mY);

                returnCoordinate.Local.Set(returnCoordinate.Local.x,y);
                returnCoordinate.Global.Set(returnCoordinate.Global.x, Y);
            }
            return returnCoordinate;
        }
        //TODO : Finish this (Test this)
        private void Test(ref int v, ref int V, int mv,int mV)
        {
            if (v > mv)
            {
                if (++V < mV)
                {
                    v = 0;
                    V = mV;
                }
                else
                {
                    v = v - mv;
                    V = mV;
                }
            }

            if(v < 0)
            {
                if(--V > 0)
                {
                    v = mv;
                }
                else
                {
                    v = 0;
                    V = 0;
                }
            }

        }

    }
}
