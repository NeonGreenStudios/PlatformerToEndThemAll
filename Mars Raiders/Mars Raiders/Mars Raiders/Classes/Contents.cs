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
            Game1.Menu = new Menu(Content.Load<Texture2D>("Graphics/MainMenuBackGround"));
            Game1.Menu.MenuItems.Clear();
            Game1.Menu.MenuItems.Add(new Menu_Item("Play Game", "Begin the Game", 1, (int)ProgramPositions.PlayGameInit,1.0f,  Content));
            Game1.Menu.MenuItems.Add(new Menu_Item("Level Creator", "Create a level", 2, (int)ProgramPositions.MenuDeveloperInitiate, 1.0f,  Content));
            Game1.Menu.MenuItems.Add(new Menu_Item("Exit", "Are you sure?", 3, (int)ProgramPositions.END, 1.0f,  Content));
            Game1.ProgramPosition = (int)ProgramPositions.MenuStart;
        }

        public void Menu_Developer_Intitiate(ContentManager Content)
        {
            Game1.Menu = new Menu(Content.Load<Texture2D>("Graphics/MainMenuBackGround"));
            Game1.Menu.MenuItems.Clear();
            Game1.Menu.MenuItems.Add(new Menu_Item("Level Creator", "Start editing!", 1, (int)ProgramPositions.LevelCreatorInitiate, 1.0f, Content));
            Game1.Menu.MenuItems.Add(new Menu_Item("Back", "Go Back to the start menu", 2, (int)ProgramPositions.MenuStartInitiate, 1.0f, Content));
            Game1.ProgramPosition = (int)ProgramPositions.MenuStart;
        }


        public void Level_Creator_Initiate(ContentManager Content)
        {
            Game1.Level.generate(LevelType.Interior);
            Game1.Level.mode = "Edit"; //sets to editor mode
            Game1.ProgramPosition = (int)ProgramPositions.LevelCreator;
        }

        public void Play_Game_Initiate()
        {
            Game1.Level.generate(LevelType.Interior);
          //  Game1.Level.load();
            Game1.Level.mode = "Play";
            Game1.ProgramPosition = (int)ProgramPositions.PlayGame;
        }


    }
}
