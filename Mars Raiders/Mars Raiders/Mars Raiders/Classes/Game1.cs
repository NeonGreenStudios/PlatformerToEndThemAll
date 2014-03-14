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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static Functions Function = new Functions(); // This is the CLASS that does all the function SHIT
        public static Menu_System Menu = new Menu_System(); // This is the CLASS that does all the menu SHIT
        public static Content Contents = new Content(); // This is the VARIABLE for the CONTENT CLASS
        public static int ProgramPosition;
        SpriteBatch SpriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); //sets up graphics use
            Content.RootDirectory = "Content"; //set up location for files
            graphics.PreferredBackBufferWidth = 1280; //horizontal resolution
            graphics.PreferredBackBufferHeight = 720; //vertical resolution
            graphics.IsFullScreen = false; //fullscreen mode
            graphics.ApplyChanges(); //sets graphics using above settings
            IsMouseVisible = true; //shows mouse in window
            this.Window.Title = "Mars Raiders"; //window title
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            ProgramPosition = (int)ProgramPositions.GameInitiate;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            switch (ProgramPosition)
            {
                case (int)ProgramPositions.GameInitiate:
                    Contents.Game_Initiate();
                    break;

                case (int)ProgramPositions.StartMenuInitiator:

                    break;
            }
                this.Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            switch (ProgramPosition)
            {
                case (int)ProgramPositions.GameInitiate:

                    break;
            }
            base.Draw(gameTime);
        }
    }
}
