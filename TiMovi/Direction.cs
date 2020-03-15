using UnityEngine;

namespace TiMovi
{
    /// <summary>
    /// Class to get a directions on a tile map based on Entity Direction
    /// </summary>
    public static class Direction
    {
        /// <summary>
        /// Returns the coordinate on right of an Entity based on it's actual Direction. 
        /// </summary>
        /// <param name="vertical">Defines if the Entity's Direction is headed to Vertical</param>
        /// <param name="positive">Defines the direction of the Entity (forward or backward if vertical | left or right if !vertical)</param>
        /// <returns>Return a Vector2 with +1 or -1 in X or Y (Defined by vertical)</returns>
        public static Vector2 Right(bool vertical, bool positive)
        {
            if (vertical)
                if (positive)
                    return Vector2.right;
                else
                    return Vector2.left;
            else
                if (positive)
                return Vector2.down;
            else
                return Vector2.up;
        }

        /// <summary>
        /// Returns the coordinate on left of an Entity based on it's actual Direction. 
        /// </summary>
        /// <param name="vertical">Defines if the Entity's Direction is headed to Vertical</param>
        /// <param name="positive">Defines the direction of the Entity (forward or backward if vertical | left or right if !vertical)</param>
        /// <returns>Return a Vector2 with +1 or -1 in X or Y (Defined by vertical)</returns>
        public static Vector2 Left(bool vertical, bool positive)
        {
            if (vertical)
                if (positive)
                    return Vector2.left;
                else
                    return Vector2.right;
            else
                if (positive)
                return Vector2.up;
            else
                return Vector2.down;
        }

        /// <summary>
        /// Returns the coordinate behind of an Entity based on it's actual Direction. 
        /// </summary>
        /// <param name="vertical">Defines if the Entity's Direction is headed to Vertical</param>
        /// <param name="positive">Defines the direction of the Entity (forward or backward if vertical | left or right if !vertical)</param>
        /// <returns>Return a Vector2 with +1 or -1 in X or Y (Defined by vertical)</returns>
        public static Vector2 Back(bool vertical, bool positive)
        {
            if (vertical)
                if (positive)
                    return Vector2.down;
                else
                    return Vector2.up;
            else
                if (positive)
                return Vector2.left;
            else
                return Vector2.right;
        }

        /// <summary>
        /// Returns the coordinate infront of an Entity based on it's actual Direction. 
        /// </summary>
        /// <param name="vertical">Defines if the Entity's Direction is headed to Vertical</param>
        /// <param name="positive">Defines the direction of the Entity (forward or backward if vertical | left or right if !vertical)</param>
        /// <returns>Return a Vector2 with +1 or -1 in X or Y (Defined by vertical)</returns>
        public static Vector2 Front(bool vertical, bool positive)
        {
            if (vertical)
                if (positive)
                    return Vector2.up;
                else
                    return Vector2.down;
            else
                if (positive)
                return Vector2.right;
            else
                return Vector2.left;
        }
    }

}
