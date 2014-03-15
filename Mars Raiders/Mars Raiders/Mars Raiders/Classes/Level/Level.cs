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
        public Vector2 MapDimensions = new Vector2 (9,9);

       
        public void generate()
        {
            Map = new Tile[10, 10];
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Map[x,y] = Tile.Grass;
                }
            }

            
        }
        public void Draw(SpriteBatch SB, ContentManager C)
        {

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Map[x, y].draw(SB,C,x,y);
                }
            }
            

        }


 

        private void update(GameTime gametime)
        {
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Map[x, y].update(gametime);
                }
            }
        }
    }

}

