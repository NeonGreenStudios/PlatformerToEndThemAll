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
        public int ID;
        public const int TileSideLengthInPixels = 32; //length of a tile in pixels
        public const int RaisedHeightInPixels = 10; //The number of pixels high the raised portion of the tile is
        public const int DropHeightInPixels = 1; //the number of pixels high the drop portion of it is (The black line at the back)

        public Tile()
        {
            Raised = false;
            define();
        }

        protected abstract void define();
        public abstract void update(GameTime gt);

        public void draw(SpriteBatch SB, ContentManager CM, int x, int y, Level level)
        {
            if (this.shouldRenderRaised(level, x, y)) //if it is raised
            {
                drawRaised(SB, CM, x, y);
            }
            else
            {
                drawLowered(SB, CM, x, y);
            }

            if (shouldRenderDrop (level,x,y))
            {
                drawDrop(SB, CM, x, y);
            }
            if (shouldRenderDropLeft(level, x, y))
            {
                drawDropLeft(SB, CM, x, y);
            }
            if (shouldRenderDropRight(level, x, y))
            {
                drawDropRight(SB, CM, x, y);
            }
        }
        protected void drawRaised(SpriteBatch SB, ContentManager CM, int x, int y) //draws the tile if it is raised
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheet"), new Rectangle((int)Math.Ceiling((x * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((y * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((TileSideLengthInPixels * Game1.Scale * Game1.Zoom))), //the destination rectangle
               new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels),(int)((TextureLocation.Y * TileSideLengthInPixels) + (TextureLocation.Y * RaisedHeightInPixels) + RaisedHeightInPixels), TileSideLengthInPixels, TileSideLengthInPixels), Color.White); //the source rectangle
        }

        protected void drawLowered(SpriteBatch SB, ContentManager CM, int x, int y) //draws tile if it is lowered
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheet"), new Rectangle((int)Math.Ceiling((x * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((y * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling(TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), //the destination rectangle
               new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels), (int)((TextureLocation.Y * TileSideLengthInPixels) + (TextureLocation.Y * RaisedHeightInPixels)), TileSideLengthInPixels, TileSideLengthInPixels), Color.White); //the source rectangle
        }

        protected void drawDrop(SpriteBatch SB, ContentManager CM, int x, int y) //draws the drop on the top of the tile (The little darkish line to show the next tile up is lowered)
        {

            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheet"), new Rectangle((int)Math.Ceiling((x * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((y * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)),(int)Math.Ceiling( (TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling(DropHeightInPixels * Game1.Scale * Game1.Zoom)), //the destination rectangle
           new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels), (int)((TextureLocation.Y * TileSideLengthInPixels) + (TextureLocation.Y * RaisedHeightInPixels) + TileSideLengthInPixels - RaisedHeightInPixels), TileSideLengthInPixels, TileSideLengthInPixels), Color.White); //the source rectangle
        }
        protected void drawDropLeft(SpriteBatch SB, ContentManager CM, int x, int y) //draws the drop on the left of the tile (The little darkish line to show the next tile up is lowered)
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheet"), new Rectangle((int)Math.Ceiling((x * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling(((y + DropHeightInPixels) * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((TileSideLengthInPixels  * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling(DropHeightInPixels * Game1.Scale * Game1.Zoom)), //the destination rectangle
           new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels), (int)((TextureLocation.Y * TileSideLengthInPixels) + (TextureLocation.Y * RaisedHeightInPixels) + TileSideLengthInPixels - RaisedHeightInPixels), TileSideLengthInPixels, TileSideLengthInPixels), Color.White,Functions.toRadians (-90f),new Vector2 (0,0),SpriteEffects.None, 0); //the source rectangle
        }

        protected void drawDropRight(SpriteBatch SB, ContentManager CM, int x, int y) //draws the drop on the left of the tile (The little darkish line to show the next tile up is lowered)
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheet"), new Rectangle((int)Math.Ceiling(((x + DropHeightInPixels) * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((y * TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling((TileSideLengthInPixels * Game1.Scale * Game1.Zoom)), (int)Math.Ceiling(DropHeightInPixels * Game1.Scale * Game1.Zoom)), //the destination rectangle
           new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels), (int)((TextureLocation.Y * TileSideLengthInPixels) + (TextureLocation.Y * RaisedHeightInPixels) + TileSideLengthInPixels - RaisedHeightInPixels), TileSideLengthInPixels, TileSideLengthInPixels), Color.White, Functions.toRadians(90f), new Vector2(0, 0), SpriteEffects.None, 0); //the source rectangle
        }
        protected bool shouldRenderRaised(Level level, int x, int y)
        {
            if (y >= level.MapDimensions.Y - 1)
            {
                return true;
            }
            else if (level.Map[x, y + 1].Raised == false && this.Raised)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool shouldRenderDrop(Level level, int x, int y)
        {
            if (y <= 0)
            {
                return false;
            }
            else if (level.Map[x, y - 1].Raised == false & this.Raised)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool shouldRenderDropLeft(Level level, int x, int y)
        {
            if (x <= 0)
            {
                return false;
            }
            else if (level.Map[x - 1, y].Raised == false & this.Raised)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool shouldRenderDropRight(Level level, int x, int y)
        {
            if (x >= level.MapDimensions.X - 1)
            {
                return false;
            }
            else if (level.Map[x + 1, y].Raised == false & this.Raised)
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
