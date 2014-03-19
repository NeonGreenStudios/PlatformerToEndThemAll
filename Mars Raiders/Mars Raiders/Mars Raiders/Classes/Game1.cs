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

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static float Scale = 1f; // This is the VARIABLE that stores the SCALE for everything in the program
        public static float Zoom = 1; // This is the VARIABLE that stores the ZOOM for the level
        public static SpriteFont Background;
        public static SpriteFont Andy; // This is the ANDY font VARIABLE
        public static Menu_System Menu = new Menu_System(); // This is the CLASS that does all the menu handling
        public static Content Contents = new Content(); // This is the VARIABLE for the CONTENT CLASS
        public static int ProgramPosition;
        public static InputManager IM = new InputManager();

        public static CommonApplicationData appdata;

        public static Level Level = new Level ();
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); //sets up graphics use
            Content.RootDirectory = "Content"; //set up location for files
            graphics.PreferredBackBufferWidth = 720; //horizontal resolution
            graphics.PreferredBackBufferHeight = 480; //vertical resolution
            graphics.IsFullScreen = false; //fullscreen mode
            graphics.ApplyChanges(); //sets graphics using above settings
            IsMouseVisible = true; //shows mouse in window
            this.Window.Title = "Mars Raiders"; //window title
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            appdata = new CommonApplicationData("NeonGreenStudios", "MarsRaiders");
            Process.Start(appdata.ApplicationFolderPath);
            IM.AddAction("Raise");
            IM["Raise"].Add(Keys.Space);
            IM.AddAction("Load");
            IM["Load"].Add(Keys.L);
            IM.AddAction("Save");
            IM["Save"].Add(Keys.S);
            IM.AddAction("ZoomIn");
            IM["ZoomIn"].Add(Keys.Z);
            IM.AddAction("ZoomOut");
            IM["ZoomOut"].Add(Keys.O);
            IM.AddAction("PlaceBlock1");
            IM["PlaceBlock1"].Add(Keys.D1);


            Andy = Content.Load<SpriteFont>("Fonts/Andy Spritefont");
            Background = Content.Load<SpriteFont>("Fonts/Background Spritefont");
            ProgramPosition = (int)ProgramPositions.GameInitiate;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            IM.Update();
            switch (ProgramPosition)
            {
                case (int)ProgramPositions.GameInitiate:
                    Contents.Game_Initiate();
                    break;

                case (int)ProgramPositions.MenuStartInitiate:
                    Contents.Start_Menu_Initiate(Content);
                    break;

                case (int)ProgramPositions.MenuStart:
                    Game1.Menu.Contents(gameTime);
                    break;

                case (int)ProgramPositions.MenuDeveloperInitiate:
                    Game1.Contents.Menu_Developer_Intitiate(Content);
                    break;

                case (int)ProgramPositions.MenuDeveloper:
                    Game1.Menu.Contents(gameTime);
                    break;
                
                case (int) ProgramPositions.LevelCreatorInitiate:
                    Contents.Level_Creator_Initiate(Content);
                    ProgramPosition = (int)ProgramPositions.LevelCreator;
                    break;
                case (int)ProgramPositions.LevelCreator:
                    Game1.Level.update(gameTime);
                    break;
                case (int)ProgramPositions.END:
                    this.Exit();
                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Orange);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,SamplerState.PointClamp,DepthStencilState.Default, RasterizerState.CullNone);
        
            switch (ProgramPosition)
            {
                case (int)ProgramPositions.MenuStart:
                    Menu.Draw(spriteBatch);
                    break;
                case (int)ProgramPositions.LevelCreator:
                    Game1.Level.Draw(spriteBatch, Content);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
