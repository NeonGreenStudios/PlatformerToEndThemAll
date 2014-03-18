using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace Mars_Raiders
{
   public  class Control
    {
        public Keys Key;
        public double Delay;
        private double LastPressed;

        public Control(Keys k, int delay)
        {
            Key = k;
            Delay = delay;
        }
   
        public bool Press(GameTime time)
        {
            if (time.TotalGameTime.TotalMilliseconds - LastPressed >= Delay & Keyboard.GetState().IsKeyDown(Key))
            {
                LastPressed = time.TotalGameTime.Milliseconds;
                return true;
            }
                return false;   
        }
    }
}
