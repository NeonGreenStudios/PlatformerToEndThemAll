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
            //FOWARD = 0,       //Just for referencing
            //BACKWARD = 1,
            //RIGHT = 2,
            //LEFT = 3,
            //SPACE = 4,
            //ZOOMIN = 5,
            //ZOOMOUT = 6,
            //PLACEBLOCK1 = 7,
            //PLACEBLOCK2 = 8,
            //PLACEBLOCK3 = 9,
            //PLACEBLOCK4 = 7,
            //SAVE = 8,
            //LOAD = 9

        public static Control[] GameControls;
        public static void Initialise()
        {
            GameControls = new Control[20];
            GameControls[0] = new Control(Keys.Up, 20);
            GameControls[1] = new Control(Keys.Down, 20);
            GameControls[2] = new Control(Keys.Right, 20);
            GameControls[3] = new Control(Keys.Left, 20);
            GameControls[4] = new Control(Keys.Space, 20);
            GameControls[5] = new Control(Keys.Z, 20);
            GameControls[6] = new Control(Keys.X, 20);
            GameControls[7] = new Control(Keys.D1, 20);
            GameControls[8] = new Control(Keys.D2, 20);
            GameControls[9] = new Control(Keys.D3, 20);
            GameControls[10] = new Control(Keys.D4, 20);
            GameControls[11] = new Control(Keys.S, 20);
            GameControls[12] = new Control(Keys.L, 20);
        }

        public static bool isControlDown(Controls cont, GameTime time)
        {
            return GameControls[(int)cont].Press(time);     
        }

        public static void setControl(Controls cont, Keys key)
        {
            GameControls[(int)cont].Key = key;
        }
        public static void setControlDelay(Controls cont, int Delay)
        {
            GameControls[(int)cont].Delay = Delay;
        }
    }
}
