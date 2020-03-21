using Colver.Main;
using UnityEngine;

namespace TiMovi
{
    /// <summary>
    /// Class about Coordinate of an Entity in a Tile Map
    /// </summary>
    public class Coordinate
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
            this.Local = Local.ToAbsolute();
            this.Global = Global.ToAbsolute();
        }
        /// <summary>
        /// Calculate the distance of 2 Coordinates
        /// </summary>
        /// <param name="cord1">Coordinate 1</param>
        /// <param name="cord2">Coordinate 2</param>
        /// <returns>Returns a Vector with the Absolute and integer distance of 2 coordinates</returns>
        public virtual Vector2 Distance(Coordinate cord1, Coordinate cord2)
        {
            var cord3 = (cord1 - cord2).ToAbsolute();
            return cord3.Local * cord3.Global;
        }
        /// <summary>
        /// Convert a Coordinate to Absolute values
        /// </summary>
        /// <returns>Return a new Coordinate with Integer positives values</returns>
        public virtual Coordinate ToAbsolute()=> new Coordinate(Local.ToAbsolute(),Global.ToAbsolute());

        #region operators
        public static Coordinate operator +(Coordinate cor, Coordinate cord)=> new Coordinate(cor.Global + cord.Global, cor.Local + cord.Local);

        public static Coordinate operator -(Coordinate cor, Coordinate cord)=> new Coordinate(cor.Global - cord.Global, cor.Local - cord.Local);

        public static bool operator ==(Coordinate cor, Coordinate cord )=> cor.Equals(cord);

        public static bool operator !=(Coordinate cor, Coordinate cord) => !cor.Equals(cord);

        #endregion











        #region default
        /// <summary>
        /// Return all information about a Coordinate
        /// </summary>
        /// <returns> 2 Lines : one of them with informations about global coordinates info and the second one with the local coordinates info</returns>
        public override string ToString() => $"Global : {Global.ToAbsolute().ToString()}\nLocal : {Local.ToAbsolute().ToString()}";

        /// <summary>
        /// Compare two coordinates
        /// </summary>
        /// <param name="obj">The coordinate to compare with the actual one</param>
        /// <returns>Return true if the coordinates are the same</returns>
        public bool Equals(Coordinate obj)
        {
            if(this.Local == obj.Local)
                if(this.Global == obj.Global)
                    return true;

            return false;
        }
        #endregion
    }
}
