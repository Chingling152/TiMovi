using TMovement.Extensions;
using TMovement.Interfaces;
using UnityEngine;

namespace TMovement
{
    /// <summary>
    /// Class about Coordinate of an Entity in a Tile Map
    /// </summary>
    public class Coordinate : ICoordinate
    {
        /// <summary>
        /// Define the exacly the Coordinate of an Entity
        /// </summary>
        public Vector2 Local { get; set; }

        /// <summary>
        /// Define the Map part that the Entity is occupying (can be avoided)
        /// </summary>
        public Vector2 Global { get; set; }

        /// <summary>
        /// Default Coordinate Constructor
        /// </summary>
        /// <param name="Local">Tile coordinate that the Entity is ocupying</param>
        /// <param name="Global">Map part that the Entity is occupying</param>
        public Coordinate(Vector2 Local, Vector2 Global)
        {
            this.Local = new Vector2((int)Local.x, (int)Local.y);
            this.Global = new Vector2((int)Global.x, (int)Global.y);
        }
        /// <summary>
        /// Calculate the distance of 2 Coordinates
        /// </summary>
        /// <param name="cord1">Coordinate 1</param>
        /// <param name="cord2">Coordinate 2</param>
        /// <returns>Returns a Vector with the Absolute and integer distance of 2 coordinates</returns>
        public Vector2 Distance(ICoordinate cord1, ICoordinate cord2)
        {
            var cord3 = (Coordinate)((Coordinate)cord1 - (Coordinate)cord2).ToAbs();
            return cord3.Local * cord3.Global;
        }
        /// <summary>
        /// Convert a Coordinate to Absolute values
        /// </summary>
        /// <returns>Return a new Coordinate with Integer positives values</returns>
        public ICoordinate ToAbs()=> new Coordinate(Local.ToAbsolute(),Global.ToAbsolute());

        public static Coordinate operator +(Coordinate cor, Coordinate cord)=> new Coordinate(cor.Global + cord.Global, cor.Local + cord.Local);

        public static Coordinate operator -(Coordinate cor, Coordinate cord)=> new Coordinate(cor.Global - cord.Global, cor.Local - cord.Local);
    }
}
