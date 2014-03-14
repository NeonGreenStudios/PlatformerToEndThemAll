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

namespace Mars_Raiders.Classes
{
    class SpriteSheet
    {
        private static Texture2D Sheet;

        public void load(String Path,ContentManager C)
        {
            Sheet = C.Load<Texture2D>(Path);   
        }


        public void draw(Vector2 position, SpriteBatch sb)
        {
            
        }
    }
}
