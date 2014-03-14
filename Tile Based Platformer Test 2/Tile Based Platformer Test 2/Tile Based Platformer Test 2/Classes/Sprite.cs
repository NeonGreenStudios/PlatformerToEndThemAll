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

namespace Tile_Based_Platformer_Test_2
{
    public class Sprite
    {
        public Vector2 Position = new Vector2(0,0);
        public Int16 Maximum_Health;
        public float Layer;
        public Int16 Current_Health;
        public Boolean Kill_Able;

        public void Move()
        {
        }

        public void Draw(SpriteBatch SB, ContentManager C)
        {
            SB.Draw(C.Load<Texture2D>("Player/Player1"), new Rectangle(Convert.ToInt16(Position.X), Convert.ToInt16(Position.Y), 15, 15), new Rectangle(0, 0, 15, 15), Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.None, 0.5f);
        }
    }
}
