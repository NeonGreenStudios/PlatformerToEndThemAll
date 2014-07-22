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
        public int RaisedOffset = 0;
        public float Depth = 0.25f;
        public Boolean visible;
        public Boolean inTransition;
        protected Vector2 TextureLocation; //top left of the frames for the entity (0 based)
        protected Vector2 Frame = new Vector2(); //current frame (0 based)
        public  readonly  int FrameSizeInPixels = 32;

        public Entity()
        {

        }

        public void render(SpriteBatch SB, ContentManager CM)
        {                                                                                      //removed * FrameSize
            SB.Draw(CM.Load<Texture2D>("Graphics/TileSheet/EntityFrames"), new Rectangle((int)(x *  Game1.Scale * Game1.Zoom) + Level.XOffset,(int)((y - RaisedOffset) * Game1.Scale * Game1.Zoom) + Level.YOffset, (int)(FrameSizeInPixels * Game1.Scale * Game1.Zoom), (int)(FrameSizeInPixels * Game1.Scale * Game1.Zoom)), //the destination rectangle
              new Rectangle((int)(FrameSizeInPixels * (TextureLocation.X + Frame.X)), (int)((FrameSizeInPixels * (TextureLocation.Y + Frame.Y))), FrameSizeInPixels, FrameSizeInPixels), Color.White,0f,new Vector2 (0,0),SpriteEffects.None,Depth); //the source rectangle
        
        }

        protected abstract void defineTexture();
        public abstract void update(GameTime gt, Level level);



    }
}
