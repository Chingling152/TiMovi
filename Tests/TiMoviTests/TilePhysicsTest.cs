using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TiMovi;
using UnityEngine;

namespace Tests.TiMoviTests
{ 
    //TODO : Make theses tests using direction
    [TestClass]
    public class TilePhysicsTest
    {
        private System.Random rdm;

        public TilePhysicsTest()
        {
            rdm = new System.Random();
        }

        [TestMethod]
        [Obsolete]
        public void OnApplyForceShouldMoveToDirection()
        {
            // Plan
            int force = rdm.Next(-3,3);
            bool vertical = rdm.NextDouble() >= 0.5;

            Coordinate coord = new Coordinate(
                Local: new Vector2(rdm.Next(5,11),rdm.Next(5,11)),
                Global: new Vector2(rdm.Next(5, 11), rdm.Next(5, 11))
                );

            // Max possible coordinates
            Coordinate maxCoord = new Coordinate(
                Local: new Vector2(rdm.Next(20, 30), rdm.Next(20, 30)),
                Global: new Vector2(rdm.Next(20, 30), rdm.Next(20, 30))
                );
            
            // Apply
            Coordinate newCoord = TilePhysics.ApplyForce(coord, maxCoord, vertical,force);

            // Verify
            Coordinate expected = new Coordinate(coord.Local, coord.Global);
            if(vertical)
                expected.Local.Set(coord.Local.x , coord.Local.y + force);
            else
                expected.Local.Set(coord.Local.x+force, coord.Local.y);

            Assert.IsTrue(newCoord.Equals(expected));
        }

        [TestMethod]
        public void OnApplyForceOnEdgeShouldGoToNextTileMap()
        { 
        }

        [TestMethod]
        public void OnApplyForceOnEndShouldNotMove()
        {
        }


    }
}
