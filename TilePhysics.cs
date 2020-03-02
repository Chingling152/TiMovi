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


                //TODO : put this logic in Test()
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
        private void Test(ref int v, ref int V, int mv,int mV)
        {
            while (v > mv)
            {
                if(++V > mV)
                {
                    V = mV;
                    v = mv;
                }
                else
                {
                    v = v - mv;
                }
            }

        }

    }
}
