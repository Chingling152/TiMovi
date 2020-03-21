using TiMovi;
using Xunit;
using UnityEngine;

namespace WorldUnitTest
{
    public class TilePhysicsTest
    {
        private System.Random rdm;

        public TilePhysicsTest()
        {
            rdm = new System.Random();
        }
        [Fact]
        public void OnApplyForceShouldMoveToDirection()
        {
            // Plan
            var direction = new Vector2(rdm.Next(-1, 2), rdm.Next(-1, 2));

            Coordinate coord = new Coordinate(
                Local: new Vector2(rdm.Next(5, 11), rdm.Next(5, 11)),
                Global: new Vector2(rdm.Next(5, 11), rdm.Next(5, 11))
                );

            Coordinate expected = new Coordinate(coord.Local + direction, coord.Global);

            // Max possible coordinates
            Coordinate maxCoord = new Coordinate(
                Local: new Vector2(rdm.Next(20, 30), rdm.Next(20, 30)),
                Global: new Vector2(rdm.Next(20, 30), rdm.Next(20, 30))
                );


            // Apply
            Coordinate newCoord = TilePhysics.ApplyForce(coord, maxCoord, direction);

            // Verify
            Assert.True(newCoord.Equals(expected));
        }
    }
}
