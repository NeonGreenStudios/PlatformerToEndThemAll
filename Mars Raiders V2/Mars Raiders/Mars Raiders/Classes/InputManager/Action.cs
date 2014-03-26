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
using System.Diagnostics;
using System.IO;
namespace Mars_Raiders
{
    public class Action
    {
        String name;
        List<Keys> keyList = new List<Keys>();
        List<Buttons> buttonList = new List<Buttons>();
        InputManager parent = null;
        bool currentStatus = false;
        bool previousStatus = false;

        public bool IsDown { get { return currentStatus; } }
        public bool IsTapped { get { return (currentStatus) && (!previousStatus); } }
        public String Name { get { return name; } }

        public Action(InputManager p, string n)
        {
            parent = p;
            name = n;
        }

        public void Add(Keys key)
        {
            if (!keyList.Contains(key))
                keyList.Add(key);
        }

        public void Add(Buttons button)
        {
            if (!buttonList.Contains(button))
                buttonList.Add(button);
        }

        internal void Update(KeyboardState kbState, GamePadState gpState)
        {
            previousStatus = currentStatus;
            currentStatus = false;
            foreach (Keys k in keyList)
                if (kbState.IsKeyDown(k))
                    currentStatus = true;
            foreach (Buttons b in buttonList)
                if (gpState.IsButtonDown(b))
                    currentStatus = true;
        }
    }
}
