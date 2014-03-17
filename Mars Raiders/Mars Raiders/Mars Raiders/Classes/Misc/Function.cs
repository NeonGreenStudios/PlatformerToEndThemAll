using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Mars_Raiders
{

    // This is the CLASS that has all the useful functions in.

    public class Functions
    {
        private static MouseState ms;

        public static Vector2 GetMouseCoords()
        {
            ms = Mouse.GetState();
            return new Vector2(ms.X, ms.Y);
        }

        public static Boolean MouseLeftClick()
        {
            ms = Mouse.GetState();
            if (ms.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean CollisionChecker(Rectangle RecA, Rectangle RecB)
        {
            if (RecA.Intersects(RecB))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static float toRadians(float angle)
        {
            return (float)Math.PI * angle / 180;
        }
    }
}
