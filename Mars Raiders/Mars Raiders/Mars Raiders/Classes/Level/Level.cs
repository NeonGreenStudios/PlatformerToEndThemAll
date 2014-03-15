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

namespace Mars_Raiders
{
    public class Level
    {
      
        public Tile[,] Map;
        public Vector2 MapDimensions = new Vector2 (100,100);

       
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

            for (int x = 1; x < (int)MapDimensions.X; x++)
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
            

        }


 

        private void update(GameTime gametime)
        {
            for (int y = 0; y < (int)MapDimensions.Y; y++)
            {
                for (int x = 0; x < (int)MapDimensions.X; x++)
                {
                    Map[x, y].update(gametime);
                }
            }
        }
    }

}

