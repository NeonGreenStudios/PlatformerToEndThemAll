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
    class HUD
    {



        private Tile DisplayTile = new TileExteriorPanel();

        private Texture2D texture;
        public void update(GameTime time)
        {

        }

        public void draw(SpriteBatch sb, ContentManager content)
        {
            if (texture == null)
            {
                texture = content.Load<Texture2D>("Graphics/HudTest");
            }
            else
            {
                sb.Draw(texture, new Rectangle(0, 0,(int) Game1.ScreenSize.X, (int)Game1.ScreenSize.Y), Color.White);
            }

    
        }

        public void setDrawTile(Tile TileToDisplay)
        {
            DisplayTile = TileToDisplay;
        }
    }
}
