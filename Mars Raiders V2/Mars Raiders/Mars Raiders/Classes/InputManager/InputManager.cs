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
    public class InputManager
    {
        List<Action> actions = new List<Action>();
        bool LastMouseLeftClick;
        bool NowMouseLeftClick;

        public void AddAction(String ActionName)
        {
            actions.Add(new Action(this, ActionName));
        }

        public Action this[String ActionName]
        {
            get
            {
                return actions.Find((Action a) => { return a.Name == ActionName; });
            }
        }

        public void Update()
        {
            KeyboardState kbState = Keyboard.GetState();
            GamePadState gpState = GamePad.GetState(0);

            foreach (Action a in actions)
                a.Update(kbState, gpState);

            LastMouseLeftClick = NowMouseLeftClick;
            NowMouseLeftClick = (Mouse.GetState().LeftButton == ButtonState.Pressed);
            
        }

        public Boolean MouseLeftClick()
        {
            return (!LastMouseLeftClick & NowMouseLeftClick);
        }

    }
}
