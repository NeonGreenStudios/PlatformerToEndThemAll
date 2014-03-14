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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteFont Andy;
        public static int ProgramPosition;
        public static SpriteFont Background;
        public static Functions Function = new Functions();
        SpriteBatch spriteBatch;
        public Menu MenuSystem = new Menu();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); //sets up graphics use
            Content.RootDirectory = "Content"; //set up location for files
            graphics.PreferredBackBufferWidth = 1280; //horizontal resolution
            graphics.PreferredBackBufferHeight = 720; //vertical resolution
            graphics.IsFullScreen = false; //fullscreen mode
            graphics.ApplyChanges(); //sets graphics using above settings
            IsMouseVisible = true; //shows mouse in window
            this.Window.Title = "Menu System 1"; //window title
        }

        protected override void Initialize()
        {
        
            ProgramPosition = (int)ProgramPositions.MenuMainInitiate;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Andy = Content.Load<SpriteFont>("Fonts/Andy Spritefont");
            Background = Content.Load<SpriteFont>("Fonts/Background");
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        private void Main_Menu_Initiate(GameTime GT)
        {
            MenuSystem.MenuItems.Clear();
            MenuSystem.MenuItems.Add(new Menu_Item("Play Game", "Start Playing the Game?", 1, (int) ProgramPositions.MenuMain, Content));
            MenuSystem.MenuItems.Add(new Menu_Item("Developer Tools", "NO NOOBS ALLOWED", 2, (int)ProgramPositions.MenuDeveloperInitiate, Content));
            MenuSystem.MenuItems.Add(new Menu_Item("Quit", "Really?", 3, (int)ProgramPositions.END, Content));
            MenuSystem.LastVoidClick = GT.TotalGameTime.TotalMilliseconds;
            ProgramPosition = (int)ProgramPositions.MenuMain; 
        }



        private void Developer_Main_Menu_Initiate(GameTime GT)
        {
            MenuSystem.MenuItems.Clear();
            MenuSystem.MenuItems.Add(new Menu_Item("Level Creator", "Create, Load or Modify a level", 1, (int)ProgramPositions.MenuMain, Content));
            MenuSystem.MenuItems.Add(new Menu_Item("Back", "Return to the Main Menu", 2, (int)ProgramPositions.MenuMainInitiate, Content));
            MenuSystem.MenuItems.Add(new Menu_Item("The Button to end all buttons (It basically does shit all)","CLICK IF YOU DAREEEE", 3, (int)ProgramPositions.MenuMain, Content));
            MenuSystem.LastVoidClick = GT.TotalGameTime.TotalMilliseconds;
            ProgramPosition = (int)ProgramPositions.MenuDeveloper;
        }

        protected override void Update(GameTime gameTime)
        {
            switch (ProgramPosition)
            {
                case (int)ProgramPositions.MenuMainInitiate: //placeholder for main menu initiate
                    Main_Menu_Initiate(gameTime);
                    break;

                case (int)ProgramPositions.MenuMain:
                    MenuSystem.Contents(gameTime);
                    break;

                case (int)ProgramPositions.GameStart:
                    ProgramPosition = (int)ProgramPositions.MenuMain; //placeholder for level initiation
                    break;

                case (int)ProgramPositions.MenuDeveloperInitiate:
                    Developer_Main_Menu_Initiate(gameTime);
                    break;

                case (int)ProgramPositions.MenuDeveloper:
                    MenuSystem.Contents(gameTime);
                    break;

                case (int)ProgramPositions.END:
                    this.Exit();
                    break;

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            
            MenuSystem.Draw(spriteBatch);
           
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
