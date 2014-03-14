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
        public Vector2 MapDimensions = new Vector2 (10,10);

       
        public void generate()
        {
            for (int x = 0; x < MapDimensions.X - 1; x++){
                for (int y = 0; y < MapDimensions.Y - 1; x++)
                {
                    Map[x,y] = Tile.Grass;
                }
            }
            
        }
        public void Draw(SpriteBatch SB, ContentManager C)
        {

            for (int x = 0; x <= MapDimensions.X; x++)
            {
                for (int y = 0; y <= MapDimensions.Y; x++)
                {
                    Map[x,y].draw(SB ,C, x,y);
                }
            }
            

        }


 

        private void update(GameTime gametime)
        {
            for (int x = 0; x <= MapDimensions.X; x++)
            {
                for (int y = 0; y <= MapDimensions.Y; x++)
                {
                    Map[x,y].update(gametime);
                }
            }
        }
    }

}

