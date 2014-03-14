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
    //This class has all the SUBS that are going to be called from the UPDATE SUB in GAME1.

    //I am doing this to keep the code organised.
    public class Content
    {
        public void Game_Initiate() //This does the prior to game launch settings. Empty at the moment but hopefully not soon!
        {
            Game1.ProgramPosition = (int)ProgramPositions.MenuStartInitiate;
        }

        public void Start_Menu_Initiate(ContentManager Content)
        {
            Game1.Menu.MenuItems.Add(new Menu_Items("Play Game","Begin the Game",1,500,Content));
            Game1.ProgramPosition = (int)ProgramPositions.MenuStart;
        }


    }
}
