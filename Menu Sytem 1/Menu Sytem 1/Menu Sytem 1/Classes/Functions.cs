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

namespace Menu_Sytem_1
{
    public class Functions
    {
        private MouseState ms = Mouse.GetState();

        public Vector2 GetMouseCoords()
        {
            ms = Mouse.GetState();
            return new Vector2(ms.X, ms.Y);
        }

        public Boolean MouseLeftClick()
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

        public Boolean CollisionChecker(Rectangle RecA, Rectangle RecB)
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
    }
}
