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

namespace Tile_Based_Platformer_Test_2
{
    public class Level
    {
        public Tile[,] Map;
        public float Position;
        private String Raw_Data1;
        private Vector2 Tile_Sheet_Position;
        private String[] Raw_Data_Lines;
        private List<String[]> Raw_Data_Tiles = new List<String[]>();
        public List<Tile> Tiles = new List<Tile>();
        public String[] Temp;
        public Int16 TileSizeX = 32;
        public Int16 TileSizeY = 42;
        public Int16 Y_Axis;
        public Int16 X_Axis;
        public Vector2 MapDimensions;
  

        public void LoadFile(String FileAddress, ContentManager C)
        {
            System.IO.StreamReader Reader = new System.IO.StreamReader(@FileAddress);
            Raw_Data1 = Reader.ReadToEnd();
            Raw_Data_Lines = Raw_Data1.Split('#');
            for (int R2 = 0; R2 < Raw_Data_Lines.Length; R2++)
            {
                Raw_Data_Tiles.Add(Raw_Data_Lines[R2].Split(','));
            }
            for (int R3 = 0; R3 < Raw_Data_Tiles.Count; R3++)
            {
                for (int R4 = 0; R4 < Raw_Data_Tiles[R3].Length; R4++)
                {
                    Tiles.Add(new Tile(Raw_Data_Tiles[R3][R4]));
                }
            }
            }
        public void Draw(SpriteBatch SB, ContentManager C)
        {
                for (int X = 0; X < Tiles.Count; X++)
                {
            switch (Tiles[X].Texture_Information[0])
                    {
                        case "Grass":
                            Tile_Sheet_Position = new Vector2(0, 0);
                            if (Tiles[X].Texture_Information[2] == "Bottom")
                            {
                                Update_Bottom(SB, C);
                            }
                            else
                            {
                                Update_Tile(SB, C); 
                            }
  
                            break;
                        case "Stone":
                            Tile_Sheet_Position = new Vector2(32, 0);
                            if (Tiles[X].Texture_Information[2] == "Bottom")
                            {
                                Update_Bottom(SB, C);
                            }
                            else
                            {
                                Update_Tile(SB, C);
                            }
                            break;
                        case "Water":
                            Tile_Sheet_Position = new Vector2(32, 32);
                            if (Tiles[X].Texture_Information[2] == "Bottom")
                            {
                                Update_Bottom(SB, C);
                            }
                            else
                            {
                                Update_Tile(SB, C);
                            }
                            break;
                        case "Sand":
                            Tile_Sheet_Position = new Vector2(0, 32);
                            if (Tiles[X].Texture_Information[2] == "Bottom")
                            {
                                Update_Bottom(SB, C);
                            }
                            else
                            {
                                Update_Tile(SB, C);
                            }
                            break;
                        case "Water Still":
                            Tile_Sheet_Position = new Vector2(0, 32);
                            if (Tiles[X].Texture_Information[2] == "Bottom")
                            {
                                Update_Bottom(SB, C);
                            }
                            else
                            {
                                Update_Tile(SB, C);
                            }
                            break;
                        case "":
                            Y_Axis++;
                            X_Axis = 0;
                            break;
                    }


     
                }

        }


        public void Update_Bottom(SpriteBatch SB, ContentManager C)
        {
            SB.Draw(C.Load<Texture2D>("Tiles/Tile Sheet 3"), new Rectangle(X_Axis * TileSizeX, Y_Axis * TileSizeX, TileSizeX, TileSizeY),
            new Rectangle(Convert.ToInt16(Tile_Sheet_Position.X), Convert.ToInt16(Tile_Sheet_Position.Y), TileSizeX, TileSizeY), Color.White, 0.0f, new Vector2(0, 0)
            , SpriteEffects.None, 1.0f);
            X_Axis++; 
        }


        private void Update_Tile(SpriteBatch SB, ContentManager C)
        {
                SB.Draw(C.Load<Texture2D>("Tiles/Tile Sheet 3"), new Rectangle(X_Axis * TileSizeX, Y_Axis * TileSizeX, TileSizeX, TileSizeX),
                new Rectangle(Convert.ToInt16(Tile_Sheet_Position.X), Convert.ToInt16(Tile_Sheet_Position.Y), TileSizeX, TileSizeX), Color.White,0.0f,new Vector2(0,0)
                ,SpriteEffects.None,1.0f);
            X_Axis++; 
        }
        }
    }

