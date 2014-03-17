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
    static class KeyboardManager
    {

        private static Control[] GameControls;

        enum Controls : int
        {
            FOWARD = 0,
            BACKWARD = 1,
            RIGHT = 2,
            LEFT = 3,
            SPACE = 4,

        }

        public static bool isControlDown(Controls cont)
        {
            if (Keyboard.GetState().IsKeyDown(GameControls[(int)cont].))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void setControl(Controls cont, Keys key)
        {
            GameControls[(int)cont] = key;
        }
        public static void setControlDelay(Controls cont, int Delay)
        {

        }
    }
}
