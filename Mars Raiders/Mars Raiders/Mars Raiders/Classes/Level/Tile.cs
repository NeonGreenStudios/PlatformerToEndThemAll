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
    public abstract class Tile
    {

        public Boolean Raised { get; set; }//Used to determine weather or not the terrain is raised
        protected Vector2 TextureLocation; //the coords of the texture (x,y)
        public const int TileSideLengthInPixels = 32; //length of a tile in pixels
        public const int RaisedHeightInPixels = 10; //The number of pixels high the raised portion of the tile is

        public Tile()
        {
            Raised = false;
            defineTexture();
        }

        protected abstract void defineTexture();
        public abstract void update(GameTime gt);

        public void draw(SpriteBatch SB, ContentManager CM, int x, int y, Level level)
        {
            if (this.shouldRenderRaised(level, x, y) && this.Raised) //if it is raised
            {
                drawRaised(SB, CM, x, y);
            }
            else
            {
                drawLowered(SB, CM, x, y);
            }
        }
        protected void drawRaised(SpriteBatch SB, ContentManager CM, int x, int y) //draws the tile if it is raised
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheet"), new Rectangle(x * TileSideLengthInPixels, y * TileSideLengthInPixels, TileSideLengthInPixels, TileSideLengthInPixels), //the destination rectangle
               new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels), (int)((TextureLocation.Y * TileSideLengthInPixels) + (TextureLocation.Y * RaisedHeightInPixels) + RaisedHeightInPixels), TileSideLengthInPixels, TileSideLengthInPixels), Color.White); //the source rectangle

        }

        protected void drawLowered(SpriteBatch SB, ContentManager CM, int x, int y) //draws tile if it is lowered
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheet"), new Rectangle(x * TileSideLengthInPixels, y * TileSideLengthInPixels, TileSideLengthInPixels, TileSideLengthInPixels), //the destination rectangle
               new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels), (int)((TextureLocation.Y * TileSideLengthInPixels) + (TextureLocation.Y * RaisedHeightInPixels)), TileSideLengthInPixels, TileSideLengthInPixels), Color.White); //the source rectangle

        }

        protected bool shouldRenderRaised(Level level, int x, int y)
        {
            if (y >= level.MapDimensions.Y - 1)
            {
                return true;
            }
            else if (level.Map[x, y + 1].Raised == false)
            {
                return true;

            }
            else
            {


                return false;
            }
        }


    }
}
