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
                // this logic will go to Test()
                while(x > mx)
                {
                    if(X < mX)
                    {
                        x = x - mx;
                        X++;
                    }
                    else
                    {
                        x = mx;
                        X = mX;
                    }

                }
                while (x < 0)
                {

                }
            }
            else
            {

            }
            return null;
        }
        //TODO : Finish this
        private void Test(out int x,out int X, int mx,int mX)
        {
            x = 0;
            X = 0;
        }

    }
}
