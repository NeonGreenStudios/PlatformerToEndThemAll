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
    public abstract class Entity
    {
        public int x, y;
        public Boolean visible;
        public Boolean inTransition;
        protected Vector2 TextureLocation;
        const int FrameSizeInPixels = 32;

        public Entity()
        {

        }

        public void render(SpriteBatch SB, ContentManager CM)
        {
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/EntityFrames"), new Rectangle((int)(x * FrameSizeInPixels * Game1.Scale * Game1.Zoom), (int)(y * FrameSizeInPixels * Game1.Scale * Game1.Zoom), (int)(FrameSizeInPixels * Game1.Scale * Game1.Zoom), (int)(FrameSizeInPixels * Game1.Scale * Game1.Zoom)), //the destination rectangle
              new Rectangle((int)(TextureLocation.X * FrameSizeInPixels), (int)((TextureLocation.Y * FrameSizeInPixels)), FrameSizeInPixels, FrameSizeInPixels), Color.White); //the source rectangle

        }

        protected abstract void defineTexture();
        public abstract void update(GameTime gt, Level level);



    }
}
