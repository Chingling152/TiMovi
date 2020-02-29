using System;
using UnityEngine;

namespace TMovement.Extensions
{
    public static class Vector2Extension 
    {
        /// <summary>
        /// Convert the current Vector2 to absolute integer Values
        /// </summary>
        /// <param name="vector2">Vector2 to to be conveted</param>
        /// <returns>Return a Vector 2 with positive integer number</returns>
        public static Vector2 ToAbsolute(this Vector2 vector2)
        {
            int x = Convert.ToInt32(Math.Abs(vector2.x));
            int y = Convert.ToInt32(Math.Abs(vector2.y));

            return new Vector2(x,y);
        }
    }
}
