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
            GameControls[(int)Controls.FOWARD] = new Control(Keys.Up, 20);
            GameControls[(int)Controls.BACKWARD] = new Control(Keys.Down, 20);
            GameControls[(int)Controls.RIGHT] = new Control(Keys.Right, 20);
            GameControls[(int)Controls.LEFT] = new Control(Keys.Left, 20);
            GameControls[(int)Controls.SPACE] = new Control(Keys.Space, 200);
            GameControls[(int)Controls.ZOOMIN] = new Control(Keys.Z, 20);
            GameControls[(int)Controls.ZOOMOUT] = new Control(Keys.X, 20);
            GameControls[(int)Controls.PLACEBLOCK1] = new Control(Keys.D1, 20);
            GameControls[(int)Controls.PLACEBLOCK2] = new Control(Keys.D2, 20);
            GameControls[(int)Controls.PLACEBLOCK3] = new Control(Keys.D3, 20);
            GameControls[(int)Controls.PLACEBLOCK4] = new Control(Keys.D4, 20);
            GameControls[(int)Controls.SAVE] = new Control(Keys.S, 20);
            GameControls[(int)Controls.LOAD] = new Control(Keys.L, 20);
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
