using UnityEngine;

namespace TMovement.Interfaces
{
    /// <summary>
    /// Interface with methods to create a valid Coordinate
    /// </summary>
    public interface ICoordinate
    {

        /// <summary>
        /// Define the exacly the Coordinate of an Entity
        /// </summary>
        Vector2 Local { get; set; }

        /// <summary>
        /// Calculate the distance of 2 Coordinates
        /// </summary>
        /// <param name="cord1">Coordinate 1</param>
        /// <param name="cord2">Coordinate 2</param>
        /// <returns>Returns a Vector with the Absolute distance of 2 coordinates</returns>
        Vector2 Distance(ICoordinate cord1, ICoordinate cord2);

        /// <summary>
        /// Convert the current Coordinate (Global and Local) to Absolute values
        /// </summary>
        /// <returns>The current Coordinate with Absolute Values</returns>
        ICoordinate ToAbs();
    }
}
