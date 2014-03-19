using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Mars_Raiders
{
    public class EntityCursor : Entity
    {

        public EntityCursor()
            : base()
        {
            defineTexture();
        }

        protected override void defineTexture()
        {
            TextureLocation = new Vector2(0, 0);
        }
        public override void update(GameTime gt, Level level)
        {
            KeyboardState ks = Keyboard.GetState();
            Vector2 MousePosition = Functions.GetMouseCoords();

            this.x = (int)(MousePosition.X / Tile.TileSideLengthInPixels / Game1.Scale / Game1.Zoom);
            this.y = (int)(MousePosition.Y / Tile.TileSideLengthInPixels / Game1.Scale / Game1.Zoom);

            if (Game1.IM["Raise"].IsTapped)
            {
                level.Map[x, y].Raised = !level.Map[x, y].Raised;
            }
            if (Game1.IM["ZoomOut"].IsTapped)
            {
                Game1.Zoom -= 0.1f;
            }
            if (Game1.IM["ZoomIn"].IsTapped)
            {
                Game1.Zoom += 0.1f;
            }
            if (Game1.IM["PlaceBlock1"].IsTapped)
            {
                level.Map[x, y] = new TileStone();
            }

            if (Game1.IM["Save"].IsTapped)
            {
             level.save();
            }
            if (Game1.IM["Load"].IsTapped)
            {
              level.load();
            }
        
        }
 
    }
}
