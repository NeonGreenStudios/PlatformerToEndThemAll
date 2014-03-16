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

       
        public void generate()
        {
            Map = new Tile[(int)MapDimensions.X, (int)MapDimensions.Y];
            for (int y = 0; y < (int)MapDimensions.Y; y++)
            {
                for (int x = 0; x < (int)MapDimensions.X; x++)
                {
                    Map[x,y] = new TileGrass();
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
                Map[x, 7] = new TileWater();
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
                   
                    writer.Write(":" + Map[x, y].ID.ToString() + ";" +  Map[x, y].Raised.ToString() + ";" + x.ToString() + ";" + y.ToString() + "/");

                }
               
            }
               writer.Dispose();
        }

        public void load()
        {

            System.IO.StreamReader reader = new System.IO.StreamReader(Game1.appdata.ApplicationFolderPath + "/LevelCreator.txt");

            reader.ReadToEnd();
            string[] Split1RawData = reader.ReadToEnd().Split(':');

            for (int i = 0; i < Split1RawData.Length -1; i ++)
            {
                string[] Data =  Split1RawData[i].Split(';');
                string t = Data[0];
                Debug.Print("hh");
    
               
                //int X = Convert.ToInt16(Data[2]);
                //int Y = Convert.ToInt16(Data[3]);
                //switch (Data[0])
                //{
                //    case "0":
                //        Map[X, Y] = new TileGrass();
                //        break;
                //    case "1":
                //        Map[X, Y] = new TileSand();
                //        break;
                //    case "2":
                //        Map[X, Y] = new TileStone();
                //        break;
                //    case "3":
                //        Map[X, Y] = new TileWater();
                //        break;
                //}
                //Map[X, Y].Raised = Convert.ToBoolean(Data[1]);
            }

            reader.Dispose();
        }
    }

}

