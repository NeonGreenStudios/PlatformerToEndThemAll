using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;

namespace Mars_Raiders
{
    public class Level
    {
      
        public Tile[,] Map;
        public Vector2 MapDimensions = new Vector2 (100,100);
        public EntityCursor Player = new EntityCursor();
        public bool Paused;
        public bool FirstTickPaused;
       
        public void generate()
        {
            Map = new Tile[(int)MapDimensions.X, (int)MapDimensions.Y];
            for (int y = 0; y < (int)MapDimensions.Y; y++)
            {
                for (int x = 0; x < (int)MapDimensions.X; x++)
                {
                    Map[x,y] = new TileIceRock();
                }
            }
            for (int y = 0; y < (int)MapDimensions.Y; y++)
            {                   
                for (double x = 0; x < (int)MapDimensions.X; x++)
                {
                    if (y < (Math.Cos((x / 20) - 10)) * 100)
                    {
                        Map[(int)Math.Round(x), y] = new TileStone();
                    }
                    
                }
            }
                
                
            

            for (int x = 1; x < 9; x++)
            {
                Map[x, 5].Raised = true;
                Map[x, 4].Raised = true;
            }

            for (int x = 3; x < (int)MapDimensions.X - 2; x++)
            {
                Map[x, 3].Raised = true;
            }
            for (int x = 3; x < 8; x++)
            {
                Map[x, 7] = new TileStone();
            }
            
        }
        public void Draw(SpriteBatch SB, ContentManager C)
        {

            for (int y = 0; y < (int)MapDimensions.Y; y++)
            {
                for (int x = 0; x < (int)MapDimensions.X; x++)
                {
                    Map[x, y].draw(SB,C,x,y,this);
                }
            }
            Player.render(SB, C);
            if (this.Paused)
            {

            }

        }


 

        public void update(GameTime gametime)
        {
            for (int y = 0; y < (int)MapDimensions.Y; y++)
            {
                for (int x = 0; x < (int)MapDimensions.X; x++)
                {
                    Map[x, y].update(gametime);
                }
            }
            Player.update(gametime,this);
        }

        public void save()
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(Game1.appdata.ApplicationFolderPath + "/LevelCreator.txt",false);
               for (int y = 0; y < (int)MapDimensions.Y; y++)
            {
                for (int x = 0; x < (int)MapDimensions.X; x++)
                {
                   
                    writer.Write(":" + Map[x, y].ID.ToString() + "/" +  Map[x, y].Raised.ToString() + "/" + x.ToString() + "/" + y.ToString() + "/");

                }
               
            }
               writer.Dispose();
        }

        public void load()
        {

            System.IO.StreamReader reader = new System.IO.StreamReader(Game1.appdata.ApplicationFolderPath + "/LevelCreator.txt");
            string[] Split1RawData = reader.ReadToEnd().Split(':');

            for (int i = 1; i < Split1RawData.Length -1; i ++) //starts at one to avoid the empty first entry
            {
                string[] Data =  Split1RawData[i].Split('/');
                int X = Convert.ToInt16(Data[2]);
                int Y = Convert.ToInt16(Data[3]);
                switch (Data[0])
                {
                    case "0":
                        Map[X, Y] = new TileIce();
                        break;
                    case "1":
                        Map[X, Y] = new TileGritIce();
                        break;
                    case "2":
                        Map[X, Y] = new TileStone();
                        break;
                    case "3":
                        Map[X, Y] = new TileIceRock();
                        break;
                }
                Map[X, Y].Raised = Convert.ToBoolean(Data[1]);
            }

            reader.Dispose();
        }
    }

}

