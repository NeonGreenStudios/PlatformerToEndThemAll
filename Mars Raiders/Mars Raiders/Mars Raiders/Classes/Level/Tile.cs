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

        protected Vector2 TextureLocation;
        public const int TileSideLengthInPixels = 32;
        public static TileGrass Grass = new TileGrass();

        public Tile()
        {
            defineTexture();
        }

        protected abstract void defineTexture();
        public abstract void update(GameTime gt);
        public void draw(SpriteBatch SB, ContentManager CM, int x, int y)
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/TileSheetTom"), new Rectangle(x * TileSideLengthInPixels, y * TileSideLengthInPixels, TileSideLengthInPixels, TileSideLengthInPixels), //the destination rectangle
                new Rectangle((int)(TextureLocation.X * TileSideLengthInPixels), (int)(TextureLocation.Y * TileSideLengthInPixels), TileSideLengthInPixels, TileSideLengthInPixels), Color.White);
        }
      
    }
}
